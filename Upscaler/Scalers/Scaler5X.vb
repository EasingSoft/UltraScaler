Imports System

Namespace xBRZ.Scalers
	' Token: 0x02000022 RID: 34
	Friend Class Scaler5X
		Inherits ScalerBase
		Implements IScaler

        Public ReadOnly Property Scale As Integer Implements IScaler.Scale
            Get
               Return 5
            End Get
        End Property

        ' Token: 0x17000041 RID: 65
        ' (get) Token: 0x060000CF RID: 207 RVA: 0x0000857A File Offset: 0x0000677A

        ' Token: 0x060000D0 RID: 208 RVA: 0x00008584 File Offset: 0x00006784
        Public Sub BlendLineShallow(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineShallow
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 1, 0), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 2, 2), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 3, 4), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(Me.Scale - 1, 1), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(Me.Scale - 2, 3), col)
			out_.Ref(Me.Scale - 1, 2).[Set](col)
			out_.Ref(Me.Scale - 1, 3).[Set](col)
			out_.Ref(Me.Scale - 1, 4).[Set](col)
			out_.Ref(Me.Scale - 2, 4).[Set](col)
		End Sub

		' Token: 0x060000D1 RID: 209 RVA: 0x00008658 File Offset: 0x00006858
		Public Sub BlendLineSteep(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineSteep
			ScalerBase.AlphaBlend(1, 4, out_.Ref(0, Me.Scale - 1), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(2, Me.Scale - 2), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(4, Me.Scale - 3), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(1, Me.Scale - 1), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(3, Me.Scale - 2), col)
			out_.Ref(2, Me.Scale - 1).[Set](col)
			out_.Ref(3, Me.Scale - 1).[Set](col)
			out_.Ref(4, Me.Scale - 1).[Set](col)
			out_.Ref(4, Me.Scale - 2).[Set](col)
		End Sub

		' Token: 0x060000D2 RID: 210 RVA: 0x0000872C File Offset: 0x0000692C
		Public Sub BlendLineSteepAndShallow(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineSteepAndShallow
			ScalerBase.AlphaBlend(1, 4, out_.Ref(0, Me.Scale - 1), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(2, Me.Scale - 2), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(1, Me.Scale - 1), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 1, 0), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 2, 2), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(Me.Scale - 1, 1), col)
			out_.Ref(2, Me.Scale - 1).[Set](col)
			out_.Ref(3, Me.Scale - 1).[Set](col)
			out_.Ref(Me.Scale - 1, 2).[Set](col)
			out_.Ref(Me.Scale - 1, 3).[Set](col)
			out_.Ref(4, Me.Scale - 1).[Set](col)
			ScalerBase.AlphaBlend(2, 3, out_.Ref(3, 3), col)
		End Sub

		' Token: 0x060000D3 RID: 211 RVA: 0x0000883C File Offset: 0x00006A3C
		Public Sub BlendLineDiagonal(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineDiagonal
			ScalerBase.AlphaBlend(1, 8, out_.Ref(Me.Scale - 1, Me.Scale / 2), col)
			ScalerBase.AlphaBlend(1, 8, out_.Ref(Me.Scale - 2, Me.Scale / 2 + 1), col)
			ScalerBase.AlphaBlend(1, 8, out_.Ref(Me.Scale - 3, Me.Scale / 2 + 2), col)
			ScalerBase.AlphaBlend(7, 8, out_.Ref(4, 3), col)
			ScalerBase.AlphaBlend(7, 8, out_.Ref(3, 4), col)
			out_.Ref(4, 4).[Set](col)
		End Sub

		' Token: 0x060000D4 RID: 212 RVA: 0x000088D5 File Offset: 0x00006AD5
		Public Sub BlendCorner(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendCorner
			ScalerBase.AlphaBlend(86, 100, out_.Ref(4, 4), col)
			ScalerBase.AlphaBlend(23, 100, out_.Ref(4, 3), col)
			ScalerBase.AlphaBlend(23, 100, out_.Ref(3, 4), col)
		End Sub
	End Class
End Namespace
