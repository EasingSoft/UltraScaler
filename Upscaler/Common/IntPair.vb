Imports System

Namespace xBRZ.Common
	' Token: 0x02000025 RID: 37
	Friend Class IntPair
		' Token: 0x17000042 RID: 66
		' (get) Token: 0x060000DB RID: 219 RVA: 0x00008AEC File Offset: 0x00006CEC
		' (set) Token: 0x060000DC RID: 220 RVA: 0x00008AF4 File Offset: 0x00006CF4
		Public Property I As Integer

		' Token: 0x17000043 RID: 67
		' (get) Token: 0x060000DD RID: 221 RVA: 0x00008AFD File Offset: 0x00006CFD
		' (set) Token: 0x060000DE RID: 222 RVA: 0x00008B05 File Offset: 0x00006D05
		Public Property J As Integer

		' Token: 0x060000DF RID: 223 RVA: 0x00008B0E File Offset: 0x00006D0E
		Public Sub New(i As Integer, j As Integer)
			Me.I = i
			Me.J = j
		End Sub
	End Class
End Namespace
