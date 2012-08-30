using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;
using System.Net.Mime;

namespace developers_components_lib
{
    public class cls_about_dlg
    {
        public void show_dlg(string app_name, string app_ver, string app_status, string app_desc,  Image app_icon, string licence_path,string help_path,string app_code,int build_n,bool check_for_update)
        {
            AboutBox about_dlg = new AboutBox();
            if (licence_path != "")
            {
                about_dlg.lbl_licence_open.Tag = licence_path;
            }
            else
            {
                about_dlg.lbl_licence_open.Enabled = false;
                about_dlg.lbl_licence_open.ForeColor = Color.Gray;
            }
            if (help_path != "")
            {
                about_dlg.lbl_help.Tag = help_path;
            }
            else
            {
                about_dlg.lbl_help.Enabled = false;
                about_dlg.lbl_help.Visible = false;
                about_dlg.lbl_help.ForeColor = Color.Gray;
            }
            about_dlg.lbl_send_feedback.Visible = false;
            about_dlg.lbl_caption.Text = app_name;
            about_dlg.lbl_desc.Text = app_desc;
            about_dlg.lbl_status.Text = app_status;
            about_dlg.lbl_ver.Text = app_ver;
            about_dlg.PictureBox1.Image = app_icon;
            about_dlg.lbl_update.Tag = app_code;
            about_dlg.lbl_ver_status.Text = "Вы пользуетесь самой новой версией.";
            about_dlg.lbl_ver_status.ForeColor = Color.Green;
            //check for new version
            if (check_for_update)
            {
                if (is_update_availible(app_code, build_n))
                {
                    about_dlg.lbl_update.Visible = true;
                    about_dlg.lbl_ver_status.Text = "Доступна новая версия!";
                    about_dlg.lbl_ver_status.ForeColor = Color.Red;
                }
            }
            else
            {
                about_dlg.lbl_ver_status.Visible = false;
            }
            about_dlg.ShowDialog();
        }

        bool is_update_availible(string app_code,int app_ver)
        {
            bool need_update = false;
            try
            {
                WebRequest request = WebRequest.Create("http://dsoft.studenthost.ru/updates/" + app_code + ".txt");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                if (Convert.ToInt32(responseFromServer) > Convert.ToInt32(app_ver)) { need_update = true; };
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch  
            {
                need_update=false;
            }
            return need_update;
        }
    }
}
