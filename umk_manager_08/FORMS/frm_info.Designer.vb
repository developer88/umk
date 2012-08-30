<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_info
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_info))
        Me.txt_name = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt1 = New System.Windows.Forms.TextBox
        Me.lbl1 = New System.Windows.Forms.Label
        Me.txt2 = New System.Windows.Forms.TextBox
        Me.lbl2 = New System.Windows.Forms.Label
        Me.txt3 = New System.Windows.Forms.TextBox
        Me.lbl3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lst_type = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt4 = New System.Windows.Forms.TextBox
        Me.lbl4 = New System.Windows.Forms.Label
        Me.chk_info1 = New System.Windows.Forms.CheckBox
        Me.chk_info2 = New System.Windows.Forms.CheckBox
        Me.chk_info3 = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.chk_info4 = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lbl_type = New System.Windows.Forms.Label
        Me.txt_date = New System.Windows.Forms.Label
        Me.txt_editdate = New System.Windows.Forms.Label
        Me.txt_size = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pic_update = New System.Windows.Forms.PictureBox
        Me.btn_close = New System.Windows.Forms.Button
        Me.btn_ok = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt5 = New System.Windows.Forms.TextBox
        Me.lbl5 = New System.Windows.Forms.Label
        Me.txt6 = New System.Windows.Forms.TextBox
        Me.lbl6 = New System.Windows.Forms.Label
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox15 = New System.Windows.Forms.PictureBox
        Me.pb_back = New System.Windows.Forms.PictureBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        CType(Me.pic_update, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_back, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_name
        '
        Me.txt_name.BackColor = System.Drawing.Color.White
        Me.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_name.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_name.ForeColor = System.Drawing.Color.Black
        Me.txt_name.Location = New System.Drawing.Point(47, 12)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(268, 19)
        Me.txt_name.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 18)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Тип:"
        Me.Label2.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(215, 439)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Изменить"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(215, 461)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Удалить"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(215, 450)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 16)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label6.Visible = False
        '
        'txt1
        '
        Me.txt1.BackColor = System.Drawing.Color.White
        Me.txt1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt1.ForeColor = System.Drawing.Color.Black
        Me.txt1.Location = New System.Drawing.Point(152, 64)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(163, 13)
        Me.txt1.TabIndex = 36
        Me.txt1.Visible = False
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.White
        Me.lbl1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.Black
        Me.lbl1.Location = New System.Drawing.Point(13, 62)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(133, 16)
        Me.lbl1.TabIndex = 35
        Me.lbl1.Text = "Название:"
        Me.lbl1.Visible = False
        '
        'txt2
        '
        Me.txt2.BackColor = System.Drawing.Color.White
        Me.txt2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt2.ForeColor = System.Drawing.Color.Black
        Me.txt2.Location = New System.Drawing.Point(152, 89)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(163, 13)
        Me.txt2.TabIndex = 38
        Me.txt2.Visible = False
        '
        'lbl2
        '
        Me.lbl2.BackColor = System.Drawing.Color.Transparent
        Me.lbl2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl2.ForeColor = System.Drawing.Color.Black
        Me.lbl2.Location = New System.Drawing.Point(13, 87)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(133, 16)
        Me.lbl2.TabIndex = 37
        Me.lbl2.Text = "Название:"
        Me.lbl2.Visible = False
        '
        'txt3
        '
        Me.txt3.BackColor = System.Drawing.Color.White
        Me.txt3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt3.ForeColor = System.Drawing.Color.Black
        Me.txt3.Location = New System.Drawing.Point(152, 117)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(163, 13)
        Me.txt3.TabIndex = 40
        Me.txt3.Visible = False
        '
        'lbl3
        '
        Me.lbl3.BackColor = System.Drawing.Color.White
        Me.lbl3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl3.ForeColor = System.Drawing.Color.Black
        Me.lbl3.Location = New System.Drawing.Point(13, 115)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(133, 16)
        Me.lbl3.TabIndex = 39
        Me.lbl3.Text = "Название:"
        Me.lbl3.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(79, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 15)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Дата создания:"
        '
        'lst_type
        '
        Me.lst_type.ForeColor = System.Drawing.Color.Black
        Me.lst_type.FormattingEnabled = True
        Me.lst_type.Location = New System.Drawing.Point(59, 37)
        Me.lst_type.Name = "lst_type"
        Me.lst_type.Size = New System.Drawing.Size(256, 21)
        Me.lst_type.TabIndex = 43
        Me.lst_type.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(79, 275)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 15)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Дата изменения:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(567, 509)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(357, 64)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Здесь вы можете посмотреть или изменить необходимые параметры выбранного элемента" & _
            " (подразделение, кафедра, УМК, файл)"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(81, 606)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(456, 14)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "_________________________________"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(79, 291)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 15)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Размер:"
        '
        'txt4
        '
        Me.txt4.BackColor = System.Drawing.Color.White
        Me.txt4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt4.ForeColor = System.Drawing.Color.Black
        Me.txt4.Location = New System.Drawing.Point(152, 146)
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(163, 13)
        Me.txt4.TabIndex = 53
        Me.txt4.Visible = False
        '
        'lbl4
        '
        Me.lbl4.BackColor = System.Drawing.Color.White
        Me.lbl4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl4.ForeColor = System.Drawing.Color.Black
        Me.lbl4.Location = New System.Drawing.Point(13, 144)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(133, 16)
        Me.lbl4.TabIndex = 52
        Me.lbl4.Text = "Название:"
        Me.lbl4.Visible = False
        '
        'chk_info1
        '
        Me.chk_info1.BackColor = System.Drawing.Color.White
        Me.chk_info1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chk_info1.ForeColor = System.Drawing.Color.Black
        Me.chk_info1.Location = New System.Drawing.Point(326, 93)
        Me.chk_info1.Name = "chk_info1"
        Me.chk_info1.Size = New System.Drawing.Size(196, 20)
        Me.chk_info1.TabIndex = 54
        Me.chk_info1.Text = "chk_info1"
        Me.chk_info1.UseVisualStyleBackColor = False
        Me.chk_info1.Visible = False
        '
        'chk_info2
        '
        Me.chk_info2.BackColor = System.Drawing.Color.White
        Me.chk_info2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chk_info2.ForeColor = System.Drawing.Color.Black
        Me.chk_info2.Location = New System.Drawing.Point(326, 27)
        Me.chk_info2.Name = "chk_info2"
        Me.chk_info2.Size = New System.Drawing.Size(196, 20)
        Me.chk_info2.TabIndex = 55
        Me.chk_info2.Text = "chk_info2"
        Me.chk_info2.UseVisualStyleBackColor = False
        Me.chk_info2.Visible = False
        '
        'chk_info3
        '
        Me.chk_info3.BackColor = System.Drawing.Color.White
        Me.chk_info3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chk_info3.ForeColor = System.Drawing.Color.Black
        Me.chk_info3.Location = New System.Drawing.Point(326, 48)
        Me.chk_info3.Name = "chk_info3"
        Me.chk_info3.Size = New System.Drawing.Size(196, 20)
        Me.chk_info3.TabIndex = 56
        Me.chk_info3.Text = "chk_info3"
        Me.chk_info3.UseVisualStyleBackColor = False
        Me.chk_info3.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 218)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(470, 15)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "_________________________________"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk_info4
        '
        Me.chk_info4.BackColor = System.Drawing.Color.White
        Me.chk_info4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chk_info4.ForeColor = System.Drawing.Color.Black
        Me.chk_info4.Location = New System.Drawing.Point(326, 70)
        Me.chk_info4.Name = "chk_info4"
        Me.chk_info4.Size = New System.Drawing.Size(196, 20)
        Me.chk_info4.TabIndex = 58
        Me.chk_info4.Text = "chk_info4"
        Me.chk_info4.UseVisualStyleBackColor = False
        Me.chk_info4.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(326, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 16)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Дополнительно:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(79, 242)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 15)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Тип:"
        '
        'lbl_type
        '
        Me.lbl_type.AutoSize = True
        Me.lbl_type.BackColor = System.Drawing.Color.Transparent
        Me.lbl_type.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_type.ForeColor = System.Drawing.Color.Black
        Me.lbl_type.Location = New System.Drawing.Point(113, 242)
        Me.lbl_type.Name = "lbl_type"
        Me.lbl_type.Size = New System.Drawing.Size(50, 15)
        Me.lbl_type.TabIndex = 63
        Me.lbl_type.Text = "Label13"
        '
        'txt_date
        '
        Me.txt_date.AutoSize = True
        Me.txt_date.BackColor = System.Drawing.Color.Transparent
        Me.txt_date.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_date.ForeColor = System.Drawing.Color.Black
        Me.txt_date.Location = New System.Drawing.Point(183, 257)
        Me.txt_date.Name = "txt_date"
        Me.txt_date.Size = New System.Drawing.Size(50, 15)
        Me.txt_date.TabIndex = 64
        Me.txt_date.Text = "Label13"
        '
        'txt_editdate
        '
        Me.txt_editdate.AutoSize = True
        Me.txt_editdate.BackColor = System.Drawing.Color.Transparent
        Me.txt_editdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_editdate.ForeColor = System.Drawing.Color.Black
        Me.txt_editdate.Location = New System.Drawing.Point(191, 275)
        Me.txt_editdate.Name = "txt_editdate"
        Me.txt_editdate.Size = New System.Drawing.Size(50, 15)
        Me.txt_editdate.TabIndex = 65
        Me.txt_editdate.Text = "Label13"
        '
        'txt_size
        '
        Me.txt_size.AutoSize = True
        Me.txt_size.BackColor = System.Drawing.Color.Transparent
        Me.txt_size.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_size.ForeColor = System.Drawing.Color.Black
        Me.txt_size.Location = New System.Drawing.Point(139, 291)
        Me.txt_size.Name = "txt_size"
        Me.txt_size.Size = New System.Drawing.Size(50, 15)
        Me.txt_size.TabIndex = 66
        Me.txt_size.Text = "Label13"
        '
        'pic_update
        '
        Me.pic_update.Image = Global.umk_manager_08.My.Resources.Resources.update_n
        Me.pic_update.Location = New System.Drawing.Point(9, 4)
        Me.pic_update.Name = "pic_update"
        Me.pic_update.Size = New System.Drawing.Size(32, 32)
        Me.pic_update.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_update.TabIndex = 78
        Me.pic_update.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pic_update, "Указать на обновлённые файлы\папки")
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(380, 301)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(96, 28)
        Me.btn_close.TabIndex = 71
        Me.btn_close.Text = "Закрыть"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_ok
        '
        Me.btn_ok.Location = New System.Drawing.Point(278, 301)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(96, 28)
        Me.btn_ok.TabIndex = 72
        Me.btn_ok.Text = "Сохранить"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(71, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 14)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "_________________________________"
        Me.Label1.Visible = False
        '
        'txt5
        '
        Me.txt5.BackColor = System.Drawing.Color.White
        Me.txt5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt5.ForeColor = System.Drawing.Color.Black
        Me.txt5.Location = New System.Drawing.Point(152, 172)
        Me.txt5.Name = "txt5"
        Me.txt5.Size = New System.Drawing.Size(295, 13)
        Me.txt5.TabIndex = 75
        Me.txt5.Visible = False
        '
        'lbl5
        '
        Me.lbl5.BackColor = System.Drawing.Color.White
        Me.lbl5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl5.ForeColor = System.Drawing.Color.Black
        Me.lbl5.Location = New System.Drawing.Point(13, 170)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(133, 16)
        Me.lbl5.TabIndex = 74
        Me.lbl5.Text = "Название:"
        Me.lbl5.Visible = False
        '
        'txt6
        '
        Me.txt6.BackColor = System.Drawing.Color.White
        Me.txt6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt6.ForeColor = System.Drawing.Color.Black
        Me.txt6.Location = New System.Drawing.Point(152, 198)
        Me.txt6.Name = "txt6"
        Me.txt6.Size = New System.Drawing.Size(295, 13)
        Me.txt6.TabIndex = 77
        Me.txt6.Visible = False
        '
        'lbl6
        '
        Me.lbl6.BackColor = System.Drawing.Color.White
        Me.lbl6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl6.ForeColor = System.Drawing.Color.Black
        Me.lbl6.Location = New System.Drawing.Point(13, 196)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(133, 16)
        Me.lbl6.TabIndex = 76
        Me.lbl6.Text = "Название:"
        Me.lbl6.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(9, 242)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 46
        Me.PictureBox6.TabStop = False
        '
        'PictureBox15
        '
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(582, 387)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(90, 90)
        Me.PictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox15.TabIndex = 24
        Me.PictureBox15.TabStop = False
        '
        'pb_back
        '
        Me.pb_back.Location = New System.Drawing.Point(207, 129)
        Me.pb_back.Name = "pb_back"
        Me.pb_back.Size = New System.Drawing.Size(65, 38)
        Me.pb_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_back.TabIndex = 62
        Me.pb_back.TabStop = False
        Me.pb_back.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frm_info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(485, 341)
        Me.Controls.Add(Me.pic_update)
        Me.Controls.Add(Me.txt6)
        Me.Controls.Add(Me.lbl6)
        Me.Controls.Add(Me.txt5)
        Me.Controls.Add(Me.lbl5)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.txt_size)
        Me.Controls.Add(Me.txt_editdate)
        Me.Controls.Add(Me.txt_date)
        Me.Controls.Add(Me.lbl_type)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt4)
        Me.Controls.Add(Me.lbl4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lst_type)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt3)
        Me.Controls.Add(Me.lbl3)
        Me.Controls.Add(Me.txt2)
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.txt1)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox15)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chk_info4)
        Me.Controls.Add(Me.chk_info3)
        Me.Controls.Add(Me.chk_info2)
        Me.Controls.Add(Me.chk_info1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pb_back)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_info"
        Me.ShowInTaskbar = False
        Me.Text = "Информация"
        CType(Me.pic_update, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_back, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_name As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lst_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents chk_info1 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_info2 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_info3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chk_info4 As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pb_back As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_type As System.Windows.Forms.Label
    Friend WithEvents txt_date As System.Windows.Forms.Label
    Friend WithEvents txt_editdate As System.Windows.Forms.Label
    Friend WithEvents txt_size As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt5 As System.Windows.Forms.TextBox
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents txt6 As System.Windows.Forms.TextBox
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents pic_update As System.Windows.Forms.PictureBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
