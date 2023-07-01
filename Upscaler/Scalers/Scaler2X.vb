Imports System

Namespace xBRZ.Scalers
	' Token: 0x0200001F RID: 31
	Friend Class Scaler2X
		Inherits ScalerBase
		Implements IScaler

        Public ReadOnly Property Scale As Integer Implements IScaler.Scale
            Get
                Return 2
            End Get
        End Property

        ' Token: 0x1700003E RID: 62
        ' (get) Token: 0x060000BA RID: 186 RVA: 0x000080BB File Offset: 0x000062BB

        ' Token: 0x060000BB RID: 187 RVA: 0x000080C3 File Offset: 0x000062C3
        Public Sub BlendLineShallow(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineShallow
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 1, 0), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(Me.Scale - 1, 1), col)
		End Sub

		' Token: 0x060000BC RID: 188 RVA: 0x000080F3 File Offset: 0x000062F3
		Public Sub BlendLineSteep(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineSteep
			ScalerBase.AlphaBlend(1, 4, out_.Ref(0, Me.Scale - 1), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(1, Me.Scale - 1), col)
		End Sub

		' Token: 0x060000BD RID: 189 RVA: 0x00008123 File Offset: 0x00006323
		Public Sub BlendLineSteepAndShallow(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineSteepAndShallow
			ScalerBase.AlphaBlend(1, 4, out_.Ref(1, 0), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(0, 1), col)
			ScalerBase.AlphaBlend(5, 6, out_.Ref(1, 1), col)
		End Sub

		' Token: 0x060000BE RID: 190 RVA: 0x00008155 File Offset: 0x00006355
		Public Sub BlendLineDiagonal(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineDiagonal
			ScalerBase.AlphaBlend(1, 2, out_.Ref(1, 1), col)
		End Sub

		' Token: 0x060000BF RID: 191 RVA: 0x00008167 File Offset: 0x00006367
		Public Sub BlendCorner(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendCorner
			ScalerBase.AlphaBlend(21, 100, out_.Ref(1, 1), col)
		End Sub
	End Class
End Namespace
