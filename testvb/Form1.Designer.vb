<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Window
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Window))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.file_make = New System.Windows.Forms.ToolStripButton()
        Me.file_open = New System.Windows.Forms.ToolStripButton()
        Me.file_save = New System.Windows.Forms.ToolStripButton()
        Me.file_close = New System.Windows.Forms.ToolStripButton()
        Me.clipcopy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.font_size = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.work_file_name = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.selection = New System.Windows.Forms.Panel()
        Me.line_rb = New System.Windows.Forms.RadioButton()
        Me.eraser_rb = New System.Windows.Forms.RadioButton()
        Me.pen_rb = New System.Windows.Forms.RadioButton()
        Me.connector_rb = New System.Windows.Forms.RadioButton()
        Me.loop_bottom_rb = New System.Windows.Forms.RadioButton()
        Me.loop_head_rb = New System.Windows.Forms.RadioButton()
        Me.ioput_rb = New System.Windows.Forms.RadioButton()
        Me.branch_rb = New System.Windows.Forms.RadioButton()
        Me.segmentation_rb = New System.Windows.Forms.RadioButton()
        Me.def_process_rb = New System.Windows.Forms.RadioButton()
        Me.start_finish_rb = New System.Windows.Forms.RadioButton()
        Me.normarl_process_rb = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.workspace = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        Me.selection.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.workspace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.file_make, Me.file_open, Me.file_save, Me.file_close, Me.clipcopy, Me.ToolStripSeparator1, Me.font_size, Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.work_file_name, Me.ToolStripLabel3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1064, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'file_make
        '
        Me.file_make.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.file_make.Image = CType(resources.GetObject("file_make.Image"), System.Drawing.Image)
        Me.file_make.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.file_make.Name = "file_make"
        Me.file_make.Size = New System.Drawing.Size(23, 22)
        Me.file_make.Text = "ToolStripButton3"
        Me.file_make.ToolTipText = "新規作成"
        '
        'file_open
        '
        Me.file_open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.file_open.Image = CType(resources.GetObject("file_open.Image"), System.Drawing.Image)
        Me.file_open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.file_open.Name = "file_open"
        Me.file_open.Size = New System.Drawing.Size(23, 22)
        Me.file_open.Text = "ToolStripButton4"
        Me.file_open.ToolTipText = "ファイルを開く"
        '
        'file_save
        '
        Me.file_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.file_save.Image = CType(resources.GetObject("file_save.Image"), System.Drawing.Image)
        Me.file_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.file_save.Name = "file_save"
        Me.file_save.Size = New System.Drawing.Size(23, 22)
        Me.file_save.Text = "ToolStripButton1"
        Me.file_save.ToolTipText = "保存"
        '
        'file_close
        '
        Me.file_close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.file_close.Image = CType(resources.GetObject("file_close.Image"), System.Drawing.Image)
        Me.file_close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.file_close.Name = "file_close"
        Me.file_close.Size = New System.Drawing.Size(23, 22)
        Me.file_close.Text = "ToolStripButton6"
        Me.file_close.ToolTipText = "閉じる"
        '
        'clipcopy
        '
        Me.clipcopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.clipcopy.Image = CType(resources.GetObject("clipcopy.Image"), System.Drawing.Image)
        Me.clipcopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.clipcopy.Name = "clipcopy"
        Me.clipcopy.Size = New System.Drawing.Size(23, 22)
        Me.clipcopy.Text = "ToolStripButton1"
        Me.clipcopy.ToolTipText = "クリップボードにコピー"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'font_size
        '
        Me.font_size.AutoSize = False
        Me.font_size.DropDownWidth = 50
        Me.font_size.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.font_size.Items.AddRange(New Object() {"8", "10", "12", "14"})
        Me.font_size.MaxLength = 2
        Me.font_size.Name = "font_size"
        Me.font_size.Size = New System.Drawing.Size(50, 23)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(20, 22)
        Me.ToolStripLabel1.Text = "px"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'work_file_name
        '
        Me.work_file_name.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.work_file_name.Name = "work_file_name"
        Me.work_file_name.Size = New System.Drawing.Size(95, 22)
        Me.work_file_name.Text = "新しいファイル.fccs"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel3.Text = "作業ファイル名:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'selection
        '
        Me.selection.AutoScroll = True
        Me.selection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.selection.Controls.Add(Me.line_rb)
        Me.selection.Controls.Add(Me.eraser_rb)
        Me.selection.Controls.Add(Me.pen_rb)
        Me.selection.Controls.Add(Me.connector_rb)
        Me.selection.Controls.Add(Me.loop_bottom_rb)
        Me.selection.Controls.Add(Me.loop_head_rb)
        Me.selection.Controls.Add(Me.ioput_rb)
        Me.selection.Controls.Add(Me.branch_rb)
        Me.selection.Controls.Add(Me.segmentation_rb)
        Me.selection.Controls.Add(Me.def_process_rb)
        Me.selection.Controls.Add(Me.start_finish_rb)
        Me.selection.Controls.Add(Me.normarl_process_rb)
        Me.selection.Location = New System.Drawing.Point(12, 37)
        Me.selection.Name = "selection"
        Me.selection.Size = New System.Drawing.Size(239, 407)
        Me.selection.TabIndex = 5
        '
        'line_rb
        '
        Me.line_rb.BackColor = System.Drawing.SystemColors.Control
        Me.line_rb.BackgroundImage = Global.testvb.My.Resources.Resources.line1
        Me.line_rb.Checked = True
        Me.line_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.line_rb.Location = New System.Drawing.Point(119, 277)
        Me.line_rb.Name = "line_rb"
        Me.line_rb.Size = New System.Drawing.Size(100, 50)
        Me.line_rb.TabIndex = 20
        Me.line_rb.TabStop = True
        Me.line_rb.UseVisualStyleBackColor = False
        '
        'eraser_rb
        '
        Me.eraser_rb.BackColor = System.Drawing.SystemColors.Control
        Me.eraser_rb.BackgroundImage = Global.testvb.My.Resources.Resources.kesigomu1
        Me.eraser_rb.Checked = True
        Me.eraser_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.eraser_rb.Location = New System.Drawing.Point(119, 345)
        Me.eraser_rb.Name = "eraser_rb"
        Me.eraser_rb.Size = New System.Drawing.Size(100, 50)
        Me.eraser_rb.TabIndex = 19
        Me.eraser_rb.TabStop = True
        Me.eraser_rb.UseVisualStyleBackColor = False
        '
        'pen_rb
        '
        Me.pen_rb.BackColor = System.Drawing.SystemColors.Control
        Me.pen_rb.BackgroundImage = Global.testvb.My.Resources.Resources.pen
        Me.pen_rb.Checked = True
        Me.pen_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.pen_rb.Location = New System.Drawing.Point(3, 345)
        Me.pen_rb.Name = "pen_rb"
        Me.pen_rb.Size = New System.Drawing.Size(100, 50)
        Me.pen_rb.TabIndex = 18
        Me.pen_rb.TabStop = True
        Me.pen_rb.UseVisualStyleBackColor = False
        '
        'connector_rb
        '
        Me.connector_rb.BackColor = System.Drawing.SystemColors.Control
        Me.connector_rb.BackgroundImage = Global.testvb.My.Resources.Resources.ketugou1
        Me.connector_rb.Checked = True
        Me.connector_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.connector_rb.Location = New System.Drawing.Point(3, 277)
        Me.connector_rb.Name = "connector_rb"
        Me.connector_rb.Size = New System.Drawing.Size(100, 50)
        Me.connector_rb.TabIndex = 10
        Me.connector_rb.TabStop = True
        Me.connector_rb.UseVisualStyleBackColor = False
        '
        'loop_bottom_rb
        '
        Me.loop_bottom_rb.BackColor = System.Drawing.SystemColors.Control
        Me.loop_bottom_rb.BackgroundImage = Global.testvb.My.Resources.Resources.bottom1
        Me.loop_bottom_rb.Checked = True
        Me.loop_bottom_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.loop_bottom_rb.Location = New System.Drawing.Point(119, 209)
        Me.loop_bottom_rb.Name = "loop_bottom_rb"
        Me.loop_bottom_rb.Size = New System.Drawing.Size(100, 50)
        Me.loop_bottom_rb.TabIndex = 9
        Me.loop_bottom_rb.TabStop = True
        Me.loop_bottom_rb.UseVisualStyleBackColor = False
        '
        'loop_head_rb
        '
        Me.loop_head_rb.BackColor = System.Drawing.SystemColors.Control
        Me.loop_head_rb.BackgroundImage = Global.testvb.My.Resources.Resources.head1
        Me.loop_head_rb.Checked = True
        Me.loop_head_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.loop_head_rb.Location = New System.Drawing.Point(3, 209)
        Me.loop_head_rb.Name = "loop_head_rb"
        Me.loop_head_rb.Size = New System.Drawing.Size(100, 50)
        Me.loop_head_rb.TabIndex = 8
        Me.loop_head_rb.TabStop = True
        Me.loop_head_rb.UseVisualStyleBackColor = False
        '
        'ioput_rb
        '
        Me.ioput_rb.BackColor = System.Drawing.SystemColors.Control
        Me.ioput_rb.BackgroundImage = Global.testvb.My.Resources.Resources.inout1
        Me.ioput_rb.Checked = True
        Me.ioput_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.ioput_rb.Location = New System.Drawing.Point(119, 139)
        Me.ioput_rb.Name = "ioput_rb"
        Me.ioput_rb.Size = New System.Drawing.Size(100, 50)
        Me.ioput_rb.TabIndex = 7
        Me.ioput_rb.TabStop = True
        Me.ioput_rb.UseVisualStyleBackColor = False
        '
        'branch_rb
        '
        Me.branch_rb.BackColor = System.Drawing.SystemColors.Control
        Me.branch_rb.BackgroundImage = Global.testvb.My.Resources.Resources.handan1
        Me.branch_rb.Checked = True
        Me.branch_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.branch_rb.Location = New System.Drawing.Point(3, 139)
        Me.branch_rb.Name = "branch_rb"
        Me.branch_rb.Size = New System.Drawing.Size(100, 50)
        Me.branch_rb.TabIndex = 6
        Me.branch_rb.TabStop = True
        Me.branch_rb.UseVisualStyleBackColor = False
        '
        'segmentation_rb
        '
        Me.segmentation_rb.BackColor = System.Drawing.SystemColors.Control
        Me.segmentation_rb.BackgroundImage = Global.testvb.My.Resources.Resources.seg1
        Me.segmentation_rb.Checked = True
        Me.segmentation_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.segmentation_rb.Location = New System.Drawing.Point(119, 71)
        Me.segmentation_rb.Name = "segmentation_rb"
        Me.segmentation_rb.Size = New System.Drawing.Size(100, 50)
        Me.segmentation_rb.TabIndex = 5
        Me.segmentation_rb.TabStop = True
        Me.segmentation_rb.UseVisualStyleBackColor = False
        '
        'def_process_rb
        '
        Me.def_process_rb.BackColor = System.Drawing.SystemColors.Control
        Me.def_process_rb.BackgroundImage = Global.testvb.My.Resources.Resources.tesyori1
        Me.def_process_rb.Checked = True
        Me.def_process_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.def_process_rb.Location = New System.Drawing.Point(3, 71)
        Me.def_process_rb.Name = "def_process_rb"
        Me.def_process_rb.Size = New System.Drawing.Size(100, 50)
        Me.def_process_rb.TabIndex = 4
        Me.def_process_rb.TabStop = True
        Me.def_process_rb.UseVisualStyleBackColor = False
        '
        'start_finish_rb
        '
        Me.start_finish_rb.AccessibleName = ""
        Me.start_finish_rb.BackColor = System.Drawing.SystemColors.Control
        Me.start_finish_rb.BackgroundImage = Global.testvb.My.Resources.Resources.stafin2
        Me.start_finish_rb.Checked = True
        Me.start_finish_rb.Cursor = System.Windows.Forms.Cursors.Default
        Me.start_finish_rb.Location = New System.Drawing.Point(3, 3)
        Me.start_finish_rb.Name = "start_finish_rb"
        Me.start_finish_rb.Size = New System.Drawing.Size(100, 50)
        Me.start_finish_rb.TabIndex = 2
        Me.start_finish_rb.TabStop = True
        Me.start_finish_rb.UseVisualStyleBackColor = False
        '
        'normarl_process_rb
        '
        Me.normarl_process_rb.BackgroundImage = Global.testvb.My.Resources.Resources.syori1
        Me.normarl_process_rb.Location = New System.Drawing.Point(119, 3)
        Me.normarl_process_rb.Name = "normarl_process_rb"
        Me.normarl_process_rb.Size = New System.Drawing.Size(100, 50)
        Me.normarl_process_rb.TabIndex = 3
        Me.normarl_process_rb.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.workspace)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(272, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(780, 625)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'workspace
        '
        Me.workspace.BackColor = System.Drawing.Color.White
        Me.workspace.Location = New System.Drawing.Point(2, 8)
        Me.workspace.Name = "workspace"
        Me.workspace.Size = New System.Drawing.Size(776, 614)
        Me.workspace.TabIndex = 0
        Me.workspace.TabStop = False
        '
        'Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1064, 681)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.selection)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Window"
        Me.Text = "フローチャート作成ソフト　v 0.3.1"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.selection.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.workspace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents file_save As ToolStripButton
    Friend WithEvents file_make As ToolStripButton
    Friend WithEvents file_open As ToolStripButton
    Friend WithEvents file_close As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents normarl_process_rb As RadioButton
    Friend WithEvents start_finish_rb As RadioButton
    Friend WithEvents selection As Panel
    Friend WithEvents clipcopy As ToolStripButton
    Friend WithEvents work_file_name As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents connector_rb As RadioButton
    Friend WithEvents loop_bottom_rb As RadioButton
    Friend WithEvents loop_head_rb As RadioButton
    Friend WithEvents ioput_rb As RadioButton
    Friend WithEvents branch_rb As RadioButton
    Friend WithEvents segmentation_rb As RadioButton
    Friend WithEvents def_process_rb As RadioButton
    Friend WithEvents eraser_rb As RadioButton
    Friend WithEvents pen_rb As RadioButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents font_size As ToolStripComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents workspace As PictureBox
    Friend WithEvents line_rb As RadioButton
End Class
