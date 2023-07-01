Imports System

Namespace xBRZ.Scalers
	' Token: 0x0200001D RID: 29
	Friend Interface IScaler
		' Token: 0x1700003D RID: 61
		' (get) Token: 0x060000B1 RID: 177
		ReadOnly Property Scale As Integer

		' Token: 0x060000B2 RID: 178
		Sub BlendLineSteep(col As Integer, out_ As OutputMatrix)

		' Token: 0x060000B3 RID: 179
		Sub BlendLineSteepAndShallow(col As Integer, out_ As OutputMatrix)

		' Token: 0x060000B4 RID: 180
		Sub BlendLineShallow(col As Integer, out_ As OutputMatrix)

		' Token: 0x060000B5 RID: 181
		Sub BlendLineDiagonal(col As Integer, out_ As OutputMatrix)

		' Token: 0x060000B6 RID: 182
		Sub BlendCorner(col As Integer, out_ As OutputMatrix)
	End Interface
End Namespace
