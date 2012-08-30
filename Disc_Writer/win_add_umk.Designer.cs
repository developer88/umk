namespace DiskCreator
{
    partial class win_add_umk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(win_add_umk));
            this.lst_files = new System.Windows.Forms.ListBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_files
            // 
            this.lst_files.FormattingEnabled = true;
            this.lst_files.Location = new System.Drawing.Point(12, 41);
            this.lst_files.Name = "lst_files";
            this.lst_files.Size = new System.Drawing.Size(420, 173);
            this.lst_files.TabIndex = 0;
            this.lst_files.SelectedIndexChanged += new System.EventHandler(this.lst_files_SelectedIndexChanged);
            this.lst_files.DoubleClick += new System.EventHandler(this.lst_files_DoubleClick);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(12, 12);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(72, 22);
            this.btn_back.TabIndex = 1;
            this.btn_back.Text = "Назад";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(90, 17);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(0, 13);
            this.lbl_name.TabIndex = 2;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(339, 227);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(93, 26);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(12, 227);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(93, 26);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Закрыть окно";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // win_add_umk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 265);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.lst_files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "win_add_umk";
            this.Text = "Добавить файлы из УМК";
            this.Load += new System.EventHandler(this.win_add_umk_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_files;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_exit;
    }
}