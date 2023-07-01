Imports System

Namespace xBRZ.Color
	' Token: 0x0200002A RID: 42
	Friend Class ColorEq
		Inherits ColorDist

		' Token: 0x060000E7 RID: 231 RVA: 0x00008C48 File Offset: 0x00006E48
		Public Sub New(cfg As ScalerCfg)
			MyBase.New(cfg)
		End Sub

		' Token: 0x060000E8 RID: 232 RVA: 0x00008C54 File Offset: 0x00006E54
		Public Function IsColorEqual(color1 As Integer, color2 As Integer) As Boolean
			Dim eqColorThres As Double = Math.Pow(Me.Cfg.EqualColorTolerance, 2.0)
			Return MyBase.DistYCbCr(color1, color2) < eqColorThres
		End Function
	End Class
End Namespace
