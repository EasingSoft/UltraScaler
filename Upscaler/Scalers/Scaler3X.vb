Imports System

Namespace xBRZ.Scalers
	' Token: 0x02000020 RID: 32
	Friend Class Scaler3X
		Inherits ScalerBase
		Implements IScaler

        Public ReadOnly Property Scale As Integer Implements IScaler.Scale
            Get
                Return 3
            End Get
        End Property

        ' Token: 0x1700003F RID: 63
        ' (get) Token: 0x060000C1 RID: 193 RVA: 0x0000818A File Offset: 0x0000638A

        ' Token: 0x060000C2 RID: 194 RVA: 0x00008194 File Offset: 0x00006394
        Public Sub BlendLineShallow(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineShallow
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 1, 0), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 2, 2), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(Me.Scale - 1, 1), col)
			out_.Ref(Me.Scale - 1, 2).[Set](col)
		End Sub

		' Token: 0x060000C3 RID: 195 RVA: 0x000081FC File Offset: 0x000063FC
		Public Sub BlendLineSteep(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineSteep
			ScalerBase.AlphaBlend(1, 4, out_.Ref(0, Me.Scale - 1), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(2, Me.Scale - 2), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(1, Me.Scale - 1), col)
			out_.Ref(2, Me.Scale - 1).[Set](col)
		End Sub

		' Token: 0x060000C4 RID: 196 RVA: 0x00008264 File Offset: 0x00006464
		Public Sub BlendLineSteepAndShallow(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineSteepAndShallow
			ScalerBase.AlphaBlend(1, 4, out_.Ref(2, 0), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(0, 2), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(2, 1), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(1, 2), col)
			out_.Ref(2, 2).[Set](col)
		End Sub

		' Token: 0x060000C5 RID: 197 RVA: 0x000082BF File Offset: 0x000064BF
		Public Sub BlendLineDiagonal(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineDiagonal
			ScalerBase.AlphaBlend(1, 8, out_.Ref(1, 2), col)
			ScalerBase.AlphaBlend(1, 8, out_.Ref(2, 1), col)
			ScalerBase.AlphaBlend(7, 8, out_.Ref(2, 2), col)
		End Sub

		' Token: 0x060000C6 RID: 198 RVA: 0x000082F1 File Offset: 0x000064F1
		Public Sub BlendCorner(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendCorner
			ScalerBase.AlphaBlend(45, 100, out_.Ref(2, 2), col)
		End Sub
	End Class
End Namespace
