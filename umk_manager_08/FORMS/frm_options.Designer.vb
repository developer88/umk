<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_options
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_options))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.tc1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CheckBox6 = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.chk_tray = New System.Windows.Forms.CheckBox
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label18 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chk_stat_umk = New System.Windows.Forms.CheckBox
        Me.chk_stat_caf = New System.Windows.Forms.CheckBox
        Me.chk_stat_unit = New System.Windows.Forms.CheckBox
        Me.lbl_stat = New System.Windows.Forms.Label
        Me.lst_stat = New System.Windows.Forms.ListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.openfile = New System.Windows.Forms.OpenFileDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.select_dir = New System.Windows.Forms.FolderBrowserDialog
        Me.pb_back = New System.Windows.Forms.PictureBox
        Me.tc1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_back, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Настройки"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(292, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Здесь вы можете изменить все настройки прграммы."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(393, 429)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 22)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Выход"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'tc1
        '
        Me.tc1.Controls.Add(Me.TabPage1)
        Me.tc1.Controls.Add(Me.TabPage2)
        Me.tc1.Controls.Add(Me.TabPage3)
        Me.tc1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tc1.Location = New System.Drawing.Point(12, 59)
        Me.tc1.Name = "tc1"
        Me.tc1.SelectedIndex = 0
        Me.tc1.Size = New System.Drawing.Size(519, 350)
        Me.tc1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckBox6)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.CheckBox4)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.TextBox5)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.chk_tray)
        Me.TabPage1.Controls.Add(Me.CheckBox5)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.PictureBox6)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(511, 323)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Основные"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CheckBox6.ForeColor = System.Drawing.Color.Black
        Me.CheckBox6.Location = New System.Drawing.Point(9, 117)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(253, 18)
        Me.CheckBox6.TabIndex = 34
        Me.CheckBox6.Text = "Удалять пустые файлы и папки при запуске"
        Me.ToolTip1.SetToolTip(Me.CheckBox6, "Если включено, то будет производиться проверка и удаление пустых файлов и папок в" & _
                " директории с УМК")
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 14)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Визуальные настройки:"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CheckBox4.ForeColor = System.Drawing.Color.Black
        Me.CheckBox4.Location = New System.Drawing.Point(9, 157)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(228, 18)
        Me.CheckBox4.TabIndex = 32
        Me.CheckBox4.Text = "Показывать информационную панель" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(6, 59)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 14)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "Разное:"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(329, 23)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(36, 27)
        Me.Button6.TabIndex = 30
        Me.Button6.Text = "..."
        Me.ToolTip1.SetToolTip(Me.Button6, "Нажмите, чтобы указать путь.")
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(6, 26)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(317, 22)
        Me.TextBox5.TabIndex = 29
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(6, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(118, 14)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "Путь до папки с УМК:"
        '
        'chk_tray
        '
        Me.chk_tray.AutoSize = True
        Me.chk_tray.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chk_tray.ForeColor = System.Drawing.Color.Black
        Me.chk_tray.Location = New System.Drawing.Point(9, 96)
        Me.chk_tray.Name = "chk_tray"
        Me.chk_tray.Size = New System.Drawing.Size(132, 18)
        Me.chk_tray.TabIndex = 25
        Me.chk_tray.Text = "Сворачивать в трей"
        Me.chk_tray.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CheckBox5.ForeColor = System.Drawing.Color.Black
        Me.CheckBox5.Location = New System.Drawing.Point(9, 75)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(258, 18)
        Me.CheckBox5.TabIndex = 24
        Me.CheckBox5.Text = "Загружать программу при старте Windows" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(76, 254)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(324, 64)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Рекомендуется не указывать слишком длинный путь до директории с УМК."
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(8, 253)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 21
        Me.PictureBox6.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(333, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 72)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Основные настройки. Здесь вы можете изменить основные параметры приложения: внешн" & _
            "ий вид, поведение и т.д."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(377, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.CheckBox3)
        Me.TabPage2.Controls.Add(Me.CheckBox2)
        Me.TabPage2.Controls.Add(Me.CheckBox1)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.PictureBox5)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(511, 323)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Поиск"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(13, 108)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Искать:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadioButton4)
        Me.Panel2.Controls.Add(Me.RadioButton3)
        Me.Panel2.Location = New System.Drawing.Point(8, 107)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(221, 64)
        Me.Panel2.TabIndex = 29
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioButton4.ForeColor = System.Drawing.Color.Black
        Me.RadioButton4.Location = New System.Drawing.Point(11, 35)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(157, 18)
        Me.RadioButton4.TabIndex = 2
        Me.RadioButton4.Text = "все слова по отдельности"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioButton3.ForeColor = System.Drawing.Color.Black
        Me.RadioButton3.Location = New System.Drawing.Point(11, 14)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(106, 18)
        Me.RadioButton3.TabIndex = 1
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "фразу целиком"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CheckBox3.ForeColor = System.Drawing.Color.Black
        Me.CheckBox3.Location = New System.Drawing.Point(8, 81)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(114, 19)
        Me.CheckBox3.TabIndex = 28
        Me.CheckBox3.Text = "тексте в файлах"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.Black
        Me.CheckBox2.Location = New System.Drawing.Point(8, 58)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(137, 19)
        Me.CheckBox2.TabIndex = 27
        Me.CheckBox2.Text = "именах директорий"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(8, 35)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(113, 19)
        Me.CheckBox1.TabIndex = 26
        Me.CheckBox1.Text = "именах файлов"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(328, 137)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(177, 95)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "Поиск. Здесь можно настроить основные параметры поиска по файлам директории с УМК" & _
            "." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(13, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 14)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Искать в:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(171, 282)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(337, 39)
        Me.Panel1.TabIndex = 23
        Me.Panel1.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.White
        Me.RadioButton2.Location = New System.Drawing.Point(157, 11)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(160, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Индексируемый поиск"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(13, 11)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(114, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Простой поиск"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(78, 253)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(300, 64)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Поиск текста в файлах может быть продолжительном при больших размерах директории " & _
            "с УМК." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(8, 253)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 21
        Me.PictureBox5.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(377, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.PictureBox7)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.chk_stat_umk)
        Me.TabPage3.Controls.Add(Me.chk_stat_caf)
        Me.TabPage3.Controls.Add(Me.chk_stat_unit)
        Me.TabPage3.Controls.Add(Me.lbl_stat)
        Me.TabPage3.Controls.Add(Me.lst_stat)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.PictureBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(511, 323)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Статистика"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(8, 253)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 37
        Me.PictureBox7.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(235, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 14)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Стиль доступен для:"
        '
        'chk_stat_umk
        '
        Me.chk_stat_umk.AutoSize = True
        Me.chk_stat_umk.Enabled = False
        Me.chk_stat_umk.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chk_stat_umk.ForeColor = System.Drawing.Color.Black
        Me.chk_stat_umk.Location = New System.Drawing.Point(240, 89)
        Me.chk_stat_umk.Name = "chk_stat_umk"
        Me.chk_stat_umk.Size = New System.Drawing.Size(51, 19)
        Me.chk_stat_umk.TabIndex = 35
        Me.chk_stat_umk.Text = "УМК"
        Me.chk_stat_umk.UseVisualStyleBackColor = True
        '
        'chk_stat_caf
        '
        Me.chk_stat_caf.AutoSize = True
        Me.chk_stat_caf.Enabled = False
        Me.chk_stat_caf.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chk_stat_caf.ForeColor = System.Drawing.Color.Black
        Me.chk_stat_caf.Location = New System.Drawing.Point(240, 65)
        Me.chk_stat_caf.Name = "chk_stat_caf"
        Me.chk_stat_caf.Size = New System.Drawing.Size(77, 19)
        Me.chk_stat_caf.TabIndex = 34
        Me.chk_stat_caf.Text = "Кафедры"
        Me.chk_stat_caf.UseVisualStyleBackColor = True
        '
        'chk_stat_unit
        '
        Me.chk_stat_unit.AutoSize = True
        Me.chk_stat_unit.Enabled = False
        Me.chk_stat_unit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chk_stat_unit.ForeColor = System.Drawing.Color.Black
        Me.chk_stat_unit.Location = New System.Drawing.Point(240, 43)
        Me.chk_stat_unit.Name = "chk_stat_unit"
        Me.chk_stat_unit.Size = New System.Drawing.Size(114, 19)
        Me.chk_stat_unit.TabIndex = 33
        Me.chk_stat_unit.Text = "Подразделения"
        Me.chk_stat_unit.UseVisualStyleBackColor = True
        '
        'lbl_stat
        '
        Me.lbl_stat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_stat.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_stat.ForeColor = System.Drawing.Color.Black
        Me.lbl_stat.Location = New System.Drawing.Point(5, 159)
        Me.lbl_stat.Name = "lbl_stat"
        Me.lbl_stat.Size = New System.Drawing.Size(317, 82)
        Me.lbl_stat.TabIndex = 32
        '
        'lst_stat
        '
        Me.lst_stat.BackColor = System.Drawing.Color.White
        Me.lst_stat.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lst_stat.ForeColor = System.Drawing.Color.Black
        Me.lst_stat.FormattingEnabled = True
        Me.lst_stat.ItemHeight = 15
        Me.lst_stat.Location = New System.Drawing.Point(8, 22)
        Me.lst_stat.Name = "lst_stat"
        Me.lst_stat.Size = New System.Drawing.Size(222, 124)
        Me.lst_stat.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(5, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 14)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Выберите стиль:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(328, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 95)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Статистика. Здесь можно выбрать стиль, который будет использоваться для показа ст" & _
            "атистики." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(78, 254)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(357, 64)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Разные стили могут содержать не все схемы для УМК, подразделений и кафедр." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(377, 6)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 26
        Me.PictureBox4.TabStop = False
        '
        'openfile
        '
        Me.openfile.FileName = "OpenFileDialog1"
        '
        'pb_back
        '
        Me.pb_back.Location = New System.Drawing.Point(12, 81)
        Me.pb_back.Name = "pb_back"
        Me.pb_back.Size = New System.Drawing.Size(519, 332)
        Me.pb_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_back.TabIndex = 18
        Me.pb_back.TabStop = False
        '
        'frm_options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(542, 423)
        Me.Controls.Add(Me.tc1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pb_back)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_options"
        Me.ShowInTaskbar = False
        Me.Text = "Настройки программы"
        Me.tc1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_back, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tc1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents openfile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_tray As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents select_dir As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_stat As System.Windows.Forms.Label
    Friend WithEvents lst_stat As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chk_stat_umk As System.Windows.Forms.CheckBox
    Friend WithEvents chk_stat_caf As System.Windows.Forms.CheckBox
    Friend WithEvents chk_stat_unit As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pb_back As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
End Class
