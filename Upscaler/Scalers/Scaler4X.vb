Imports System

Namespace xBRZ.Scalers
	' Token: 0x02000021 RID: 33
	Friend Class Scaler4X
		Inherits ScalerBase
		Implements IScaler

        Public ReadOnly Property Scale As Integer Implements IScaler.Scale
            Get
                Return 4
            End Get
        End Property

        ' Token: 0x17000040 RID: 64
        ' (get) Token: 0x060000C8 RID: 200 RVA: 0x00008314 File Offset: 0x00006514

        ' Token: 0x060000C9 RID: 201 RVA: 0x0000831C File Offset: 0x0000651C
        Public Sub BlendLineShallow(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineShallow
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 1, 0), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(Me.Scale - 2, 2), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(Me.Scale - 1, 1), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(Me.Scale - 2, 3), col)
			out_.Ref(Me.Scale - 1, 2).[Set](col)
			out_.Ref(Me.Scale - 1, 3).[Set](col)
		End Sub

		' Token: 0x060000CA RID: 202 RVA: 0x000083B0 File Offset: 0x000065B0
		Public Sub BlendLineSteep(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineSteep
			ScalerBase.AlphaBlend(1, 4, out_.Ref(0, Me.Scale - 1), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(2, Me.Scale - 2), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(1, Me.Scale - 1), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(3, Me.Scale - 2), col)
			out_.Ref(2, Me.Scale - 1).[Set](col)
			out_.Ref(3, Me.Scale - 1).[Set](col)
		End Sub

		' Token: 0x060000CB RID: 203 RVA: 0x00008444 File Offset: 0x00006644
		Public Sub BlendLineSteepAndShallow(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineSteepAndShallow
			ScalerBase.AlphaBlend(3, 4, out_.Ref(3, 1), col)
			ScalerBase.AlphaBlend(3, 4, out_.Ref(1, 3), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(3, 0), col)
			ScalerBase.AlphaBlend(1, 4, out_.Ref(0, 3), col)
			ScalerBase.AlphaBlend(1, 3, out_.Ref(2, 2), col)
			out_.Ref(3, 3).[Set](col)
			out_.Ref(3, 2).[Set](col)
			out_.Ref(2, 3).[Set](col)
		End Sub

		' Token: 0x060000CC RID: 204 RVA: 0x000084CC File Offset: 0x000066CC
		Public Sub BlendLineDiagonal(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendLineDiagonal
			ScalerBase.AlphaBlend(1, 2, out_.Ref(Me.Scale - 1, Me.Scale / 2), col)
			ScalerBase.AlphaBlend(1, 2, out_.Ref(Me.Scale - 2, Me.Scale / 2 + 1), col)
			out_.Ref(Me.Scale - 1, Me.Scale - 1).[Set](col)
		End Sub

		' Token: 0x060000CD RID: 205 RVA: 0x00008533 File Offset: 0x00006733
		Public Sub BlendCorner(col As Integer, out_ As OutputMatrix) Implements xBRZ.Scalers.IScaler.BlendCorner
			ScalerBase.AlphaBlend(68, 100, out_.Ref(3, 3), col)
			ScalerBase.AlphaBlend(9, 100, out_.Ref(3, 2), col)
			ScalerBase.AlphaBlend(9, 100, out_.Ref(2, 3), col)
		End Sub
	End Class
End Namespace
