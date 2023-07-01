Imports System

Namespace xBRZ.Color
	' Token: 0x02000029 RID: 41
	Friend Class ColorDist
		' Token: 0x060000E5 RID: 229 RVA: 0x00008B63 File Offset: 0x00006D63
		Public Sub New(cfg As ScalerCfg)
			Me.Cfg = cfg
		End Sub

		' Token: 0x060000E6 RID: 230 RVA: 0x00008B74 File Offset: 0x00006D74
		Public Function DistYCbCr(pix1 As Integer, pix2 As Integer) As Double
			If pix1 = pix2 Then
				Return 0.0
			End If
			Dim rDiff As Integer = (pix1 And 16711680) - (pix2 And 16711680) >> 16
			Dim gDiff As Integer = (pix1 And 65280) - (pix2 And 65280) >> 8
			Dim bDiff As Integer = (pix1 And 255) - (pix2 And 255)
			Dim y As Double = 0.2126 * CDbl(rDiff) + 0.7152 * CDbl(gDiff) + 0.0722 * CDbl(bDiff)
			Dim cB As Double = 0.5389092476826902 * (CDbl(bDiff) - y)
			Dim cR As Double = 0.63500127000254 * (CDbl(rDiff) - y)
			Return Math.Pow(Me.Cfg.LuminanceWeight * y, 2.0) + Math.Pow(cB, 2.0) + Math.Pow(cR, 2.0)
		End Function

		' Token: 0x040000A3 RID: 163
		Protected Cfg As ScalerCfg
	End Class
End Namespace
