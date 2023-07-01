<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.Preview = New System.Windows.Forms.DataGridViewImageColumn()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dimensions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Out_Dimensions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ScaleCount = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Start = New System.Windows.Forms.Button()
        Me.Progress = New System.Windows.Forms.ProgressBar()
        Me.Worker = New System.ComponentModel.BackgroundWorker()
        Me.OutputToDir = New System.Windows.Forms.CheckBox()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.AllowDrop = True
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Preview, Me.FilePath, Me.FileName, Me.Dimensions, Me.Out_Dimensions})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grid.EnableHeadersVisualStyles = False
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(18, 18)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Grid.Name = "Grid"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grid.RowHeadersVisible = False
        Me.Grid.RowTemplate.Height = 100
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(573, 373)
        Me.Grid.TabIndex = 0
        '
        'Preview
        '
        Me.Preview.HeaderText = "Preview"
        Me.Preview.Name = "Preview"
        Me.Preview.ReadOnly = True
        Me.Preview.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Preview.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'FilePath
        '
        Me.FilePath.HeaderText = "FilePath"
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        Me.FilePath.Visible = False
        '
        'FileName
        '
        Me.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FileName.HeaderText = "Name"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        '
        'Dimensions
        '
        Me.Dimensions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Dimensions.HeaderText = "Dimensions"
        Me.Dimensions.Name = "Dimensions"
        Me.Dimensions.ReadOnly = True
        Me.Dimensions.Width = 116
        '
        'Out_Dimensions
        '
        Me.Out_Dimensions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Out_Dimensions.HeaderText = "Expected"
        Me.Out_Dimensions.Name = "Out_Dimensions"
        Me.Out_Dimensions.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 422)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Scale:"
        '
        'ScaleCount
        '
        Me.ScaleCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ScaleCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ScaleCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ScaleCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScaleCount.ForeColor = System.Drawing.Color.White
        Me.ScaleCount.FormattingEnabled = True
        Me.ScaleCount.Items.AddRange(New Object() {"2", "3", "4", "5"})
        Me.ScaleCount.Location = New System.Drawing.Point(80, 419)
        Me.ScaleCount.Name = "ScaleCount"
        Me.ScaleCount.Size = New System.Drawing.Size(102, 28)
        Me.ScaleCount.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(189, 422)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "times"
        '
        'Start
        '
        Me.Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Start.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Start.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Start.Location = New System.Drawing.Point(477, 415)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(114, 35)
        Me.Start.TabIndex = 4
        Me.Start.Text = "Start"
        Me.Start.UseVisualStyleBackColor = False
        '
        'Progress
        '
        Me.Progress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Progress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Progress.Location = New System.Drawing.Point(18, 391)
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(573, 10)
        Me.Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Progress.TabIndex = 5
        '
        'Worker
        '
        '
        'OutputToDir
        '
        Me.OutputToDir.AutoSize = True
        Me.OutputToDir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OutputToDir.ForeColor = System.Drawing.Color.White
        Me.OutputToDir.Location = New System.Drawing.Point(274, 421)
        Me.OutputToDir.Name = "OutputToDir"
        Me.OutputToDir.Size = New System.Drawing.Size(143, 24)
        Me.OutputToDir.TabIndex = 6
        Me.OutputToDir.Text = "Create Directory"
        Me.OutputToDir.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(609, 459)
        Me.Controls.Add(Me.OutputToDir)
        Me.Controls.Add(Me.Progress)
        Me.Controls.Add(Me.Start)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ScaleCount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Grid)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ultra Scaler"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ScaleCount As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Start As Button
    Friend WithEvents Progress As ProgressBar
    Friend WithEvents Preview As DataGridViewImageColumn
    Friend WithEvents FilePath As DataGridViewTextBoxColumn
    Friend WithEvents FileName As DataGridViewTextBoxColumn
    Friend WithEvents Dimensions As DataGridViewTextBoxColumn
    Friend WithEvents Out_Dimensions As DataGridViewTextBoxColumn
    Friend WithEvents Worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents OutputToDir As CheckBox
End Class
