Imports UltraScaler.xBRZ.Common

Namespace xBRZ.Scalers
    ' Token: 0x0200001B RID: 27
    Friend Class OutputMatrix
        ' Token: 0x060000A9 RID: 169 RVA: 0x00007E23 File Offset: 0x00006023
        Public Sub New(scale As Integer, outPtr As Integer(), outWidth As Integer)
            Me._n = (scale - 2) * 100
            Me._out = New xBRZ.Common.IntPtr(outPtr)
            Me._outWidth = outWidth
        End Sub

        ' Token: 0x060000AA RID: 170 RVA: 0x00007E4A File Offset: 0x0000604A
        Public Sub Move(rotDeg As Integer, outi As Integer)
            Me._nr = Me._n + rotDeg * 25
            Me._outi = outi
        End Sub

        ' Token: 0x060000AB RID: 171 RVA: 0x00007E64 File Offset: 0x00006064
        Public Function Ref(i As Integer, j As Integer) As xBRZ.Common.IntPtr
            Dim rot As IntPair = OutputMatrix.MatrixRotation(Me._nr + i * 5 + j)
            Me._out.Position(Me._outi + rot.J + rot.I * Me._outWidth)
            Return Me._out
        End Function

        ' Token: 0x060000AC RID: 172 RVA: 0x00007EB0 File Offset: 0x000060B0
        Shared Sub New()
            For i As Integer = 2 To 6 - 1
                For r As Integer = 0 To 4 - 1
                    Dim nr As Integer = (i - 2) * 100 + r * 25
                    For j As Integer = 0 To 5 - 1
                        For k As Integer = 0 To 5 - 1
                            OutputMatrix.MatrixRotation(nr + j * 5 + k) = OutputMatrix.BuildMatrixRotation(r, j, k, i)
                        Next
                    Next
                Next
            Next
        End Sub

        ' Token: 0x060000AD RID: 173 RVA: 0x00007F24 File Offset: 0x00006124
        Private Shared Function BuildMatrixRotation(rotDeg As Integer, i As Integer, j As Integer, n As Integer) As IntPair
            Dim iOld As Integer
            Dim jOld As Integer
            If rotDeg = 0 Then
                iOld = i
                jOld = j
            Else
                Dim old As IntPair = OutputMatrix.BuildMatrixRotation(rotDeg - 1, i, j, n)
                iOld = n - 1 - old.J
                jOld = old.I
            End If
            Return New IntPair(iOld, jOld)
        End Function

        ' Token: 0x04000087 RID: 135
        Private _out As xBRZ.Common.IntPtr

        ' Token: 0x04000088 RID: 136
        Private _outWidth As Integer

        ' Token: 0x04000089 RID: 137
        Private _n As Integer

        ' Token: 0x0400008A RID: 138
        Private _outi As Integer

        ' Token: 0x0400008B RID: 139
        Private _nr As Integer

        ' Token: 0x0400008C RID: 140
        Private Const MaxScale As Integer = 5

        ' Token: 0x0400008D RID: 141
        Private Const MaxScaleSquared As Integer = 25

        ' Token: 0x0400008E RID: 142
        Private Shared MatrixRotation As IntPair() = New IntPair(399) {}
    End Class
End Namespace
