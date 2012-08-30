using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Windows;
using Microsoft.Win32;
using System.Diagnostics;

namespace developers_components_lib
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        public void open_webdoc(string web_path)
        {
            string windir = "";
            windir = Environment.GetEnvironmentVariable("windir");
            Process.Start(web_path);
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            open_webdoc("mailto:dsoft88@gmail.com");
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            open_webdoc("http://eremin.me");
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

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_licence_open_Click(object sender, EventArgs e)
        {
            open_webdoc(lbl_licence_open.Tag.ToString());
        }

        private void lbl_licence_open_MouseEnter(object sender, EventArgs e)
        {
            lbl_licence_open.ForeColor= Color.Blue;
        }

        private void lbl_licence_open_MouseLeave(object sender, EventArgs e)
        {
            lbl_licence_open.ForeColor= Color.Black;
        }

        private void lbl_send_feedback_Click(object sender, EventArgs e)
        {
            open_webdoc("http://dsoft.studenthost.ru/feedback.aspx");
        }

        private void lbl_send_feedback_MouseEnter(object sender, EventArgs e)
        {
            lbl_send_feedback.ForeColor = Color.Blue;
        }

        private void lbl_send_feedback_MouseLeave(object sender, EventArgs e)
        {
            lbl_send_feedback.ForeColor = Color.Black;
        }

        private void lbl_help_MouseEnter(object sender, EventArgs e)
        {
            lbl_help.ForeColor = Color.Blue;
        }

        private void lbl_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.ForeColor = Color.Black;
        }

        private void lbl_help_Click(object sender, EventArgs e)
        {
            open_webdoc(lbl_help.Tag.ToString());
        }

        private void lbl_update_MouseEnter(object sender, EventArgs e)
        {
            lbl_update.ForeColor = Color.Blue; 
        }

        private void lbl_update_MouseLeave(object sender, EventArgs e)
        {
            lbl_update.ForeColor = Color.Black;
        }

        private void lbl_update_Click(object sender, EventArgs e)
        {
            open_webdoc("http://dsoft.studenthost.ru/download.aspx?appid="+lbl_update.Tag);
        }


    }
}
