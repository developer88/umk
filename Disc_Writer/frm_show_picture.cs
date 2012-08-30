using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiskCreator
{
    public partial class frm_show_picture : Form
    {
        public frm_show_picture()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void load_picture(string picture_path)
        {
            if (picture_path != "")
            {
                pictureBox1.Load(picture_path);
            }
        }
    }
}
