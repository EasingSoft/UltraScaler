Imports System

Namespace xBRZ.Common
	' Token: 0x02000026 RID: 38
	Friend Class IntPtr
		' Token: 0x060000E0 RID: 224 RVA: 0x00008B24 File Offset: 0x00006D24
		Public Sub New(array As Integer())
			Me._array = array
		End Sub

		' Token: 0x060000E1 RID: 225 RVA: 0x00008B33 File Offset: 0x00006D33
		Public Sub Position(position As Integer)
			Me._ptr = position
		End Sub

		' Token: 0x060000E2 RID: 226 RVA: 0x00008B3C File Offset: 0x00006D3C
		Public Function [Get]() As Integer
			Return Me._array(Me._ptr)
		End Function

		' Token: 0x060000E3 RID: 227 RVA: 0x00008B4B File Offset: 0x00006D4B
		Public Sub [Set](val As Integer)
			Me._array(Me._ptr) = val
		End Sub

		' Token: 0x04000099 RID: 153
		Private _array As Integer()

		' Token: 0x0400009A RID: 154
		Private _ptr As Integer
	End Class
End Namespace
