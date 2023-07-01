Imports System.Drawing.Imaging
Imports System.IO
Imports System.Threading.Tasks
Imports UltraScaler.xBRZ.Blend
Imports UltraScaler.xBRZ.Color
Imports UltraScaler.xBRZ.Common
Imports UltraScaler.xBRZ.Extensions
Imports UltraScaler.xBRZ.Scalers

Namespace xBRZ
    ' Token: 0x02000018 RID: 24
    Public Class xBRZScaler
        ' Token: 0x0600009F RID: 159 RVA: 0x00007334 File Offset: 0x00005534
        Public Sub ScaleImage(Input As String, Output As String, scaleSize As Integer, Optional config As ScalerCfg = Nothing)
            Using fs As FileStream = New FileStream(Input, FileMode.Open)
                Dim img As Bitmap = CType(Image.FromStream(fs, False, False), Bitmap)
                Dim pixelFormat As PixelFormat = img.PixelFormat
                config = (If(config, New ScalerCfg()))
                If img.PixelFormat <> PixelFormat.Format32bppRgb Then
                    img = BitmapExtensions.ChangeFormat(img, PixelFormat.Format32bppRgb)
                End If
                Dim rgbValues As Integer() = img.ToIntArray()
                Dim scaledRbgValues As Integer() = New Integer(rgbValues.Length * (scaleSize * scaleSize) - 1) {}
                Me.ScaleImage(scaleSize, rgbValues, scaledRbgValues, img.Width, img.Height, config, 0, Integer.MaxValue)
                scaledRbgValues.ToBitmap(img.Width * scaleSize, img.Height * scaleSize, img.PixelFormat, Output)
            End Using
        End Sub

        ' Token: 0x060000A0 RID: 160 RVA: 0x000073F4 File Offset: 0x000055F4
        Public Sub ScaleImage(scaleSize As Integer, src As Integer(), trg As Integer(), srcWidth As Integer, srcHeight As Integer, cfg As ScalerCfg, yFirst As Integer, yLast As Integer)
            Me._scaler = scaleSize.ToIScaler()
            Me._cfg = cfg
            Me._colorDistance = New ColorDist(Me._cfg)
            Me._colorEqualizer = New ColorEq(Me._cfg)
            Me.ScaleImageImpl(src, trg, srcWidth, srcHeight, yFirst, yLast)
        End Sub

        ' Token: 0x060000A1 RID: 161 RVA: 0x00007448 File Offset: 0x00005648
        Private Shared Sub FillBlock(trg As Integer(), trgi As Integer, pitch As Integer, col As Integer, blockSize As Integer)
            Dim y As Integer = 0
            While y < blockSize
                For x As Integer = 0 To blockSize - 1
                    trg(trgi + x) = col
                Next
                y += 1
                trgi += pitch
            End While
        End Sub

        ' Token: 0x060000A2 RID: 162 RVA: 0x0000747C File Offset: 0x0000567C
        Private Sub PreProcessCorners(ker As Kernel4x4)
            Me._blendResult.Reset()
            If (ker.F = ker.G AndAlso ker.J = ker.K) OrElse (ker.F = ker.J AndAlso ker.G = ker.K) Then
                Return
            End If
            Dim dist As ColorDist = Me._colorDistance
            Dim jg As Double = dist.DistYCbCr(ker.I, ker.F) + dist.DistYCbCr(ker.F, ker.C) + dist.DistYCbCr(ker.N, ker.K) + dist.DistYCbCr(ker.K, ker.H) + 4.0 * dist.DistYCbCr(ker.J, ker.G)
            Dim fk As Double = dist.DistYCbCr(ker.E, ker.J) + dist.DistYCbCr(ker.J, ker.O) + dist.DistYCbCr(ker.B, ker.G) + dist.DistYCbCr(ker.G, ker.L) + 4.0 * dist.DistYCbCr(ker.F, ker.K)
            If jg < fk Then
                Dim dominantGradient As Boolean = Me._cfg.DominantDirectionThreshold * jg < fk
                If ker.F <> ker.G AndAlso ker.F <> ker.J Then
                    Me._blendResult.F = If(dominantGradient, ChrW(2), ChrW(1))
                End If
                If ker.K <> ker.J AndAlso ker.K <> ker.G Then
                    Me._blendResult.K = If(dominantGradient, ChrW(2), ChrW(1))
                    Return
                End If
            ElseIf fk < jg Then
                Dim dominantGradient2 As Boolean = Me._cfg.DominantDirectionThreshold * fk < jg
                If ker.J <> ker.F AndAlso ker.J <> ker.K Then
                    Me._blendResult.J = If(dominantGradient2, ChrW(2), ChrW(1))
                End If
                If ker.G <> ker.F AndAlso ker.G <> ker.K Then
                    Me._blendResult.G = If(dominantGradient2, ChrW(2), ChrW(1))
                End If
            End If
        End Sub

        ' Token: 0x060000A3 RID: 163 RVA: 0x00007698 File Offset: 0x00005898
        Private Sub ScalePixel(scaler As IScaler, rotDeg As Integer, ker As Kernel3x3, trgi As Integer, blendInfo As Char)
            Dim b As Integer = ker.K_(Rot.R_(4 + rotDeg))
            Dim c As Integer = ker.K_(Rot.R_(8 + rotDeg))
            Dim d As Integer = ker.K_(Rot.R_(12 + rotDeg))
            Dim e As Integer = ker.K_(Rot.R_(16 + rotDeg))
            Dim f As Integer = ker.K_(Rot.R_(20 + rotDeg))
            Dim g As Integer = ker.K_(Rot.R_(24 + rotDeg))
            Dim h As Integer = ker.K_(Rot.R_(28 + rotDeg))
            Dim i As Integer = ker.K_(Rot.R_(32 + rotDeg))
            Dim blend As Char = Rotate(blendInfo, CType(rotDeg, RotationDegree))
            If GetBottomR(blend) = vbNullChar Then
                Return
            End If
            Dim eq As ColorEq = Me._colorEqualizer
            Dim dist As ColorDist = Me._colorDistance
            Dim doLineBlend As Boolean = GetBottomR(blend) >= ChrW(2) OrElse ((GetTopR(blend) = vbNullChar OrElse eq.IsColorEqual(e, g)) AndAlso (GetBottomL(blend) = vbNullChar OrElse eq.IsColorEqual(e, c)) AndAlso (Not eq.IsColorEqual(g, h) OrElse Not eq.IsColorEqual(h, i) OrElse Not eq.IsColorEqual(i, f) OrElse Not eq.IsColorEqual(f, c) OrElse eq.IsColorEqual(e, i)))
            Dim px As Integer = If((dist.DistYCbCr(e, f) <= dist.DistYCbCr(e, h)), f, h)
            Dim out_ As OutputMatrix = Me._outputMatrix
            out_.Move(rotDeg, trgi)
            If Not doLineBlend Then
                scaler.BlendCorner(px, out_)
                Return
            End If
            Dim fg As Double = dist.DistYCbCr(f, g)
            Dim hc As Double = dist.DistYCbCr(h, c)
            Dim flag As Boolean = Me._cfg.SteepDirectionThreshold * fg <= hc AndAlso e <> g AndAlso d <> g
            Dim haveSteepLine As Boolean = Me._cfg.SteepDirectionThreshold * hc <= fg AndAlso e <> c AndAlso b <> c
            If flag Then
                If haveSteepLine Then
                    scaler.BlendLineSteepAndShallow(px, out_)
                    Return
                End If
                scaler.BlendLineShallow(px, out_)
                Return
            Else
                If haveSteepLine Then
                    scaler.BlendLineSteep(px, out_)
                    Return
                End If
                scaler.BlendLineDiagonal(px, out_)
                Return
            End If
        End Sub

        ' Token: 0x060000A4 RID: 164 RVA: 0x000078B8 File Offset: 0x00005AB8
        Private Sub ScaleImageImpl(src As Integer(), trg As Integer(), srcWidth As Integer, srcHeight As Integer, yFirst As Integer, yLast As Integer)
            yFirst = Math.Max(yFirst, 0)
            yLast = Math.Min(yLast, srcHeight)
            If yFirst >= yLast OrElse srcWidth <= 0 Then
                Return
            End If
            Dim trgWidth As Integer = srcWidth * Me._scaler.Scale
            Dim preProcBuffer As Char() = New Char(srcWidth - 1) {}
            Dim ker4 As Kernel4x4 = New Kernel4x4()
            If yFirst > 0 Then
                Dim y As Integer = yFirst - 1
                Dim sM1 As Integer = srcWidth * Math.Max(y - 1, 0)
                Dim s0 As Integer = srcWidth * y
                Dim sP1 As Integer = srcWidth * Math.Min(y + 1, srcHeight - 1)
                Dim sP2 As Integer = srcWidth * Math.Min(y + 2, srcHeight - 1)
                Parallel.[For](0, srcWidth, Sub(x As Integer)
                                                Dim xM2 As Integer = Math.Max(x - 1, 0)
                                                Dim xP3 As Integer = Math.Min(x + 1, srcWidth - 1)
                                                Dim xP4 As Integer = Math.Min(x + 2, srcWidth - 1)
                                                ker4.A = src(sM1 + xM2)
                                                ker4.B = src(sM1 + x)
                                                ker4.C = src(sM1 + xP3)
                                                ker4.D = src(sM1 + xP4)
                                                ker4.E = src(s0 + xM2)
                                                ker4.F = src(s0 + x)
                                                ker4.G = src(s0 + xP3)
                                                ker4.H = src(s0 + xP4)
                                                ker4.I = src(sP1 + xM2)
                                                ker4.J = src(sP1 + x)
                                                ker4.K = src(sP1 + xP3)
                                                ker4.L = src(sP1 + xP4)
                                                ker4.M = src(sP2 + xM2)
                                                ker4.N = src(sP2 + x)
                                                ker4.O = src(sP2 + xP3)
                                                ker4.P = src(sP2 + xP4)
                                                Me.PreProcessCorners(ker4)
                                                preProcBuffer(x) = SetTopR(preProcBuffer(x), Me._blendResult.J)
                                                If x + 1 < srcWidth Then
                                                    preProcBuffer(x + 1) = SetTopL(preProcBuffer(x + 1), Me._blendResult.K)
                                                End If
                                            End Sub)
            End If
            Me._outputMatrix = New OutputMatrix(Me._scaler.Scale, trg, trgWidth)
            Dim ker3 As Kernel3x3 = New Kernel3x3()
            For y2 As Integer = yFirst To yLast - 1
                Dim trgi As Integer = Me._scaler.Scale * y2 * trgWidth
                Dim sM As Integer = srcWidth * Math.Max(y2 - 1, 0)
                Dim s As Integer = srcWidth * y2
                Dim sP As Integer = srcWidth * Math.Min(y2 + 1, srcHeight - 1)
                Dim sP3 As Integer = srcWidth * Math.Min(y2 + 2, srcHeight - 1)
                Dim blendXy As Char = vbNullChar
                Dim x2 As Integer = 0
                While x2 < srcWidth
                    Dim xM As Integer = Math.Max(x2 - 1, 0)
                    Dim xP As Integer = Math.Min(x2 + 1, srcWidth - 1)
                    Dim xP2 As Integer = Math.Min(x2 + 2, srcWidth - 1)
                    ker4.A = src(sM + xM)
                    ker4.B = src(sM + x2)
                    ker4.C = src(sM + xP)
                    ker4.D = src(sM + xP2)
                    ker4.E = src(s + xM)
                    ker4.F = src(s + x2)
                    ker4.G = src(s + xP)
                    ker4.H = src(s + xP2)
                    ker4.I = src(sP + xM)
                    ker4.J = src(sP + x2)
                    ker4.K = src(sP + xP)
                    ker4.L = src(sP + xP2)
                    ker4.M = src(sP3 + xM)
                    ker4.N = src(sP3 + x2)
                    ker4.O = src(sP3 + xP)
                    ker4.P = src(sP3 + xP2)
                    Me.PreProcessCorners(ker4)
                    Dim blendXy2 As Char = SetBottomR(preProcBuffer(x2), Me._blendResult.F)
                    blendXy = SetTopR(blendXy, Me._blendResult.J)
                    preProcBuffer(x2) = blendXy
                    blendXy = SetTopL(vbNullChar, Me._blendResult.K)
                    If x2 + 1 < srcWidth Then
                        preProcBuffer(x2 + 1) = SetBottomL(preProcBuffer(x2 + 1), Me._blendResult.G)
                    End If
                    xBRZScaler.FillBlock(trg, trgi, trgWidth, src(s + x2), Me._scaler.Scale)
                    If blendXy2 <> vbNullChar Then
                        ker3.K_(0) = src(sM + xM)
                        ker3.K_(1) = src(sM + x2)
                        ker3.K_(2) = src(sM + xP)
                        ker3.K_(3) = src(s + xM)
                        ker3.K_(4) = src(s + x2)
                        ker3.K_(5) = src(s + xP)
                        ker3.K_(6) = src(sP + xM)
                        ker3.K_(7) = src(sP + x2)
                        ker3.K_(8) = src(sP + xP)
                        Me.ScalePixel(Me._scaler, 0, ker3, trgi, blendXy2)
                        Me.ScalePixel(Me._scaler, 1, ker3, trgi, blendXy2)
                        Me.ScalePixel(Me._scaler, 2, ker3, trgi, blendXy2)
                        Me.ScalePixel(Me._scaler, 3, ker3, trgi, blendXy2)
                    End If
                    x2 += 1
                    trgi += Me._scaler.Scale
                End While
            Next
        End Sub

        ' Token: 0x04000070 RID: 112
        Private _cfg As ScalerCfg

        ' Token: 0x04000071 RID: 113
        Private _scaler As IScaler

        ' Token: 0x04000072 RID: 114
        Private _outputMatrix As OutputMatrix

        ' Token: 0x04000073 RID: 115
        Private _blendResult As BlendResult = New BlendResult()

        ' Token: 0x04000074 RID: 116
        Private _colorDistance As ColorDist

        ' Token: 0x04000075 RID: 117
        Private _colorEqualizer As ColorEq
    End Class
End Namespace
