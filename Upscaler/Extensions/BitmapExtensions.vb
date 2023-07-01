Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Namespace xBRZ.Extensions
	' Token: 0x02000024 RID: 36
	Friend Module BitmapExtensions
		' Token: 0x060000D8 RID: 216 RVA: 0x0000897C File Offset: 0x00006B7C
		Public Function ChangeFormat(image As Bitmap, format As PixelFormat) As Bitmap
			Dim newFormatImage As Bitmap = New Bitmap(image.Width, image.Height, format)
			Using gr As Graphics = Graphics.FromImage(newFormatImage)
				gr.DrawImage(image, New Rectangle(0, 0, newFormatImage.Width, newFormatImage.Height))
			End Using
			image.Dispose()
			Return newFormatImage
		End Function

		' Token: 0x060000D9 RID: 217 RVA: 0x000089E0 File Offset: 0x00006BE0
		<System.Runtime.CompilerServices.ExtensionAttribute()>
		Public Function ToIntArray(image As Bitmap) As Integer()
			Dim rectangle As Rectangle = New Rectangle(0, 0, image.Width, image.Height)
			Dim bitmapData As BitmapData = image.LockBits(rectangle, ImageLockMode.ReadWrite, image.PixelFormat)
			Dim bitmapPointer As IntPtr = bitmapData.Scan0
			If bitmapData.Stride < 0 Then
				bitmapPointer += bitmapData.Stride * (image.Height - 1)
			End If
			Dim intCount As Integer = bitmapData.Stride * image.Height / 4
			Dim values As Integer() = New Integer(intCount - 1) {}
			Marshal.Copy(bitmapPointer, values, 0, intCount)
			image.UnlockBits(bitmapData)
			Return values
		End Function

		' Token: 0x060000DA RID: 218 RVA: 0x00008A64 File Offset: 0x00006C64
		<System.Runtime.CompilerServices.ExtensionAttribute()>
		Public Sub ToBitmap(bitmapData As Integer(), width As Integer, height As Integer, format As PixelFormat, Output As String)
			Using newImage As Bitmap = New Bitmap(width, height, format)
				Dim rectangle As Rectangle = New Rectangle(0, 0, newImage.Width, newImage.Height)
				Dim newBitmapData As BitmapData = newImage.LockBits(rectangle, ImageLockMode.ReadWrite, format)
				Dim newBitmapPointer As IntPtr = newBitmapData.Scan0
				Dim intCount As Integer = newBitmapData.Stride * newImage.Height / 4
				Marshal.Copy(bitmapData, 0, newBitmapPointer, intCount)
				newImage.UnlockBits(newBitmapData)
				newImage.Save(Output, ImageFormat.Jpeg)
			End Using
		End Sub
	End Module
End Namespace
