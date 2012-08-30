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
    public partial class win_add_umk : Form
    {
        int umk_level = 0;
        string umk_dir = "";
        string unit_name = "";
        string caf_name = "";
        string umk_name = "";
        string file_name = "";
        public int selected_level = 0;
        public string selected_obj = "";
        public string selected_path = "";

        public void change_vars(string umk_directory)
        {
            umk_dir = umk_directory+"\\";
        }

        public win_add_umk()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void win_add_umk_Load(object sender, EventArgs e)
        {
            System.Collections.ObjectModel.Collection<string> return_lst = new System.Collections.ObjectModel.Collection<string>();
            cls_main main_func=new cls_main();
            //
            umk_level = 0;
            lbl_name.Text = "Выберите подразделение.";
            show_path("");
            
            
           // return_lst = main_func.get_dir(umk_dir);
            //if (return_lst.Count > 0)
            //{
             //   for (int i = 0; i < return_lst.Count-1; i++)
             //   {
              //      lst_files.Items.Add(return_lst[i]);
              //  }
           // }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            add_to_app();
        }

        void add_to_app()
        {
            if (lst_files.SelectedIndex >= 0)
            //if (lst_files.SelectedItem.ToString() != "")
            {
                selected_level = umk_level;
                selected_obj = lst_files.SelectedItem.ToString();
                switch (umk_level)
                {
                    case 0:
                        //selected_path = umk_dir;
                        selected_path = "";
                        break;
                    case 1:
                        selected_path = unit_name;
                        //selected_path = umk_dir + "\\" + unit_name;
                        break;
                    case 2:
                        selected_path =unit_name + "\\" + caf_name;
                        //selected_path = umk_dir + "\\" + unit_name + "\\" + caf_name;
                        break;
                    case 3:
                        selected_path = unit_name + "\\" + caf_name + "\\" + umk_name;
                        //selected_path = umk_dir + "\\" + unit_name + "\\" + caf_name + "\\" + umk_name;
                        break;
                    // case 4:
                    // selected_path = umk_dir + "\\" + unit_name + "\\" + caf_name + "\\" + umk_name + "\\" + lst_files.SelectedItem.ToString();
                    // break;
                }
                if (umk_level != 3 & umk_level!=2)
                {
                    if (MessageBox.Show("Вы действительно хотите добавить все УМК из выбранной папки?", "Добавить УМК?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                        selected_path = "";
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        void show_path(string selected_value)
        {
            string open_path = "";
            System.Collections.ObjectModel.Collection<string> return_lst = new System.Collections.ObjectModel.Collection<string>();
            cls_main main_func = new cls_main();
            switch (umk_level)
            {
                case 0:
                    open_path = umk_dir;
                    return_lst = main_func.get_dir(open_path);
                    lbl_name.Text = "Выберите подразделение!";
                    break;
                case 1:
                    open_path = umk_dir + "\\" + selected_value;
                    if (selected_value.Length > 0) { unit_name = selected_value; };
                    return_lst = main_func.get_dir(open_path);
                    lbl_name.Text = "Выбрано: " + unit_name + ". Выберите кафедру!";
                    break;
                case 2:
                    open_path = umk_dir + "\\" + unit_name + "\\" + selected_value;
                   if (selected_value.Length > 0) { caf_name = selected_value; }
                    return_lst = main_func.get_dir(open_path);
                    lbl_name.Text = "Выбрано: " + caf_name + ". Выберите УМК!";
                    break;
                //case 3:
                 //   open_path = umk_dir + "\\" + unit_name + "\\" + caf_name + "\\" + selected_value;
                  // if (selected_value.Length > 0) { umk_name = selected_value; }
                  //  return_lst = main_func.get_files_indir(open_path);
                  //  lbl_name.Text = "> " + umk_name + ". Выберите файл!";
                   // break;
               // case 4:
                   // open_path = umk_dir + "\\" + unit_name + "\\" + caf_name + "\\" + umk_name + "\\" + selected_value;
                   // file_name = selected_value;
                   // break;
            }
            //MessageBox.Show(unit_name + "\\" + caf_name + "\\" + umk_name);
           if (umk_level != 4 && umk_level!=3)
            {
                lst_files.Items.Clear();
                if (return_lst.Count > 0)
                {
                    for (int i = 0; i < return_lst.Count; i++)
                    {
                        if (main_func.get_extention(return_lst[i]) != "info" && main_func.get_extention(return_lst[i]) != "dat")
                        {
                           lst_files.Items.Add(return_lst[i]);
                        }
                    }
                }
            }
        }


        private void lst_files_DoubleClick(object sender, EventArgs e)
        {
            if (lst_files.SelectedItem!= null & umk_level!=3  )
            {
                if (umk_level == 2)
                {
                    add_to_app();
                }
                else
                {
                    //MessageBox.Show(umk_level.ToString());
                    if (umk_level < 3) { umk_level++; }   
                    show_path(lst_files.SelectedItem.ToString()); 
                }
            }            
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
                umk_level = umk_level - 1;
                switch (umk_level)
                {
                    case 0:
                        show_path("");
                        break;
                    case 1:
                        show_path(unit_name);
                        break;
                    case 2:
                        show_path(caf_name);
                        break;
                   case 3:
                        show_path(file_name);
                       break;
                }
        }

        private void lst_files_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
