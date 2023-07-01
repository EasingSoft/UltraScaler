Imports System.IO
Imports System.Threading

Public Class Main
    Private Sub ScaleCount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ScaleCount.SelectedIndexChanged
        Dim Scale = ScaleCount.SelectedItem.ToString()
        For Each Row In Grid.Rows.Cast(Of DataGridViewRow)
            Dim Dimensions = Row.Cells(3).Value.ToString().Split("x"c)
            Dim W = Integer.Parse(Dimensions(0))
            Dim H = Integer.Parse(Dimensions(1))
            Row.Cells(4).Value = (W * Scale) & "x" & (H * Scale)
        Next
    End Sub

    Private Sub Grid_DragEnter(sender As Object, e As DragEventArgs) Handles Grid.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Copy
    End Sub

    Dim AllowedExtensions As String() = New String() {"jpg", "jpeg", "png", "bmp"}
    Private Sub Grid_DragDrop(sender As Object, e As DragEventArgs) Handles Grid.DragDrop

        Dim gRows = (From row In Grid.Rows.Cast(Of DataGridViewRow).ToArray()
                     Select (row.Cells(1).Value.ToString())).ToArray()


        Dim H2 = Grid.RowTemplate.Height
        Dim ScaleCounts As String() = ScaleCount.Items.Cast(Of Object)().Select(Function(item) item.ToString()).ToArray()
        Dim Scale = If(ScaleCount.SelectedIndex > -1, ScaleCounts(ScaleCount.SelectedIndex), ScaleCounts.First())
        Dim Images = From img In DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
                     Where Not gRows.Contains(img) AndAlso AllowedExtensions.Contains(Path.GetExtension(img).ToLower().Replace(".", ""))
        For Each ImagePath In Images
            Using fs As New FileStream(ImagePath, FileMode.Open)
                Using img As Image = Image.FromStream(fs)
                    Dim W1 = img.Width
                    Dim H1 = img.Height
                    Dim W2 = (W1 / H1) * H2
                    Dim Thumbnail As Image = img.GetThumbnailImage(H2, W2, Nothing, IntPtr.Zero)
                    Grid.Rows.Add(New Object() {Thumbnail, ImagePath, Path.GetFileNameWithoutExtension(ImagePath), W1 & "x" & H1, (W1 * Scale) & "x" & (H1 * Scale)})
                End Using
            End Using
        Next
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ScaleCount.SelectedIndex = 0
    End Sub

    Dim Cyan As Color = Color.FromArgb(192, 255, 255)
    Dim Red As Color = Color.FromArgb(255, 192, 192)
    Dim ShouldStop As Boolean = False
    Dim UpScale As Integer = 2
    Dim OutputDir As String = String.Empty
    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        If Not Worker.IsBusy Then
            ShouldStop = False
            Start.Text = "Cancel"
            Start.BackColor = Red
            UpScale = Integer.Parse(ScaleCount.SelectedItem.ToString())
            OutputDir = If(OutputToDir.Checked, "Upscaled", String.Empty)
            Progress.Value = 0
            Worker.RunWorkerAsync()
        Else
            ShouldStop = True
            Start.Text = "Start"
            Start.BackColor = Cyan
        End If
    End Sub
    Dim Scaler As xBRZ.xBRZScaler = New xBRZ.xBRZScaler()

    Private Sub Worker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        Dim Rows As DataGridViewRow() = Nothing
        Grid.Invoke(Sub()
                        Rows = Grid.Rows.Cast(Of DataGridViewRow).ToArray()
                    End Sub)
        For R = 0 To Rows.Count - 1
            If ShouldStop Then Exit For
            Dim Row = Rows(R)
            Dim FilePath = Row.Cells(1).Value.ToString()
            Dim Dir = Path.GetDirectoryName(FilePath)
            Dim Name = Path.GetFileNameWithoutExtension(FilePath)
            Dim FileName = Name & "_" & UpScale & "X.jpeg"
            Dim Output = Path.Combine(Dir, FileName)
            If OutputDir IsNot String.Empty Then
                Directory.CreateDirectory(Path.Combine(Dir, OutputDir))
                Output = Path.Combine(Dir, OutputDir, FileName)
            End If
            Scaler.ScaleImage(FilePath, Output, UpScale, Nothing)

            Invoke(Sub()
                       Progress.Value = ((R + 1) / Rows.Count) * Progress.Maximum
                       Grid.Rows.Remove(Row)
                   End Sub)
        Next
        Start.Invoke(Sub()
                         Progress.Value = 0
                         Start.Text = "Start"
                         Start.BackColor = Cyan
                     End Sub)

    End Sub

    Private Sub EasingSoft_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles EasingSoft.LinkClicked
        Process.Start("https://github.com/EasingSoft/UltraScaler")
    End Sub
End Class
