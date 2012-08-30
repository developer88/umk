using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace DiskCreator
{
    public partial class win_plans : Form
    {
        string plans_dir = AppDomain.CurrentDomain.BaseDirectory + "system\\plans";
        bool plan_isOpen = false;
        public string umk_folder = "";
        string plan_open_name = "";
        int selected_level =1;
        System.Collections.ObjectModel.Collection<string> lst_all_umk = new System.Collections.ObjectModel.Collection<string>();

        public win_plans()
        {
            InitializeComponent();
        }

        void show_gb_list()
        {
            clear_form();
            lst_plans.Items.Clear();
            cls_main main_func = new cls_main();
            System.Collections.ObjectModel.Collection<string> lst_temp = new System.Collections.ObjectModel.Collection<string>();
            lst_temp = main_func.get_files_indir(plans_dir);
            if (lst_temp.Count != 0)
            {
                for (int i = 0; i < lst_temp.Count; i++)
                {
                    if(main_func.get_extention(lst_temp[i].ToString())== "xml")
                    {
                        lst_plans.Items.Add(lst_temp[i].ToString());
                    }
                }
            }
            gb_list.Visible = true;
            gb_plan_edit.Visible = false;
        }

        void show_gb_edit_plan()
        {
            gb_plan_edit.Top = gb_list.Top;
            gb_plan_edit.Left = gb_list.Left;
            gb_list.Visible = false;
            gb_plan_edit.Visible = true;
            show_level(selected_level);
            txt_plan_open_name.Text = plan_open_name;
        }

        void clear_form()
        {
            plan_isOpen = false;
            plan_open_name = "";
            txt_plan_open_name.Text = "";
            lst_plans.Items.Clear();
            dg_prj_files.Rows.Clear();
            selected_level = 0;
            combo_level.SelectedIndex = selected_level;            
            lst_all_umk.Clear();
        }

        private void btn_close_window_Click(object sender, EventArgs e)
        {
            close_form();
        }

        void close_form()
        {
            //if (plan_open_name != "")
           // {
             //   DialogResult result = MessageBox.Show("Данное действите приведёт к закрытию текущего учебного плана, продолжить?", "Закрыть учебный план?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             //   if (result == DialogResult.Yes)
              //  {
                   this.Close();
               // }
            //}
           // else { this.Close();  }
        }

        private void win_plans_Load(object sender, EventArgs e)
        {
            show_gb_list();
        }

        private void btn_delete_plan_Click(object sender, EventArgs e)
        {
            if (Microsoft.VisualBasic.Strings.Len(lst_plans.SelectedItem.ToString()) > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить рабочий учебный план " + lst_plans.SelectedItem.ToString() + "?", "Удаление учебного плана", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.Delete(plans_dir + "\\" + lst_plans.SelectedItem.ToString());
                    lst_plans.Items.Remove(lst_plans.SelectedItem);
                }
            }
        }

        private void btn_create_plan_Click(object sender, EventArgs e)
        {
            clear_form();
            //gb_plan_edit.Top = gb_list.Top;
            //gb_plan_edit.Left = gb_list.Left;
           // gb_plan_edit.Visible = true;
            //gb_list.Visible = false;
            plan_open_name = "";
            plan_isOpen = true;
            selected_level = 0;
            show_gb_edit_plan();
        }

        private void btn_open_plan_Click(object sender, EventArgs e)
        {
            if (lst_plans.SelectedItem!=null)
            //if (Microsoft.VisualBasic.Strings.Len(lst_plans.SelectedItem.ToString()) > 0)
            {
                open_plan(lst_plans.SelectedItem.ToString());
            }
        }

        void open_plan(string plan_name)
        {
            cls_main main_func = new cls_main();
            clear_form();
            string s_temp="";
            FileStream fs = new FileStream(plans_dir + "\\" +  plan_name, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Xml.XmlDocument CXML = new System.Xml.XmlDocument();
            try
            {
                CXML.Load(fs);
                for (int i = 0; i < CXML.DocumentElement.ChildNodes.Count; i++)
                {
                    s_temp = CXML.DocumentElement.ChildNodes[i].Attributes[0].Value.ToString() + ";" + CXML.DocumentElement.ChildNodes[i].Attributes[1].Value.ToString() + ";" + CXML.DocumentElement.ChildNodes[i].InnerText + ";" + CXML.DocumentElement.ChildNodes[i].Attributes[2].Value.ToString();
                    lst_all_umk.Add(s_temp);
                }
            }
            catch { };
            fs.Close();
            plan_isOpen=true;
            plan_open_name=main_func.get_filename_without_ex( plan_name);
            selected_level=0;
            show_gb_edit_plan();
        }

        void sort_data_in_plan()
        {
            if (lst_all_umk.Count > 0)
            {
                System.Collections.ObjectModel.Collection<string> lst_umk2= new System.Collections.ObjectModel.Collection<string>();
                for (int i = 0; i < lst_all_umk.Count; i++)
                {
                    lst_umk2.Add(lst_all_umk[i]);
                }
                lst_all_umk.Clear();
                for (int i = 0; i < lst_umk2.Count; i++)
                {
                    for (int h = 0; h < lst_umk2.Count; h++)
                    {
                        string s_temp = Microsoft.VisualBasic.Strings.Right(lst_umk2[h], 1);
                        if (s_temp == i.ToString()) { lst_all_umk.Add(lst_umk2[h]); }
                    }
                }
            }
        }

        void save_u_plan(string plan_name)
        {
            sort_data_in_plan();
            string full_plan_name = plan_name + ".xml";
            cls_main main_func = new cls_main();
            System.Xml.XmlDocument CXML = new System.Xml.XmlDocument();
            if (File.Exists(plans_dir + "\\" + full_plan_name) == true) { File.Delete(plans_dir + "\\" + full_plan_name); }
            // Write down the XML declaration
            XmlDeclaration xmlDeclaration = CXML.CreateXmlDeclaration("1.0", "utf-8", null);
            // Create the root element
            XmlElement rootNode = CXML.CreateElement("eplan");
            CXML.InsertBefore(xmlDeclaration, CXML.DocumentElement);
            CXML.AppendChild(rootNode);
            //adding new nodes
            if (lst_all_umk.Count > 0)
            {
                for (int i = 0; i < lst_all_umk.Count; i++)
                {
                    string s_temp = lst_all_umk[i];
                    if (s_temp != "")
                    {
                        string[] str_temp = s_temp.Split(Convert.ToChar(";"));
                        if (str_temp.GetUpperBound(0) > 0)
                        {
                            XmlElement newitem = CXML.CreateElement("unit");
                            newitem.InnerText = str_temp[2];
                            XmlAttribute xmlat1 = CXML.CreateAttribute("name");
                            xmlat1.InnerText = str_temp[0];
                            XmlAttribute xmlat2 = CXML.CreateAttribute("code");
                            xmlat2.InnerText = str_temp[1];
                            XmlAttribute xmlat3 = CXML.CreateAttribute("year");
                            xmlat3.InnerText = str_temp[3];
                            newitem.Attributes.Append(xmlat1);
                            newitem.Attributes.Append(xmlat2);
                            newitem.Attributes.Append(xmlat3);
                            CXML.DocumentElement.InsertAfter(newitem, CXML.DocumentElement.LastChild);
                        }
                    }
                }
            }
            // Save to the XML file
            CXML.Save(plans_dir + "\\" + full_plan_name);
        }

        void rename_plan(string plan_old_name, string plan_new_name)
        {
            File.Copy(plans_dir + "\\" + plan_old_name + ".xml", plans_dir + "\\" + plan_new_name + ".xml", true);
            File.Delete(plans_dir + "\\" + plan_old_name + ".xml");
            save_u_plan(plan_new_name);
        }

        private void btn_back_to_gb_list_Click(object sender, EventArgs e)
        {
            if (plan_isOpen==true)
            {
                DialogResult result = MessageBox.Show("Данное действите приведёт к закрытию текущего учебного плана, продолжить?", "Закрыть учебный план?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    show_gb_list();
                }
            }
            else { show_gb_list(); }
        }

        private void combo_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (combo_level.SelectedIndex != selected_level)
            //{
                //if (lst_all_umk.Count > 0)
                //{
                    update_level_files(selected_level);
                    selected_level = combo_level.SelectedIndex;
                    show_level(selected_level);
                //}
                //else
                //{
                   // selected_level = combo_level.SelectedIndex;
                   // show_level(selected_level);
                //}
           // }
        }

        void update_level_files(int old_level)
        {
            System.Collections.ObjectModel.Collection<string> lst_to_delete= new System.Collections.ObjectModel.Collection<string>();
            //delete old values
            if (lst_all_umk.Count > 0)
            {
                lst_to_delete.Clear();
                foreach (string s_item in lst_all_umk)
                {
                    string s_temp = Microsoft.VisualBasic.Strings.Right(s_item, 1);
                    if (s_temp == old_level.ToString()) { lst_to_delete.Add(s_item); }
                }
                for (int i = 0; i < lst_to_delete.Count; i++)
                {
                    lst_all_umk.Remove(lst_to_delete[i]);
                }
            }
            //add new values
            for (int i = 0; i < dg_prj_files.Rows.Count; i++)
            {
                string new_value = dg_prj_files.Rows[i].Cells[0].Value.ToString() + ";" + dg_prj_files.Rows[i].Cells[1].Value.ToString() + ";" + dg_prj_files.Rows[i].Cells[2].Value.ToString() + ";" + old_level.ToString();
                lst_all_umk.Add(new_value);
            }
        }

        void show_level(int level)
        {
            dg_prj_files.Rows.Clear();
            if (lst_all_umk.Count > 0)
            {
                for (int i = 0; i < lst_all_umk.Count; i++)
                {
                    string s_temp=lst_all_umk[i];
                    if (s_temp != "")
                    {
                        string[] str_temp = s_temp.Split(Convert.ToChar(";"));
                        if (str_temp.GetUpperBound(0) > 0)
                        {
                            string s_temp1 = Microsoft.VisualBasic.Strings.Right(lst_all_umk[i], 1);
                            if (Convert.ToInt32(s_temp1) == level)
                            {
                                string[] row1 = { str_temp[0], str_temp[1], str_temp[2] };
                                dg_prj_files.Rows.Add(row1);
                            }
                        }
                    }
                }
            }
        }

        private void save_plan_Click(object sender, EventArgs e)
        {
            if (txt_plan_open_name.Text != "")
            {
                if (txt_plan_open_name.Text != plan_open_name & plan_open_name!="")
                {
                    update_level_files(selected_level);
                    rename_plan(plan_open_name,txt_plan_open_name.Text);
                    save_u_plan(txt_plan_open_name.Text);
                    plan_open_name = txt_plan_open_name.Text;
                }
                else
                {
                    update_level_files(selected_level);
                    save_u_plan(txt_plan_open_name.Text);
                    plan_open_name = txt_plan_open_name.Text;
                }
            }
            else
            {
                MessageBox.Show("Укажите название для учебного плана!", "Нет названия!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void add_umk_Click(object sender, EventArgs e)
        {
            win_add_umk window_umk = new win_add_umk();
            System.Collections.ObjectModel.Collection<string> return_lst = new System.Collections.ObjectModel.Collection<string>();
            System.Collections.ObjectModel.Collection<string> return_lst1 = new System.Collections.ObjectModel.Collection<string>();
            System.Collections.ObjectModel.Collection<string> return_lst2 = new System.Collections.ObjectModel.Collection<string>();
            cls_main main_func = new cls_main();
             window_umk.change_vars(umk_folder);
            window_umk.ShowDialog();
            //if (window_umk.selected_path != "")
            //{
                if (window_umk.selected_level == 2)
                {
                    //if (if_cell_ISexists(2, window_umk.selected_path + "\\" + window_umk.selected_obj) != true)
                    //{
                        string[] row1 = { window_umk.selected_obj, main_func.get_value_from_infofile(umk_folder + "\\" + window_umk.selected_path + "\\" + window_umk.selected_obj + "\\info.dat", "code"), window_umk.selected_path + "\\" + window_umk.selected_obj };
                        dg_prj_files.Rows.Add(row1);
                    //}
                }
                else
                {
                    if (window_umk.selected_level == 0)
                    {
                        return_lst.Clear();
                        return_lst1.Clear();
                        return_lst = main_func.get_dir(umk_folder +  window_umk.selected_path + "\\" + window_umk.selected_obj);
                        if (return_lst.Count > 0)
                        {
                            for (int i = 0; i < return_lst.Count; i++)
                            {
                                return_lst1 = main_func.get_dir(umk_folder +  window_umk.selected_path + "\\" + window_umk.selected_obj + "\\" + return_lst[i]);                              
                                if (return_lst1.Count > 0)
                                {
                                    for (int j = 0; j < return_lst1.Count; j++)
                                    {
                                        //if (if_cell_ISexists(2,  window_umk.selected_obj + "\\" + return_lst[i] + "\\" + return_lst1[j]) != true)
                                        //{
                                            string[] row1 = { return_lst1[j], main_func.get_value_from_infofile(umk_folder + window_umk.selected_path + "\\" + window_umk.selected_obj + "\\" + return_lst[i] + "\\" + return_lst1[j] + "\\info.dat", "code"),  window_umk.selected_obj + "\\" + return_lst[i] + "\\" + return_lst1[j] };
                                            dg_prj_files.Rows.Add(row1);
                                        //}
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        return_lst.Clear();
                        return_lst = main_func.get_dir(umk_folder + "\\" + window_umk.selected_path + "\\" + window_umk.selected_obj);
                        if (return_lst.Count > 0)
                        {
                            for (int i = 0; i < return_lst.Count; i++)
                            {
                                //if (if_cell_ISexists(2,  window_umk.selected_path + "\\" + window_umk.selected_obj + "\\" + return_lst[i]) != true)
                                //{
                                    string[] row1 = { return_lst[i], main_func.get_value_from_infofile(umk_folder + "\\" + window_umk.selected_path + "\\" + window_umk.selected_obj + "\\" + return_lst[i] + "\\info.dat", "code"), window_umk.selected_path + "\\" + window_umk.selected_obj + "\\" + return_lst[i] };
                                    dg_prj_files.Rows.Add(row1);
                                //}
                            }
                        }
                    }
                }
            //}
            update_level_files(selected_level);
        }

        bool if_cell_ISexists(int column_id, string cell_text)
        {
            bool result = false;
            if (dg_prj_files.Rows.Count > 0)
            {
                for (int i = 0; i < dg_prj_files.Rows.Count; i++)
                {
                    //MessageBox.Show(cell_text + "\n" + column_id + dg_prj_files.Rows[i].Cells[column_id].ToString());
                     if (dg_prj_files.Rows[i].Cells[column_id].Value.ToString() == cell_text) { result = true; };
                }
            }
            return result;
        }

        private void remove_umk_Click(object sender, EventArgs e)
        {
            if (dg_prj_files.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                //if (dg_prj_files.SelectedRows[0].Cells[0].Value.ToString() != "")
                //{
                dg_prj_files.Rows.Remove(dg_prj_files.SelectedRows[0]);
                update_level_files(selected_level);
                //}
            }
        }

        private void win_plans_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (plan_open_name != "")
            //{
            //    DialogResult result = MessageBox.Show("Данное действите приведёт к закрытию текущего учебного плана, продолжить?", "Закрыть учебный план?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
                    //close_form();
            //    }
            //}
            //else { close_form(); }
        }

        private void lst_plans_DoubleClick(object sender, EventArgs e)
        {
            if (lst_plans.SelectedItem != null)
            //if (Microsoft.VisualBasic.Strings.Len(lst_plans.SelectedItem.ToString()) > 0)
            {
                open_plan(lst_plans.SelectedItem.ToString());
            }
        }

        private void dg_prj_files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





    }
}
