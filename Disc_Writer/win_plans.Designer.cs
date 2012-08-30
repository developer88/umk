namespace DiskCreator
{
    partial class win_plans
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(win_plans));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_close_window = new System.Windows.Forms.Button();
            this.gb_list = new System.Windows.Forms.GroupBox();
            this.btn_open_plan = new System.Windows.Forms.Button();
            this.btn_create_plan = new System.Windows.Forms.Button();
            this.btn_delete_plan = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lst_plans = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.combo_level = new System.Windows.Forms.ComboBox();
            this.gb_plan_edit = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.remove_umk = new System.Windows.Forms.Button();
            this.add_umk = new System.Windows.Forms.Button();
            this.dg_prj_files = new System.Windows.Forms.DataGridView();
            this.clmn_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmln_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmn_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_back_to_gb_list = new System.Windows.Forms.Button();
            this.save_plan = new System.Windows.Forms.Button();
            this.txt_plan_open_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gb_plan_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_prj_files)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close_window
            // 
            this.btn_close_window.Location = new System.Drawing.Point(543, 391);
            this.btn_close_window.Name = "btn_close_window";
            this.btn_close_window.Size = new System.Drawing.Size(101, 24);
            this.btn_close_window.TabIndex = 0;
            this.btn_close_window.Text = "Выход";
            this.btn_close_window.UseVisualStyleBackColor = true;
            this.btn_close_window.Click += new System.EventHandler(this.btn_close_window_Click);
            // 
            // gb_list
            // 
            this.gb_list.Controls.Add(this.btn_open_plan);
            this.gb_list.Controls.Add(this.btn_create_plan);
            this.gb_list.Controls.Add(this.btn_delete_plan);
            this.gb_list.Controls.Add(this.pictureBox2);
            this.gb_list.Controls.Add(this.label8);
            this.gb_list.Controls.Add(this.lst_plans);
            this.gb_list.Location = new System.Drawing.Point(12, 12);
            this.gb_list.Name = "gb_list";
            this.gb_list.Size = new System.Drawing.Size(632, 373);
            this.gb_list.TabIndex = 1;
            this.gb_list.TabStop = false;
            this.gb_list.Text = "Учебные планы:";
            this.gb_list.Visible = false;
            // 
            // btn_open_plan
            // 
            this.btn_open_plan.Location = new System.Drawing.Point(464, 75);
            this.btn_open_plan.Name = "btn_open_plan";
            this.btn_open_plan.Size = new System.Drawing.Size(95, 22);
            this.btn_open_plan.TabIndex = 8;
            this.btn_open_plan.Text = "Открыть";
            this.toolTip1.SetToolTip(this.btn_open_plan, "Открыть учебный план");
            this.btn_open_plan.UseVisualStyleBackColor = true;
            this.btn_open_plan.Click += new System.EventHandler(this.btn_open_plan_Click);
            // 
            // btn_create_plan
            // 
            this.btn_create_plan.Location = new System.Drawing.Point(464, 47);
            this.btn_create_plan.Name = "btn_create_plan";
            this.btn_create_plan.Size = new System.Drawing.Size(95, 22);
            this.btn_create_plan.TabIndex = 7;
            this.btn_create_plan.Text = "Создать";
            this.toolTip1.SetToolTip(this.btn_create_plan, "Создать новый учебный план");
            this.btn_create_plan.UseVisualStyleBackColor = true;
            this.btn_create_plan.Click += new System.EventHandler(this.btn_create_plan_Click);
            // 
            // btn_delete_plan
            // 
            this.btn_delete_plan.Location = new System.Drawing.Point(464, 19);
            this.btn_delete_plan.Name = "btn_delete_plan";
            this.btn_delete_plan.Size = new System.Drawing.Size(95, 22);
            this.btn_delete_plan.TabIndex = 6;
            this.btn_delete_plan.Text = "Удалить";
            this.toolTip1.SetToolTip(this.btn_delete_plan, "Удалить учебный план");
            this.btn_delete_plan.UseVisualStyleBackColor = true;
            this.btn_delete_plan.Click += new System.EventHandler(this.btn_delete_plan_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(498, 132);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(461, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 98);
            this.label8.TabIndex = 4;
            this.label8.Text = "Учебный план - документ, определяющий состав учебных дисциплин, изучаемых в данно" +
                "м учебном заведении, их распределение по годам в течение всего срока обучения. ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lst_plans
            // 
            this.lst_plans.FormattingEnabled = true;
            this.lst_plans.Location = new System.Drawing.Point(6, 19);
            this.lst_plans.Name = "lst_plans";
            this.lst_plans.Size = new System.Drawing.Size(449, 342);
            this.lst_plans.TabIndex = 0;
            this.lst_plans.DoubleClick += new System.EventHandler(this.lst_plans_DoubleClick);
            // 
            // combo_level
            // 
            this.combo_level.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.combo_level.FormattingEnabled = true;
            this.combo_level.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.combo_level.Location = new System.Drawing.Point(293, 54);
            this.combo_level.Name = "combo_level";
            this.combo_level.Size = new System.Drawing.Size(65, 22);
            this.combo_level.TabIndex = 9;
            this.toolTip1.SetToolTip(this.combo_level, "Выберите курс");
            this.combo_level.SelectedIndexChanged += new System.EventHandler(this.combo_level_SelectedIndexChanged);
            // 
            // gb_plan_edit
            // 
            this.gb_plan_edit.Controls.Add(this.label4);
            this.gb_plan_edit.Controls.Add(this.combo_level);
            this.gb_plan_edit.Controls.Add(this.label3);
            this.gb_plan_edit.Controls.Add(this.remove_umk);
            this.gb_plan_edit.Controls.Add(this.add_umk);
            this.gb_plan_edit.Controls.Add(this.dg_prj_files);
            this.gb_plan_edit.Controls.Add(this.label2);
            this.gb_plan_edit.Controls.Add(this.btn_back_to_gb_list);
            this.gb_plan_edit.Controls.Add(this.save_plan);
            this.gb_plan_edit.Controls.Add(this.txt_plan_open_name);
            this.gb_plan_edit.Controls.Add(this.label1);
            this.gb_plan_edit.Location = new System.Drawing.Point(6, 112);
            this.gb_plan_edit.Name = "gb_plan_edit";
            this.gb_plan_edit.Size = new System.Drawing.Size(632, 373);
            this.gb_plan_edit.TabIndex = 2;
            this.gb_plan_edit.TabStop = false;
            this.gb_plan_edit.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(367, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "курса.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(254, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "для";
            // 
            // remove_umk
            // 
            this.remove_umk.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.remove_umk.Location = new System.Drawing.Point(128, 53);
            this.remove_umk.Name = "remove_umk";
            this.remove_umk.Size = new System.Drawing.Size(116, 24);
            this.remove_umk.TabIndex = 7;
            this.remove_umk.Text = "Удалить УМК";
            this.remove_umk.UseVisualStyleBackColor = true;
            this.remove_umk.Click += new System.EventHandler(this.remove_umk_Click);
            // 
            // add_umk
            // 
            this.add_umk.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_umk.Location = new System.Drawing.Point(6, 53);
            this.add_umk.Name = "add_umk";
            this.add_umk.Size = new System.Drawing.Size(116, 24);
            this.add_umk.TabIndex = 6;
            this.add_umk.Text = "Добавить УМК";
            this.add_umk.UseVisualStyleBackColor = true;
            this.add_umk.Click += new System.EventHandler(this.add_umk_Click);
            // 
            // dg_prj_files
            // 
            this.dg_prj_files.AllowUserToAddRows = false;
            this.dg_prj_files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_prj_files.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dg_prj_files.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_prj_files.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_prj_files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_prj_files.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmn_name,
            this.cmln_type,
            this.clmn_path});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_prj_files.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_prj_files.Location = new System.Drawing.Point(6, 83);
            this.dg_prj_files.Name = "dg_prj_files";
            this.dg_prj_files.RowHeadersWidth = 40;
            this.dg_prj_files.Size = new System.Drawing.Size(620, 279);
            this.dg_prj_files.TabIndex = 5;
            this.dg_prj_files.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_prj_files_CellContentClick);
            // 
            // clmn_name
            // 
            this.clmn_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmn_name.HeaderText = "Название";
            this.clmn_name.Name = "clmn_name";
            this.clmn_name.Width = 82;
            // 
            // cmln_type
            // 
            this.cmln_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cmln_type.HeaderText = "Шифр";
            this.cmln_type.Name = "cmln_type";
            this.cmln_type.Width = 61;
            // 
            // clmn_path
            // 
            this.clmn_path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmn_path.HeaderText = "Путь";
            this.clmn_path.Name = "clmn_path";
            this.clmn_path.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "* имя файла для создаваемого\\редактируемого учебного плана";
            // 
            // btn_back_to_gb_list
            // 
            this.btn_back_to_gb_list.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_back_to_gb_list.Location = new System.Drawing.Point(474, 42);
            this.btn_back_to_gb_list.Name = "btn_back_to_gb_list";
            this.btn_back_to_gb_list.Size = new System.Drawing.Size(152, 25);
            this.btn_back_to_gb_list.TabIndex = 3;
            this.btn_back_to_gb_list.Text = "К списку планов";
            this.btn_back_to_gb_list.UseVisualStyleBackColor = true;
            this.btn_back_to_gb_list.Click += new System.EventHandler(this.btn_back_to_gb_list_Click);
            // 
            // save_plan
            // 
            this.save_plan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_plan.Location = new System.Drawing.Point(474, 11);
            this.save_plan.Name = "save_plan";
            this.save_plan.Size = new System.Drawing.Size(152, 25);
            this.save_plan.TabIndex = 2;
            this.save_plan.Text = "Сохранить план";
            this.save_plan.UseVisualStyleBackColor = true;
            this.save_plan.Click += new System.EventHandler(this.save_plan_Click);
            // 
            // txt_plan_open_name
            // 
            this.txt_plan_open_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_plan_open_name.Location = new System.Drawing.Point(160, 14);
            this.txt_plan_open_name.Name = "txt_plan_open_name";
            this.txt_plan_open_name.Size = new System.Drawing.Size(298, 22);
            this.txt_plan_open_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название учебного плана:";
            // 
            // win_plans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 427);
            this.Controls.Add(this.gb_plan_edit);
            this.Controls.Add(this.gb_list);
            this.Controls.Add(this.btn_close_window);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "win_plans";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор учебных планов";
            this.Load += new System.EventHandler(this.win_plans_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.win_plans_FormClosing);
            this.gb_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gb_plan_edit.ResumeLayout(false);
            this.gb_plan_edit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_prj_files)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_close_window;
        private System.Windows.Forms.GroupBox gb_list;
        private System.Windows.Forms.ListBox lst_plans;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_delete_plan;
        private System.Windows.Forms.Button btn_open_plan;
        private System.Windows.Forms.Button btn_create_plan;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox gb_plan_edit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_back_to_gb_list;
        private System.Windows.Forms.Button save_plan;
        private System.Windows.Forms.TextBox txt_plan_open_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dg_prj_files;
        private System.Windows.Forms.Button add_umk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_level;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button remove_umk;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmln_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn_path;
    }
}