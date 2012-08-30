using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DiskCreator
{
    public partial class win_about : Form
    {
        cls_main Main_func = new cls_main();
        public win_about()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void win_about_Load(object sender, EventArgs e)
        {
            Label2.Text = "Версия: " +  Application.ProductVersion.ToString();
        }

        private void Label7_Click(object sender, EventArgs e)
        {
          Main_func.open_webdoc("mailto:dsoft88@gmail.com");
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            Main_func.open_webdoc("http://dsoft88.spaces.live.com");
        }

        private void Label7_MouseEnter(object sender, EventArgs e)
        {
            Label7.ForeColor = Color.Blue;
        }

        private void Label7_MouseLeave(object sender, EventArgs e)
        {
            Label7.ForeColor = Color.Black;
        }

        private void Label8_MouseEnter(object sender, EventArgs e)
        {
            Label8.ForeColor = Color.Blue;
        }

        private void Label8_MouseLeave(object sender, EventArgs e)
        {
            Label8.ForeColor = Color.Black;
        }
    }
}
