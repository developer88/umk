<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_hlp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_hlp))
        Me.wb_hlp = New System.Windows.Forms.WebBrowser
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.PictureBox16 = New System.Windows.Forms.PictureBox
        Me.pb_back = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_back, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wb_hlp
        '
        Me.wb_hlp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wb_hlp.Location = New System.Drawing.Point(0, 45)
        Me.wb_hlp.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wb_hlp.Name = "wb_hlp"
        Me.wb_hlp.Size = New System.Drawing.Size(609, 410)
        Me.wb_hlp.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 463)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Label4"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(565, 20)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Text = "Поиск..."
        '
        'PictureBox16
        '
        Me.PictureBox16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox16.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(583, 12)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox16.TabIndex = 25
        Me.PictureBox16.TabStop = False
        '
        'pb_back
        '
        Me.pb_back.Location = New System.Drawing.Point(0, 1)
        Me.pb_back.Name = "pb_back"
        Me.pb_back.Size = New System.Drawing.Size(719, 52)
        Me.pb_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_back.TabIndex = 26
        Me.pb_back.TabStop = False
        '
        'frm_hlp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(609, 484)
        Me.Controls.Add(Me.PictureBox16)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.wb_hlp)
        Me.Controls.Add(Me.pb_back)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 520)
        Me.Name = "frm_hlp"
        Me.ShowInTaskbar = False
        Me.Text = "Помощь"
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_back, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wb_hlp As System.Windows.Forms.WebBrowser
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_back As System.Windows.Forms.PictureBox
End Class
