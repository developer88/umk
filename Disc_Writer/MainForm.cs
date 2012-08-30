using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using IMAPI2.Interop;
using IMAPI2.MediaItem;
using System.Windows;
using System.Diagnostics;

namespace DiskCreator
{

    public partial class MainForm : Form
    {
        string prj_version = "100";
        string shell_config_version = "100";
        string shell_search_db_version = "100";
        string plans_dir = AppDomain.CurrentDomain.BaseDirectory + "system\\plans";
        bool prj_exist = true;
        int prj_open = 0;
        string prj_folder=AppDomain.CurrentDomain.BaseDirectory + "Projects\\";
        string appdir = AppDomain.CurrentDomain.BaseDirectory;
        string prj_open_name = "";
        string umk_folder = "";
        string prj_create_date = "";
        bool prj_IS_built = false;
        string prj_build_date = "";
        string disk_style = "";
        bool isBurn_func_show = false;
        bool m_isStructurising = false;
        System.Collections.ObjectModel.Collection<string> lst_style_preview_filename = new System.Collections.ObjectModel.Collection<string>();
        private string m_clientName = "Disk Creator";
        Int64 totalDiscSize = 0;
        private bool m_isBurning = false;
        private bool m_isFormatting = false;
        private IMAPI_BURN_VERIFICATION_LEVEL m_verificationLevel =  IMAPI_BURN_VERIFICATION_LEVEL.IMAPI_BURN_VERIFICATION_NONE;
        private BurnData m_burnData = new BurnData();
        //for_structur
        string s_plan_name = "";
        string s_convert_to_type = "";
        bool s_licence_enabled = false;
        string s_licence_type = "";
        string s_splash_type = "";
        string s_edu_type = "";
        string s_control_type = "";
        string s_about_type = "";
        string s_help_type = "";
        string s_help_text = "";


        public MainForm()
        {
            InitializeComponent();
        }

        void add_files_to_listboxfiles(string filename)
        {
            FileItem fileItem = new FileItem(filename);
            listBoxFiles.Items.Add(fileItem);
        }

        void add_folder_to_listboxfiles(string filename)
        {
            DirectoryItem directoryItem = new DirectoryItem(filename);
            listBoxFiles.Items.Add(directoryItem);
        }

        public void add_prj_to_listboxfiles()
        {
            listBoxFiles.Items.Clear();
            System.Collections.ObjectModel.Collection<string> return_lst = new System.Collections.ObjectModel.Collection<string>();
            System.Collections.ObjectModel.Collection<string> return_fldr_lst = new System.Collections.ObjectModel.Collection<string>();
            cls_main main_func = new cls_main();
            return_lst = main_func.get_files_indir(prj_folder + prj_open_name + "\\distr\\");
            if (return_lst.Count > 0)
            {
                for (int i = 0; i < return_lst.Count; i++)
                {
                    add_files_to_listboxfiles(prj_folder + prj_open_name + "\\distr\\" + return_lst[i]);
                }
            }
            return_fldr_lst = main_func.get_dir(prj_folder + prj_open_name + "\\distr\\");
            if (return_fldr_lst.Count > 0)
            {
                for (int i = 0; i < return_fldr_lst.Count; i++)
                {
                    add_folder_to_listboxfiles(prj_folder + prj_open_name + "\\distr\\" + return_fldr_lst[i]);
                }
            }
            UpdateCapacity();
        }

        public void update_list_with_plans()
        {
            System.Collections.ObjectModel.Collection<string> lst_temp2 = new System.Collections.ObjectModel.Collection<string>();
            cls_main main_func = new cls_main();
            combo_plans.Items.Clear();
            lst_temp2 = main_func.get_files_indir(plans_dir);
            for (int i = 0; i < lst_temp2.Count; i++)
            {
                if (main_func.get_extention(lst_temp2[i].ToString()) == "xml")
                {
                    combo_plans.Items.Add(lst_temp2[i]);
                }
            }  
        }

        System.Collections.ObjectModel.Collection<string> open_plan(string plan_name)
        {
            System.Collections.ObjectModel.Collection<string> lst_temp = new System.Collections.ObjectModel.Collection<string>();
            cls_main main_func = new cls_main();
            string s_temp = "";
            FileStream fs = new FileStream(plans_dir + "\\" + plan_name, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Xml.XmlDocument CXML = new System.Xml.XmlDocument();
            try
            {
                CXML.Load(fs);
                for (int i = 0; i < CXML.DocumentElement.ChildNodes.Count; i++)
                {
                    s_temp = CXML.DocumentElement.ChildNodes[i].Attributes[0].Value.ToString() + ";" + CXML.DocumentElement.ChildNodes[i].Attributes[1].Value.ToString() + ";" + CXML.DocumentElement.ChildNodes[i].InnerText + ";" + CXML.DocumentElement.ChildNodes[i].Attributes[2].Value.ToString();
                    lst_temp.Add(s_temp);
                }
            }
            catch { };
            fs.Close();
            return lst_temp;
        }

        void prepare_for_structur()
        {
            s_plan_name = combo_plans.Text;
            s_convert_to_type = combo_convert_to.Text;
            s_licence_enabled = check_licence.Checked;
            s_licence_type = combo_licence.Text;
            s_splash_type = combo_splash.Text;
            s_edu_type = combo_menu_edu.Text;
            s_control_type = combo_menu_control.Text;
            s_about_type = combo_menu_about.Text;
            s_help_text = txt_menu_help_path.Text;
            prj_build_date = "";
            prj_IS_built = false;
            s_help_type = combo_menu_help.Text;
        }

        public void start_create_structure()
        {
            m_isStructurising = true;            
            m_isStructurising = false;
        }

        public void save_project(string prj_name)
        {
            cls_main main_func = new cls_main();
            main_func.clear_lst_to_file();
            //write PRJ file
            main_func.clear_lst_to_file();
            main_func.add_to_lst_to_file("version=" + prj_version);
            main_func.add_to_lst_to_file("prj_name=" + prj_open_name);
            main_func.add_to_lst_to_file("prj_create_date=" + prj_create_date);
            main_func.add_to_lst_to_file("[PRJ SETTINGS]");
            main_func.add_to_lst_to_file("prj_disk_name=" + txt_disk_name.Text);
            main_func.add_to_lst_to_file("prj_author_name=" + txt_author_name.Text);
            main_func.add_to_lst_to_file("prj_licence_type=" + combo_licence.Text);
            main_func.add_to_lst_to_file("prj_licence=" + txt_licence_path.Text);
            main_func.add_to_lst_to_file("prj_licence_enabled=" + check_licence.Checked.ToString());
            main_func.add_to_lst_to_file("prj_disk_style=" + disk_style);
            main_func.add_to_lst_to_file("prj_splash_path=" + txt_splash_path.Text);
            main_func.add_to_lst_to_file("prj_disk_volume_label=" + textBoxLabel.Text);
            main_func.add_to_lst_to_file("prj_splash_type=" + combo_splash.Text);
            main_func.add_to_lst_to_file("prj_create_autorun_inf=" + chk_create_autorun_inf.Checked.ToString());
            main_func.add_to_lst_to_file("prj_student_profession=" + txt_profession.Text);
            main_func.add_to_lst_to_file("prj_student_specialization=" + txt_specialization.Text);
            main_func.add_to_lst_to_file("prj_student_year=" + txt_year.Text);
            main_func.add_to_lst_to_file("prj_eplan=" + combo_plans.Text);
            main_func.add_to_lst_to_file("prj_student_total_year=" + txt_total_year.Text);
            main_func.add_to_lst_to_file("prj_copy_service=" + chk_service_enabled.Checked.ToString());
            main_func.add_to_lst_to_file("prj_create_search=" + chk_search_enabled.Checked.ToString());
            main_func.add_to_lst_to_file("prj_glass_enabled=" + chk_glass_enabled.Checked.ToString());
            main_func.add_to_lst_to_file("prj_ziptests_enabled=" + chk_zip_tests_enabled.Checked.ToString());
            main_func.add_to_lst_to_file("prj_convert_files_to=" + combo_convert_to.Text);
            main_func.add_to_lst_to_file("[DISK_MENU_SETTINGS]");
            main_func.add_to_lst_to_file("prj_menu_edu_caption=" + txt_menu_edu.Text);
            main_func.add_to_lst_to_file("prj_menu_edu_type=" + combo_menu_edu.Text);
            main_func.add_to_lst_to_file("prj_menu_edu_path=" + txt_menu_edu_path.Text);
            main_func.add_to_lst_to_file("prj_menu_control_caption=" + txt_menu_control.Text);
            main_func.add_to_lst_to_file("prj_menu_control_type=" + combo_menu_control.Text);
            main_func.add_to_lst_to_file("prj_menu_control_path=" + txt_menu_control_path.Text);
            main_func.add_to_lst_to_file("prj_menu_about_caption=" + txt_menu_about.Text);
            main_func.add_to_lst_to_file("prj_menu_about_type=" + combo_menu_about.Text);
            main_func.add_to_lst_to_file("prj_menu_about_path=" + txt_menu_about_path.Text);
            main_func.add_to_lst_to_file("prj_menu_help_type=" + combo_menu_help.Text);
            main_func.add_to_lst_to_file("prj_menu_help_path=" + txt_menu_help_path.Text);
            main_func.add_to_lst_to_file("splash_enabled=" + chk_splash_enabled.Checked.ToString());
            main_func.add_to_lst_to_file("help_enabled=" + chk_help_enabled.Checked.ToString());
            main_func.add_to_lst_to_file("umk_enabled=" + chk_edu_enabled.Checked.ToString());
            main_func.add_to_lst_to_file("test_enabled=" + chk_control_enabled.Checked.ToString());
            main_func.add_to_lst_to_file("about_enabled=" + chk_about_enabled.Checked.ToString());
            main_func.write_to_info_file(prj_folder + prj_name + "\\index.prj"); 
            //write BUILD information
            main_func.clear_lst_to_file();
            main_func.add_to_lst_to_file("prj_is_built=" + prj_IS_built.ToString());
            main_func.add_to_lst_to_file("prj_build_date=" + prj_build_date);
            main_func.write_to_info_file(prj_folder + prj_name + "\\build.info"); 
        }

        public void open_prj(string prj_name)
        {
            clear_form();
            cls_prj prj_func=new cls_prj();
            prj_func.create_prj_dir("distr",prj_name,false);
            prj_func.create_prj_dir("system",prj_name,false);
            cls_main main_func = new cls_main();
            System.Collections.ObjectModel.Collection<string> lst_temp = new System.Collections.ObjectModel.Collection<string>();
            update_list_with_plans();
            //load style list
            System.Collections.ObjectModel.Collection<string> lst_temp3 = new System.Collections.ObjectModel.Collection<string>();
            lst_temp3 = main_func.get_dir(appdir + "Styles\\disk_styles\\");
            lst_disk_styles.Items.Clear();
            if (lst_temp3.Count != 0)
            {
                for (int i = 0; i < lst_temp3.Count; i++)
                {
                    if (File.Exists(appdir + "Styles\\disk_styles\\" + lst_temp3[i].ToString() + "\\style.info"))
                    {
                        lst_disk_styles.Items.Add(lst_temp3[i].ToString());
                    }
                }
            }
            //load prj_file
            System.Collections.ObjectModel.Collection<string> lst_temp1 = new System.Collections.ObjectModel.Collection<string>();
            lst_temp1 = main_func.read_textfile_by_line(prj_folder + prj_name + "\\index.prj");
            if (lst_temp1.Count > 0)
            {
                for (int i = 0; i < lst_temp1.Count; i++)
                {
                    string s_temp = lst_temp1[i].ToString();
                    string[] str_temp = s_temp.Split(Convert.ToChar("="));
                    switch (str_temp[0].ToString())
                    {
                        case "prj_create_date":
                            prj_create_date = str_temp[1].ToString();
                            break;
                        case "prj_disk_name":
                            txt_disk_name.Text = str_temp[1].ToString();
                            break;
                        case "prj_author_name":
                            txt_author_name.Text = str_temp[1].ToString();
                            break;
                        case "prj_splash_path":
                            txt_splash_path.Text = str_temp[1].ToString();
                            break;
                        case "prj_menu_edu_caption":
                            txt_menu_edu.Text = str_temp[1].ToString();
                            break;
                        case "prj_menu_edu_path":
                            txt_menu_edu_path.Text = str_temp[1].ToString();
                            break;
                        case "prj_menu_control_caption":
                            txt_menu_control.Text = str_temp[1].ToString();
                            break;
                        case "prj_menu_control_path":
                            txt_menu_control_path.Text = str_temp[1].ToString();
                            break;
                        case "prj_menu_about_caption":
                            txt_menu_about.Text = str_temp[1].ToString();
                            break;
                        case "prj_menu_about_path":
                            txt_menu_about_path.Text = str_temp[1].ToString();
                            break;
                        case "prj_menu_help_path":
                            txt_menu_help_path.Text = str_temp[1].ToString();
                            break;
                        case "prj_disk_volume_label":
                            textBoxLabel.Text = str_temp[1].ToString();
                            break;
                        case "splash_enabled":
                            if (str_temp[1].ToString()=="True") {
                                chk_splash_enabled.Checked = true;
                            }
                            else
                            {
                                chk_splash_enabled.Checked=false;
                            }
                            break;
                        case "help_enabled":
                            if ( Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                chk_help_enabled.Checked = true;
                            }
                            else
                            {
                                chk_help_enabled.Checked = false;
                            }
                            break;
                        case "umk_enabled":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                chk_edu_enabled.Checked = true;
                            }
                            else
                            {
                                chk_edu_enabled.Checked = false;
                            }
                            break;
                        case "test_enabled":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                chk_control_enabled.Checked = true;
                            }
                            else
                            {
                                chk_control_enabled.Checked = false;
                            }
                            break;
                        case "about_enabled":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                chk_about_enabled.Checked = true;
                            }
                            else
                            {
                                chk_about_enabled.Checked = false;
                            }
                            break;
                        case "prj_splash_type":
                            combo_splash.SelectedItem = str_temp[1].ToString();
                            if (str_temp[1].ToString() == "page" | str_temp[1].ToString() == "image" | str_temp[1].ToString() == "")
                            {
                                btn_add_splash.Visible = true;
                                label23.Text = "Название файла с заставочной картинкой:";
                            }
                            else
                            {
                                btn_add_splash.Visible = false;
                                label23.Text = "URL заставки:";
                            }
                            break;
                        case "prj_menu_help_type":
                            combo_menu_help.SelectedItem = str_temp[1].ToString();
                            if (str_temp[1].ToString() == "page" | str_temp[1].ToString() =="")
                            {
                                btn_add_help_file.Visible = true;
                                label38.Text = "Название файла с  меню:";
                            }
                            else
                            {
                                btn_add_help_file.Visible = false;
                                label38.Text = "URL меню:";
                            }
                            break;
                        case "prj_menu_edu_type":
                            combo_menu_edu.SelectedItem = str_temp[1].ToString();
                            if (str_temp[1].ToString() != "url")
                            {
                                lbl_edu_path.Visible = false;
                                txt_menu_edu_path.Visible = false;
                            }
                            break;
                        case "prj_menu_control_type":
                            combo_menu_control.SelectedItem = str_temp[1].ToString();
                            if (str_temp[1].ToString() != "url")
                            {
                                lbl_control_path.Visible = false;
                                txt_menu_control_path.Visible = false;
                            }
                            break;
                        case "prj_menu_about_type":
                            combo_menu_about.SelectedItem = str_temp[1].ToString();
                            if (str_temp[1].ToString() == "page" | str_temp[1].ToString() == "")
                            {
                                btn_add_about_file.Visible = true;
                                label37.Text = "Название файла с  меню:";
                            }
                            else
                            {
                                btn_add_about_file.Visible = false;
                                label37.Text = "URL меню:";
                            }
                            break;
                        case "prj_create_autorun_inf":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                chk_create_autorun_inf.Checked = true;
                            }
                            else
                            {
                                chk_create_autorun_inf.Checked = false;
                            }
                            break;
                        case "prj_disk_style":
                            disk_style=str_temp[1].ToString();
                            lst_style_preview_list.BeginUpdate();
                            for (int i2 = 0; i2 < lst_disk_styles.Items.Count; i2++)
                            {
                                if (lst_disk_styles.Items[i2].ToString() == disk_style)
                                {
                                    lst_disk_styles.SelectedIndex = i2;
                                }
                            }
                            int selectedIndex = lst_disk_styles.SelectedIndex;
                            if (selectedIndex<0) { selectedIndex=0; };
                            int topIndex = lst_disk_styles.IndexFromPoint(0, 0);
                            lst_disk_styles.TopIndex = topIndex;
                            lst_disk_styles.SetSelected(selectedIndex, false);
                            lst_disk_styles.SetSelected(selectedIndex, true);
                            lst_style_preview_list.EndUpdate();
                            read_style(str_temp[1].ToString());
                            break;

                        case "prj_student_profession":
                            txt_profession.Text = str_temp[1].ToString();
                            break;
                        case "prj_student_specialization":
                            txt_specialization.Text = str_temp[1].ToString();
                            break;
                        case "prj_student_year":
                            txt_year.Text = str_temp[1].ToString();
                            break;
                        case "prj_student_total_year":
                            txt_total_year.Text = str_temp[1].ToString();
                            break;
                        case "prj_copy_service":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                chk_service_enabled.Checked = true;
                            }
                            else
                            {
                                chk_service_enabled.Checked = false;
                            }
                            break;
                        case "prj_create_search":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                chk_search_enabled.Checked = true;
                            }
                            else
                            {
                                chk_search_enabled.Checked = false;
                            }
                            break;
                        case "prj_glass_enabled":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                chk_glass_enabled.Checked = true;
                            }
                            else
                            {
                                chk_glass_enabled.Checked = false;
                            }
                            break;
                        case "prj_ziptests_enabled":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                chk_zip_tests_enabled.Checked = true;
                            }
                            else
                            {
                                chk_zip_tests_enabled.Checked = false;
                            }
                            break;
                        case "prj_convert_files_to":
                            combo_convert_to.SelectedItem = str_temp[1].ToString();
                            break;
                        case "prj_licence":
                            txt_licence_path.Text = str_temp[1].ToString();
                            break;
                        case "prj_licence_enabled":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1].ToString()) == "true")
                            {
                                check_licence.Checked = true;
                            }
                            else
                            {
                                check_licence.Checked = false;
                            }
                            break;
                        case "prj_licence_type":
                            combo_licence.SelectedItem = str_temp[1].ToString();
                            if (str_temp[1].ToString() == "page" | str_temp[1].ToString() == "")
                            {
                                label50.Text = "Название файла с соглашением:";
                                btn_add_licence.Visible = true;
                            }
                            else
                            {
                                label50.Text = "URL соглашения:";
                                btn_add_licence.Visible = false;
                            }
                            break;
                        case "prj_eplan":
                            combo_plans.SelectedItem = str_temp[1].ToString();
                            break;
                    }
                }
            }
            
            //load build information file
            System.Collections.ObjectModel.Collection<string> lst_temp2 = new System.Collections.ObjectModel.Collection<string>();
            lst_temp2 = main_func.read_textfile_by_line(prj_folder + prj_name + "\\build.info");
            if (lst_temp2.Count > 0)
            {
                for (int i = 0; i < lst_temp2.Count; i++)
                {
                    string s_temp = lst_temp2[i].ToString();
                    string[] str_temp = s_temp.Split(Convert.ToChar("="));
                    switch (str_temp[0].ToString())
                    {
                        case "prj_is_built":
                            if (Microsoft.VisualBasic.Strings.LCase(str_temp[1]) == "true") { prj_IS_built = true; } else { prj_IS_built = false; };
                            break;
                        case "prj_build_date":
                            prj_build_date = str_temp[1].ToString();
                            break;
                    }
                }
            }
            if (prj_build_date != "")
            {
                lbl_structurize_build_date.Text = prj_build_date;
                btn_explore_distr.Enabled = true;
            }
            else
            {
                lbl_structurize_build_date.Text = "Никогда";
            }
            if (lst_disk_styles.SelectedIndex >= 0)
            {
                read_style(lst_disk_styles.SelectedItem.ToString());
            }
            pict_save.Enabled = true;
            pict_save.Image = Properties.Resources.save2_n;
            prj_open_name = prj_name;
            if (Directory.Exists(appdir + "system\\service") == false) { chk_service_enabled.Enabled = false; } else { chk_service_enabled.Enabled = true; }
            prj_open = 1;
            tab_prj.Visible = true;
            gb_new_prj.Visible = false;
            gb_open_prj.Visible = false;
            pict_save.Visible = true;
            pict_actions.Visible = true;
            if (File.Exists(prj_folder + prj_name + "\\temp\\autorun\\disk_icon.ico"))
            {
                pic_disk_icon.Load(prj_folder + prj_name + "\\temp\\autorun\\disk_icon.ico");
            }
            else
            {
                pic_disk_icon.Image = null;
            }
        }

        void enableUI(bool enable)
        {
            pic_projects.Enabled = enable;
            pict_actions.Enabled = enable;
            pict_save.Enabled = enable;
            pict_about.Enabled = enable;
            pict_mngr.Enabled = enable;
        }

        public void show_dg_open()
        {
            gb_new_prj.Visible = false;
            tab_prj.Visible = false;
            gb_open_prj.Left = 12;
            gb_open_prj.Top = 48;
            //pict_save.Enabled = false;
            //pict_save.Image = Properties.Resources.save_d;
            //pict_data.Enabled = false;
            //pict_data.Image = Properties.Resources.data_d;
            devicesComboBox.Visible = false;
            label43.Visible = false;
            //pict_actions.Image = Properties.Resources.actions_d;
            //pict_actions.Enabled = false;
            clear_form();


            cls_main main_func = new cls_main();
                System.Collections.ObjectModel.Collection<string> lst_temp = new System.Collections.ObjectModel.Collection<string>();
                lst_temp = main_func.get_dir(prj_folder);
                lst_open_prj.Items.Clear();
                if (lst_temp.Count != 0)
                {
                    for (int i = 0; i < lst_temp.Count; i++)
                    {
                        lst_open_prj.Items.Add(lst_temp[i].ToString());
                    }
                }
            gb_open_prj.Visible = true;
        }

        void show_dg_create()
        {
           
            gb_open_prj.Visible = false;
            txt_prj_name.Text = "";
            lbl_prj_exist_status.Text = "";
            lbl_path.Text = "Директория:";
            prj_exist = true;
            btn_create_prj.Enabled = false;
            gb_new_prj.Left=12;
            gb_new_prj.Top=48;
            gb_new_prj.Visible = true;
            tab_prj.Visible =false;
            tabBurn.Visible = false;
        }

        void resume_prj()
        {
            pict_save.Image = Properties.Resources.save2_n;
            pict_save.Enabled = true;
            tab_prj.Visible = true;
        }

        void clear_form()
        {
            toolTip.SetToolTip(pict_actions, "Действия");
            combo_plans.Text = "";
            chk_service_enabled.Enabled = true;
            chk_service_enabled.Checked = false;
            chk_search_enabled.Checked = false;
            chk_glass_enabled.Checked = false;
            pic_disk_icon.Image = null;
            txt_author_name.Text="";
            lbl_style_desk.Text = "";
            txt_disk_name.Text="";
            txt_menu_about.Text = "";
            txt_menu_about_path.Text = "";
            txt_menu_control.Text = "";
            txt_menu_control_path.Text = "";
            txt_menu_edu.Text = "";
            txt_menu_edu_path.Text = "";
            txt_menu_help_path.Text = "";
            txt_prj_name.Text = "";
            txt_splash_path.Text = "";
            prj_create_date = "";
            //pict_actions.Image = Properties.Resources.actions_d;
            //pict_actions.Enabled = false;
            prj_IS_built = false;
            prj_build_date = "";
            disk_style = "";
            m_isStructurising = false;
            m_isBurning = false;
            m_isFormatting = false;
            lbl_structurize_build_date.Text = "";
            btn_explore_distr.Enabled = false;
            devicesComboBox.Visible = false;
            label43.Visible = false;
            tab_prj.Visible = false;
            tabBurn.Visible = false;
            chk_about_enabled.Checked = false;
            chk_control_enabled.Checked = false;
            chk_edu_enabled.Checked = false;
            chk_help_enabled.Checked = false;
            chk_splash_enabled.Checked = false;
            chk_zip_tests_enabled.Checked = false;
            combo_splash.SelectedIndex = 0;
            combo_convert_to.SelectedIndex = 0;
            combo_menu_help.SelectedIndex =0;
            combo_menu_edu.SelectedIndex = 0;
            combo_menu_control.SelectedIndex = 0;
            combo_menu_about.SelectedIndex = 0;
            btn_add_about_file.Visible = true;
            btn_add_help_file.Visible = true;
            btn_add_splash.Visible = true;
            lbl_style_desk.Text="";
            lbl_style_preview_cap.Visible=false;
            lbl_style_preview_desk.Visible=false;
            lst_style_preview_list.Visible=false;
            txt_profession.Text = "";
            txt_specialization.Text = "";
            txt_year.Text = "";
            txt_total_year.Text = "";
            pict_data.Enabled = false;
            pict_data.Image = Properties.Resources.data_d;
            pict_actions.Image = Properties.Resources.actions_n2;
            pict_actions.Visible = false;
            isBurn_func_show = false;
            pict_save.Visible = false;
        }

        private void btn_create_prj_Click(object sender, EventArgs e)
        {
            if (prj_exist == false && String.IsNullOrEmpty(txt_prj_name.Text) == false)
            {
                prj_open_name = txt_prj_name.Text;
                clear_form();
                cls_prj project = new cls_prj();
                project.create_prj(prj_open_name);
                gb_new_prj.Visible = false;
                open_prj(prj_open_name);
                prj_open = 1;                
            }
            else { MessageBox.Show("Проект с таким именем существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop); };
        }

        private void txt_prj_name_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + txt_prj_name.Text))
            {
                if (txt_prj_name.Text == "")
                {
                    lbl_prj_exist_status.Text = "Укажите имя!";
                }
                else
                {
                    lbl_prj_exist_status.Text = "Проект существует!";
                }
                lbl_prj_exist_status.ForeColor = Color.Red;
                prj_exist = true;
                btn_create_prj.Enabled = false;
            }
            else
            {
                lbl_prj_exist_status.ForeColor = Color.Green;
                prj_exist = false;
                lbl_prj_exist_status.Text = "Ок!";
                lbl_path.Text = "Директория: " + "Projects\\" + txt_prj_name.Text;
                btn_create_prj.Enabled = true;
            };
        }

       
        /// <summary>
        /// Initialize the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            cls_main main_func = new cls_main();
            if (main_func.check_for_components(false))
            {
                if (!File.Exists(appdir + "umk_manager_08.exe")) { pict_mngr.Visible = false; };
                if (Directory.Exists(appdir + "system\\service") == false) { chk_service_enabled.Enabled = false; } else { chk_service_enabled.Enabled = true; }
                main_func.create_registry();
                prj_exist = true;
                umk_folder = main_func.get_value_from_infofile(appdir + "configs\\settings.ini", "umk_folder");
                if (umk_folder == "")
                {
                    MessageBox.Show("УМК не найдены. Запустите УМК Менеджер, чтобы указать правильный путь к директории с УМК.", "УМК не найдены!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    if (Microsoft.VisualBasic.Strings.Right(umk_folder, 1)== "\\")
                    { 
                        umk_folder = Microsoft.VisualBasic.Strings.Left(umk_folder, umk_folder.Length-1);
                    };
                    if (Microsoft.VisualBasic.Strings.Left(umk_folder, 6) == "APPDIR")
                    {
                        umk_folder = main_func.ReplaceAll(umk_folder, "APPDIR\\", appdir);
                    }
                 }
                clear_form();
                show_dg_open();
                if (Environment.OSVersion.Version.Major > 5)
                {
                    MsftDiscMaster2 discMaster = null;
                    try
                    {
                        discMaster = new MsftDiscMaster2();

                        if (!discMaster.IsSupportedEnvironment)
                            return;
                        foreach (string uniqueRecorderID in discMaster)
                        {
                            MsftDiscRecorder2 discRecorder2 = new MsftDiscRecorder2();
                            discRecorder2.InitializeDiscRecorder(uniqueRecorderID);

                            devicesComboBox.Items.Add(discRecorder2);
                        }
                        if (devicesComboBox.Items.Count > 0)
                        {
                            devicesComboBox.SelectedIndex = 0;
                        }
                    }
                    catch (COMException ex)
                    {
                        MessageBox.Show(ex.Message,
                            string.Format("Error:{0} - Пожалуйста, установите IMAPI2", ex.ErrorCode),
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    finally
                    {
                        if (discMaster != null)
                        {
                            Marshal.ReleaseComObject(discMaster);
                        }
                    }
                    //
                    // Create the volume label based on the current date
                    //
                    DateTime now = DateTime.Now;
                    textBoxLabel.Text = now.Year + "_" + now.Month + "_" + now.Day;

                    labelStatusText.Text = string.Empty;
                    labelFormatStatusText.Text = string.Empty;

                    //
                    // Select no verification, by default
                    //
                    comboBoxVerification.SelectedIndex = 0;

                    UpdateCapacity();
                }
                else
                {
                    devicesComboBox.Visible = false;
                    label43.Visible = false;
                    MessageBox.Show("В данной версии ОС некоторые функции программы будут недоступны!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (prj_open == 1)
            {
                DialogResult result = MessageBox.Show("Данное действие приведёт к закрытию текущего проекта. Продолжить?", "Disk Creator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }

  

            
            //
            // Release the disc recorder items
            //
            foreach (MsftDiscRecorder2 discRecorder2 in devicesComboBox.Items)
            {
                if (discRecorder2 != null)
                {
                    Marshal.ReleaseComObject(discRecorder2);
                }
            }
        }



        #region Device ComboBox
        /// <summary>
        /// Selected a new device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void devicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (devicesComboBox.SelectedIndex == -1)
            {
                return;
            }

            IDiscRecorder2 discRecorder =
                (IDiscRecorder2)devicesComboBox.Items[devicesComboBox.SelectedIndex];

            supportedMediaLabel.Text = string.Empty;

            //
            // Verify recorder is supported
            //
            IDiscFormat2Data discFormatData = null;
            try
            {
                discFormatData = new MsftDiscFormat2Data();
                if (!discFormatData.IsRecorderSupported(discRecorder))
                {
                    MessageBox.Show("Данное устройство записи не поддерживается", m_clientName,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StringBuilder supportedMediaTypes = new StringBuilder();
                foreach (IMAPI_MEDIA_PHYSICAL_TYPE mediaType in discFormatData.SupportedMediaTypes)
                {
                    if (supportedMediaTypes.Length > 0)
                        supportedMediaTypes.Append(", ");
                    supportedMediaTypes.Append(GetMediaTypeString(mediaType));
                }
                supportedMediaLabel.Text = supportedMediaTypes.ToString();
            }
            catch (COMException)
            {
                supportedMediaLabel.Text = "Ошибка получения поддерживаемых форматов";
            }
            finally
            {
                if (discFormatData != null)
                {
                    Marshal.ReleaseComObject(discFormatData);
                }
            }
        }

        /// <summary>
        /// converts an IMAPI_MEDIA_PHYSICAL_TYPE to it's string
        /// </summary>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        string GetMediaTypeString(IMAPI_MEDIA_PHYSICAL_TYPE mediaType)
        {
            switch (mediaType)
            {
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_UNKNOWN:
                default:
                    return "Неизвестный тип";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDROM:
                    return "CD-ROM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDR:
                    return "CD-R";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDRW:
                    return "CD-RW";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDROM:
                    return "DVD ROM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDRAM:
                    return "DVD-RAM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR:
                    return "DVD+R";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW:
                    return "DVD+RW";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR_DUALLAYER:
                    return "DVD+R Dual Layer";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR:
                    return "DVD-R";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHRW:
                    return "DVD-RW";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR_DUALLAYER:
                    return "DVD-R Dual Layer";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DISK:
                    return "random-access writes";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW_DUALLAYER:
                    return "DVD+RW DL";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDROM:
                    return "HD DVD-ROM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDR:
                    return "HD DVD-R";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDRAM:
                    return "HD DVD-RAM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDROM:
                    return "Blu-ray DVD (BD-ROM)";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDR:
                    return "Blu-ray media";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDRE:
                    return "Blu-ray Rewritable media";
            }
        }

        /// <summary>
        /// Provides the display string for an IDiscRecorder2 object in the combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void devicesComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            IDiscRecorder2 discRecorder2 = (IDiscRecorder2)e.ListItem;
            string devicePaths = string.Empty;
            string volumePath = (string)discRecorder2.VolumePathNames.GetValue(0);
            foreach (string volPath in discRecorder2.VolumePathNames)
            {
                if (!string.IsNullOrEmpty(devicePaths))
                {
                    devicePaths += ",";
                }
                devicePaths += volumePath;
            }

            e.Value = string.Format("{0} [{1}]", devicePaths, discRecorder2.ProductId);
        }
        #endregion


        #region Media Size

        private void buttonDetectMedia_Click(object sender, EventArgs e)
        {
           check_disk();  
        }

        bool if_thereIS_Disk()
        {
            if (devicesComboBox.SelectedIndex == -1)
            {
                return false;
            }
            IDiscRecorder2 discRecorder =
      (IDiscRecorder2)devicesComboBox.Items[devicesComboBox.SelectedIndex];

            MsftDiscFormat2Data discFormatData = null;

            try
            {
                //
                // Create and initialize the IDiscFormat2Data
                //
                discFormatData = new MsftDiscFormat2Data();
                if (!discFormatData.IsCurrentMediaSupported(discRecorder))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch { return false; }
        }

        void check_disk()
        {
           
            if (devicesComboBox.SelectedIndex == -1)
            {
                return;
            }
            IDiscRecorder2 discRecorder =
      (IDiscRecorder2)devicesComboBox.Items[devicesComboBox.SelectedIndex];

            MsftFileSystemImage fileSystemImage = null;
            MsftDiscFormat2Data discFormatData = null;

            try
            {
                //
                // Create and initialize the IDiscFormat2Data
                //
                discFormatData = new MsftDiscFormat2Data();
                if (!discFormatData.IsCurrentMediaSupported(discRecorder))
                {
                    labelMediaType.Text = "Диск отсутствует!";
                    labelTotalSize.Text = "0 Мб";
                    totalDiscSize = 0;
                    UpdateCapacity();
                    return;
                }
                else
                {
                    //
                    // Get the media type in the recorder
                    //
                    discFormatData.Recorder = discRecorder;
                    IMAPI_MEDIA_PHYSICAL_TYPE mediaType = discFormatData.CurrentPhysicalMediaType;
                    labelMediaType.Text = GetMediaTypeString(mediaType);

                    //
                    // Create a file system and select the media type
                    //
                    fileSystemImage = new MsftFileSystemImage();
                    fileSystemImage.ChooseImageDefaultsForMediaType(mediaType);

                    //
                    // See if there are other recorded sessions on the disc
                    //
                    if (!discFormatData.MediaHeuristicallyBlank)
                    {
                        fileSystemImage.MultisessionInterfaces = discFormatData.MultisessionInterfaces;
                        fileSystemImage.ImportFileSystem();
                    }

                    Int64 freeMediaBlocks = fileSystemImage.FreeMediaBlocks;
                    totalDiscSize = 2048 * freeMediaBlocks;
                }
            }
            catch (COMException exception)
            {
                MessageBox.Show(this, exception.Message, "Обнаружена ошибка диска",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (discFormatData != null)
                {
                    Marshal.ReleaseComObject(discFormatData);
                    discFormatData = null;
                }

                if (fileSystemImage != null)
                {
                    Marshal.ReleaseComObject(fileSystemImage);
                    fileSystemImage = null;
                }
            }
            UpdateCapacity();
        }

        /// <summary>
        /// Updates the capacity progressbar
        /// </summary>
        private void UpdateCapacity()
        {
            //
            // Get the text for the Max Size
            //
             if (totalDiscSize == 0)
            {
                labelTotalSize.Text = "0 Мб";
                progressBarCapacity.Value = 0;
                 return;
            }
            else if (totalDiscSize < 1000000000)
            {
                labelTotalSize.Text = string.Format("{0} Мб", totalDiscSize / 1000000);
            }
            else
            {
                labelTotalSize.Text = string.Format("{0:F2} Гб", (float)totalDiscSize / 1000000000.0);
            }

            //
            // Calculate the size of the files
            //
            Int64 totalMediaSize = 0;
            foreach (IMediaItem mediaItem in listBoxFiles.Items)
            {
                totalMediaSize += mediaItem.SizeOnDisc;
            }

            if (totalMediaSize == 0)
            {
                progressBarCapacity.Value = 0;
                progressBarCapacity.ForeColor = SystemColors.Highlight;
            }
            else
            {
                int percent = (int)((totalMediaSize * 100) / totalDiscSize);
                if (percent > 100)
                {
                    progressBarCapacity.Value = 100;
                    progressBarCapacity.ForeColor = Color.Red;
                }
                else
                {
                    progressBarCapacity.Value = percent;
                    progressBarCapacity.ForeColor = SystemColors.Highlight;
                }
            }
        }

        #endregion


        #region Burn Media Process

        /// <summary>
        /// User clicked the "Burn" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBurn_Click(object sender, EventArgs e)
        {
            if (devicesComboBox.SelectedIndex == -1)
            {
                return;
            }

            if (m_isBurning)
            {
                buttonBurn.Enabled = false;
                backgroundBurnWorker.CancelAsync();
            }
            else
            {
                if (if_thereIS_Disk() == false)
                {
                    MessageBox.Show("В приводе нет диска!", "Нет диска", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                m_isBurning = true;
                EnableBurnUI(false);

                IDiscRecorder2 discRecorder =
                    (IDiscRecorder2)devicesComboBox.Items[devicesComboBox.SelectedIndex];
                m_burnData.uniqueRecorderId = discRecorder.ActiveDiscRecorder;

                backgroundBurnWorker.RunWorkerAsync(m_burnData);
            }
        }

        /// <summary>
        /// The thread that does the burning of the media
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundBurnWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 discRecorder = null;
            MsftDiscFormat2Data discFormatData = null;

            try
            {
                //
                // Create and initialize the IDiscRecorder2 object
                //
                discRecorder = new MsftDiscRecorder2();
                BurnData burnData = (BurnData)e.Argument;
                discRecorder.InitializeDiscRecorder(burnData.uniqueRecorderId);
                discRecorder.AcquireExclusiveAccess(true, m_clientName);

                //
                // Create and initialize the IDiscFormat2Data
                //
                discFormatData = new MsftDiscFormat2Data();
                discFormatData.Recorder = discRecorder;
                discFormatData.ClientName = m_clientName;
                discFormatData.ForceMediaToBeClosed = checkBoxCloseMedia.Checked;

                //
                // Set the verification level
                //
                IBurnVerification burnVerification = (IBurnVerification)discFormatData;
                burnVerification.BurnVerificationLevel = (IMAPI_BURN_VERIFICATION_LEVEL)m_verificationLevel;

                //
                // Check if media is blank, (for RW media)
                //
                object[] multisessionInterfaces = null;
                if (!discFormatData.MediaHeuristicallyBlank)
                {
                    multisessionInterfaces = discFormatData.MultisessionInterfaces;
                }

                //
                // Create the file system
                //
                IStream fileSystem = null;
                if (!CreateMediaFileSystem(discRecorder, multisessionInterfaces, out fileSystem))
                {
                    e.Result = -1;
                    return;
                }

                //
                // add the Update event handler
                //
                discFormatData.Update += new DiscFormat2Data_EventHandler(discFormatData_Update);

                //
                // Write the data here
                //
                try
                {
                    discFormatData.Write(fileSystem);
                    e.Result = 0;
                }
                catch (COMException ex)
                {
                    e.Result = ex.ErrorCode;
                    MessageBox.Show(ex.Message, "Ошибка в процессе записи диска!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    if (fileSystem != null)
                    {
                        Marshal.FinalReleaseComObject(fileSystem);
                    }
                }

                //
                // remove the Update event handler
                //
                discFormatData.Update -= new DiscFormat2Data_EventHandler(discFormatData_Update);

                if (this.checkBoxEject.Checked)
                {
                    discRecorder.EjectMedia();
                }

                discRecorder.ReleaseExclusiveAccess();
            }
            catch (COMException exception)
            {
                //
                // If anything happens during the format, show the message
                //
                //MessageBox.Show(exception.Message);
                e.Result = exception.ErrorCode;
            }
            finally
            {
                if (discRecorder != null)
                {
                    Marshal.ReleaseComObject(discRecorder);
                }

                if (discFormatData != null)
                {
                    Marshal.ReleaseComObject(discFormatData);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="progress"></param>
        void discFormatData_Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress)
        {
            //
            // Check if we've cancelled
            //
            if (backgroundBurnWorker.CancellationPending)
            {
                IDiscFormat2Data format2Data = (IDiscFormat2Data)sender;
                format2Data.CancelWrite();
                return;
            }

            IDiscFormat2DataEventArgs eventArgs = (IDiscFormat2DataEventArgs)progress;

            m_burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING;

            // IDiscFormat2DataEventArgs Interface
            m_burnData.elapsedTime = eventArgs.ElapsedTime;
            m_burnData.remainingTime = eventArgs.RemainingTime;
            m_burnData.totalTime = eventArgs.TotalTime;

            // IWriteEngine2EventArgs Interface
            m_burnData.currentAction = eventArgs.CurrentAction;
            m_burnData.startLba = eventArgs.StartLba;
            m_burnData.sectorCount = eventArgs.SectorCount;
            m_burnData.lastReadLba = eventArgs.LastReadLba;
            m_burnData.lastWrittenLba = eventArgs.LastWrittenLba;
            m_burnData.totalSystemBuffer = eventArgs.TotalSystemBuffer;
            m_burnData.usedSystemBuffer = eventArgs.UsedSystemBuffer;
            m_burnData.freeSystemBuffer = eventArgs.FreeSystemBuffer;

            //
            // Report back to the UI
            //
            backgroundBurnWorker.ReportProgress(0, m_burnData);
        }

        /// <summary>
        /// Completed the "Burn" thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundBurnWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                labelStatusText.Text = "Диск успешно записан!";
            }
            else
            {
                labelStatusText.Text = "Ошибка при записи диска!";
            }
            statusProgressBar.Value = 0;

            m_isBurning = false;
            EnableBurnUI(true);
            buttonBurn.Enabled = true;
            UpdateCapacity();
            enableUI(true);
        }

        /// <summary>
        /// Enables/Disables the "Burn" User Interface
        /// </summary>
        /// <param name="enable"></param>
        void EnableBurnUI(bool enable)
        {
            buttonBurn.Text = enable ? "&Начать запись диска" : "&Отмена";
            buttonDetectMedia.Enabled = enable;

            devicesComboBox.Enabled = enable;
            listBoxFiles.Enabled = enable;

            buttonAddFiles.Enabled = enable;
            buttonAddFolders.Enabled = enable;
            buttonRemoveFiles.Enabled = enable;
            checkBoxEject.Enabled = enable;
            checkBoxCloseMedia.Enabled = enable;
            textBoxLabel.Enabled = enable;
            comboBoxVerification.Enabled = enable;
            if (enable == false)
            {
                label54.Visible = false;
                label55.Visible = false;
                labelMediaType.Visible = false;
                buttonDetectMedia.Visible = false;
                //label3.Visible = false;
                labelTotalSize.Visible = false;
                progressBarCapacity.Visible = false;
                checkBoxCloseMedia.Visible = false;
                checkBoxEject.Visible = false;
                labelVerification.Visible = false;
                comboBoxVerification.Visible = false;
                label57.Visible = false;

                labelStatusText.Visible = true;
                statusProgressBar.Visible = true;
            }
            else
            {
                label54.Visible = true;
                label55.Visible = true;
                labelMediaType.Visible = true;
                buttonDetectMedia.Visible = true;
                //label3.Visible = true;
                labelTotalSize.Visible = true;
                progressBarCapacity.Visible = true;
                checkBoxCloseMedia.Visible = true;
                checkBoxEject.Visible = true;
                labelVerification.Visible = true;
                comboBoxVerification.Visible =true;
                label57.Visible = true;

                labelStatusText.Visible = false;
                statusProgressBar.Visible = false;
            }
            enableUI(enable);
        }

        /// <summary>
        /// Event receives notification from the Burn thread of an event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundBurnWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //int percent = e.ProgressPercentage;
            BurnData burnData = (BurnData)e.UserState;

            if (burnData.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM)
            {
                labelStatusText.Text = burnData.statusMessage;
            }
            else if (burnData.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING)
            {
                switch (burnData.currentAction)
                {
                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VALIDATING_MEDIA:
                        labelStatusText.Text = "Проверка данных...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FORMATTING_MEDIA:
                        labelStatusText.Text = "Идёт форматирование...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_INITIALIZING_HARDWARE:
                        labelStatusText.Text = "Определение оборудования...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_CALIBRATING_POWER:
                        labelStatusText.Text = "Оптимизация лазера...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_WRITING_DATA:
                        long writtenSectors = burnData.lastWrittenLba - burnData.startLba;

                        if (writtenSectors > 0 && burnData.sectorCount > 0)
	                    {
                            int percent = (int)((100 * writtenSectors) / burnData.sectorCount);
                            labelStatusText.Text = string.Format("Прогресс: {0}%", percent);
                            statusProgressBar.Value = percent;
                        }
	                    else
	                    {
                            labelStatusText.Text = "Прогресс 0%";
                            statusProgressBar.Value = 0;
                        }
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FINALIZATION:
                        labelStatusText.Text = "Окончание записи...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_COMPLETED:
                        labelStatusText.Text = "Завершено!";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VERIFYING:
                        labelStatusText.Text = "Проверка";
                        break;
                }
            }
        }

        /// <summary>
        /// Enable the Burn Button if items in the file listbox
        /// </summary>
        private void EnableBurnButton()
        {
            buttonBurn.Enabled = (listBoxFiles.Items.Count > 0);
        }


        #endregion


        #region File System Process
        private bool CreateMediaFileSystem(IDiscRecorder2 discRecorder, object[] multisessionInterfaces, out IStream dataStream)
        {
            MsftFileSystemImage fileSystemImage = null;
            try
            {
                fileSystemImage = new MsftFileSystemImage();
                fileSystemImage.ChooseImageDefaults(discRecorder);
                fileSystemImage.FileSystemsToCreate =
                    FsiFileSystems.FsiFileSystemJoliet | FsiFileSystems.FsiFileSystemISO9660;
                fileSystemImage.VolumeName = textBoxLabel.Text;

                fileSystemImage.Update += new DFileSystemImage_EventHandler(fileSystemImage_Update);

                //
                // If multisessions, then import previous sessions
                //
                if (multisessionInterfaces != null)
                {
                    fileSystemImage.MultisessionInterfaces = multisessionInterfaces;
                    fileSystemImage.ImportFileSystem();
                }



                //
                // Get the image root
                //
                IFsiDirectoryItem rootItem = fileSystemImage.Root;

                //
                // Add Files and Directories to File System Image
                //
                foreach (IMediaItem mediaItem in listBoxFiles.Items)
                {
                    //
                    // Check if we've cancelled
                    //
                    if (backgroundBurnWorker.CancellationPending)
                    {
                        break;
                    }

                    //
                    // Add to File System
                    //
                    mediaItem.AddToFileSystem(rootItem);
                }

                fileSystemImage.Update -= new DFileSystemImage_EventHandler(fileSystemImage_Update);

                //
                // did we cancel?
                //
                if (backgroundBurnWorker.CancellationPending)
                {
                    dataStream = null;
                    return false;
                }

                dataStream = fileSystemImage.CreateResultImage().ImageStream;
            }
            catch (COMException exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка при создании файловой системы", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataStream = null;
                return false;
            }
            finally
            {
                if (fileSystemImage != null)
                {
                    Marshal.ReleaseComObject(fileSystemImage);
                }
            }

	        return true;
        }

        /// <summary>
        /// Event Handler for File System Progress Updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="currentFile"></param>
        /// <param name="copiedSectors"></param>
        /// <param name="totalSectors"></param>
        void fileSystemImage_Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender,
            [In, MarshalAs(UnmanagedType.BStr)]string currentFile, [In] int copiedSectors, [In] int totalSectors)
        {
            int percentProgress = 0;
            if (copiedSectors > 0 && totalSectors > 0)
            {
                percentProgress = (copiedSectors * 100) / totalSectors;
            }

            if (!string.IsNullOrEmpty(currentFile))
            {
                FileInfo fileInfo = new FileInfo(currentFile);
                m_burnData.statusMessage = "Добавление \"" + fileInfo.Name + "\" к проекту...";

                //
                // report back to the ui
                //
                m_burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM;
                backgroundBurnWorker.ReportProgress(percentProgress, m_burnData);
            }

        }
        #endregion


        #region Add/Remove File(s)/Folder(s)

        /// <summary>
        /// Adds a file to the burn list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddFiles_Click(object sender, EventArgs e)
        {
            if (file_dialog.ShowDialog(this) == DialogResult.OK)
            {
                FileItem fileItem = new FileItem(file_dialog.FileName);
                listBoxFiles.Items.Add(fileItem);

                UpdateCapacity();
                EnableBurnButton();
            }
        }

        /// <summary>
        /// Adds a folder to the burn list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddFolders_Click(object sender, EventArgs e)
        {
            if (fldr_dialog.ShowDialog(this) == DialogResult.OK)
            {
                DirectoryItem directoryItem = new DirectoryItem(fldr_dialog.SelectedPath);
                listBoxFiles.Items.Add(directoryItem);

                UpdateCapacity();
                EnableBurnButton();
            }
        }

        /// <summary>
        /// User wants to remove a file or folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveFiles_Click(object sender, EventArgs e)
        {
            IMediaItem mediaItem = (IMediaItem)listBoxFiles.SelectedItem;
            if (mediaItem == null)
                return;

            if (MessageBox.Show("Are you sure you want to remove \"" + mediaItem + "\"?",
                "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listBoxFiles.Items.Remove(mediaItem);

                EnableBurnButton();
                UpdateCapacity();
            }
        }

        #endregion


        #region File ListBox Events
        /// <summary>
        /// The user has selected a file or folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveFiles.Enabled = (listBoxFiles.SelectedIndex != -1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxFiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            IMediaItem mediaItem = (IMediaItem)listBoxFiles.Items[e.Index];
	        if (mediaItem == null)
            {
		        return;
            }

            e.DrawBackground();

	        if ((e.State & DrawItemState.Focus) != 0)
            {
                e.DrawFocusRectangle();
            }

            if (mediaItem.FileIconImage != null)
            {
                e.Graphics.DrawImage(mediaItem.FileIconImage, new Rectangle(4, e.Bounds.Y + 4, 16, 16));
            }

            RectangleF rectF = new RectangleF(e.Bounds.X + 24, e.Bounds.Y,
                e.Bounds.Width - 24, e.Bounds.Height);

            Font font = new Font(FontFamily.GenericSansSerif, 11);

            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.DrawString(mediaItem.ToString(), font, new SolidBrush(e.ForeColor),
                rectF, stringFormat);
        }
        #endregion


        #region Format/Erase the Disc
        /// <summary>
        /// The user has clicked the "Format" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFormat_Click(object sender, EventArgs e)
        {
            if (devicesComboBox.SelectedIndex == -1)
            {
                return;
            }

            if (if_thereIS_Disk() == false)
            {
                MessageBox.Show("В приводе нет диска!", "Нет диска", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            m_isFormatting = true;
            EnableFormatUI(false);

            IDiscRecorder2 discRecorder =
                (IDiscRecorder2)devicesComboBox.Items[devicesComboBox.SelectedIndex];
            backgroundFormatWorker.RunWorkerAsync(discRecorder.ActiveDiscRecorder);
        }

        /// <summary>
        /// Enables/Disables the "Burn" User Interface
        /// </summary>
        /// <param name="enable"></param>
        void EnableFormatUI(bool enable)
        {
            buttonFormat.Enabled = enable;
            checkBoxEjectFormat.Enabled = enable;
            checkBoxQuickFormat.Enabled = enable;
            if (enable == false)
            {
                checkBoxEjectFormat.Visible = false;
                checkBoxQuickFormat.Visible = false;
                label56.Visible = false;

                labelFormatStatusText.Visible = true;
                formatProgressBar.Visible = true;
            }
            else
            {
                checkBoxEjectFormat.Visible = true;
                checkBoxQuickFormat.Visible = true;
                label56.Visible = true;
                labelFormatStatusText.Visible = false;
                formatProgressBar.Visible = false;
            }
            enableUI(enable);
        }

        /// <summary>
        /// Worker thread that Formats the Disc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundFormatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 discRecorder = null;
            MsftDiscFormat2Erase discFormatErase = null;

            try
            {
                //
                // Create and initialize the IDiscRecorder2
                //
                discRecorder = new MsftDiscRecorder2();
                string activeDiscRecorder = (string)e.Argument;
                discRecorder.InitializeDiscRecorder(activeDiscRecorder);
                discRecorder.AcquireExclusiveAccess(true, m_clientName);

                //
                // Create the IDiscFormat2Erase and set properties
                //
                discFormatErase = new MsftDiscFormat2Erase();
                discFormatErase.Recorder = discRecorder;
                discFormatErase.ClientName = m_clientName;
                discFormatErase.FullErase = !checkBoxQuickFormat.Checked;

                //
                // Setup the Update progress event handler
                //
                discFormatErase.Update += new DiscFormat2Erase_EventHandler(discFormatErase_Update);

                //
                // Erase the media here
                //
                try
                {
                    discFormatErase.EraseMedia();
                    e.Result = 0;
                }
                catch (COMException ex)
                {
                    e.Result = ex.ErrorCode;
                    MessageBox.Show(ex.Message, "Ошибка при форматировании!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                //
                // Remove the Update progress event handler
                //
                discFormatErase.Update -= new DiscFormat2Erase_EventHandler(discFormatErase_Update);

                //
                // Eject the media 
                //
                if (checkBoxEjectFormat.Checked)
                {
                    discRecorder.EjectMedia();
                }

                discRecorder.ReleaseExclusiveAccess();
            }
            catch (COMException exception)
            {
                //
                // If anything happens during the format, show the message
                //
               // MessageBox.Show(exception.Message);
            }
            finally
            {
                if (discRecorder != null)
                {
                    Marshal.ReleaseComObject(discRecorder);
                }

                if (discFormatErase != null)
                {
                    Marshal.ReleaseComObject(discFormatErase);
                }
            }
        }

        /// <summary>
        /// Event Handler for the Erase Progress Updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedSeconds"></param>
        /// <param name="estimatedTotalSeconds"></param>
        void discFormatErase_Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender, int elapsedSeconds, int estimatedTotalSeconds)
        {
            IDiscFormat2Erase discFormat2Data = (IDiscFormat2Erase)sender;
            int percent = elapsedSeconds * 100 / estimatedTotalSeconds;
            //
            // Report back to the UI
            //
            backgroundFormatWorker.ReportProgress(percent);
        }

        private void backgroundFormatWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelFormatStatusText.Text = string.Format("Форматирование {0}%...", e.ProgressPercentage);
            formatProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundFormatWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                labelFormatStatusText.Text = "Форматирование завершено!";
            }
            else
            {
                labelFormatStatusText.Text = "Ошибка при форматировании!";
            }

            formatProgressBar.Value = 0;

            m_isFormatting = false;
            EnableFormatUI(true);
            UpdateCapacity();
            enableUI(true);
        }
        #endregion

        /// <summary>
        /// Called when user selects a new tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //
            // Prevent page from changing if we're burning or formatting.
            //
            if (m_isBurning || m_isFormatting || m_isStructurising)
            {
                e.Cancel = true;
            }
        }
        
        /// <summary>
        /// Get the burn verification level when the user changes the selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxVerification_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_verificationLevel = (IMAPI_BURN_VERIFICATION_LEVEL)comboBoxVerification.SelectedIndex;
        }

       private void button2_Click(object sender, EventArgs e)
        {
            gb_new_prj.Visible = false;
        }

       private void btn_new_prj_Click(object sender, EventArgs e)
       {
           if (prj_open == 1)
           {
               DialogResult  result = MessageBox.Show("Данное действие приведёт к закрытию текущего проекта. Продолжить?", "Disk Creator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (result == DialogResult.Yes)
               {
                   show_dg_create();
               }
           }
           else { show_dg_create(); }
       }

       private void add_umk_files_Click(object sender, EventArgs e)
       {
           win_add_umk window_umk = new win_add_umk();
           System.Collections.ObjectModel.Collection<string> return_lst = new System.Collections.ObjectModel.Collection<string>();
           System.Collections.ObjectModel.Collection<string> return_lst1 = new System.Collections.ObjectModel.Collection<string>();
           System.Collections.ObjectModel.Collection<string> return_lst2 = new System.Collections.ObjectModel.Collection<string>();
           cls_main main_func = new cls_main();
           window_umk.change_vars(umk_folder);
           window_umk.ShowDialog();
           if (window_umk.selected_path != "")
           {
               /*if (window_umk.selected_level == 3)
               {
                   string[] row1 = { window_umk.selected_obj, "файл", window_umk.selected_path + "\\" };
                   dg_prj_files.Rows.Add(row1);
               }*/
               if (window_umk.selected_level == 2)
               {
                   string[] row1 = { window_umk.selected_obj, "папка", window_umk.selected_path + "\\" };
                   //dg_prj_files.Rows.Add(row1);
               }
               else
               {
                   if (window_umk.selected_level == 0)
                   {
                       return_lst.Clear();
                       return_lst1.Clear();
                       return_lst = main_func.get_dir(window_umk.selected_path + "\\" + window_umk.selected_obj);
                       if (return_lst.Count > 0)
                       {
                           for (int i = 0; i < return_lst.Count; i++)
                           {
                               return_lst1 = main_func.get_dir(window_umk.selected_path + "\\" + window_umk.selected_obj + "\\" + return_lst[i]);
                               if (return_lst1.Count > 0)
                               {
                                   for (int j = 0; j < return_lst1.Count; j++)
                                   {
                                       string[] row1 = { return_lst1[j], "папка", window_umk.selected_path + "\\" + window_umk.selected_obj + "\\" + return_lst[i] + "\\"};
                                       //dg_prj_files.Rows.Add(row1);
                                   }
                               }
                           }
                       }
                   }
                   else
                   {
                       return_lst.Clear();
                       return_lst = main_func.get_dir(window_umk.selected_path + "\\" + window_umk.selected_obj);
                       if (return_lst.Count > 0)
                       {
                           for (int i = 0; i < return_lst.Count; i++)
                           {
                               string[] row1 = { return_lst[i], "папка", window_umk.selected_path + "\\" + window_umk.selected_obj + "\\" };
                               //dg_prj_files.Rows.Add(row1);
                           }
                       }
                   }
               }
           }
       }

       private void add_other_folder_Click(object sender, EventArgs e)
       {
             cls_main main_func = new cls_main();
             fldr_dialog.ShowNewFolderButton = false;
             fldr_dialog.SelectedPath = "";
             DialogResult result= fldr_dialog.ShowDialog();
             if (result == DialogResult.OK)
             {

                 string[] row1 = { main_func.get_filename(fldr_dialog.SelectedPath), "папка", Microsoft.VisualBasic.Strings.Left(fldr_dialog.SelectedPath,Microsoft.VisualBasic.Strings.Len(fldr_dialog.SelectedPath)- Microsoft.VisualBasic.Strings.Len(main_func.get_filename(fldr_dialog.SelectedPath))      )  };
                 //dg_prj_files.Rows.Add(row1);

                 //System.Collections.ObjectModel.Collection<string> lst_temp = new System.Collections.ObjectModel.Collection<string>();
                 //lst_temp = main_func.get_dir(fldr_dialog.SelectedPath);
                 //if (lst_temp.Count != 0)
                // {



                    // if (lst_temp.Count > 1)
                    // {
                        // string[] row2 = { main_func.get_filename(lst_temp[0].ToString()), "папка", fldr_dialog.SelectedPath  };
                       //  dg_prj_files.Rows.Add(row2);



                        // for (int i = 0; i < lst_temp.Count; i++)
                        // {
                         //    string[] row1 = { lst_temp[i].ToString(), "папка", fldr_dialog.SelectedPath  };
                        //     dg_prj_files.Rows.Add(row1);
                        // }



                    // }


                        // if (dg_prj_files.Rows.Count > 0)
                        // {
                        //     DirectoryItem directoryItem = new DirectoryItem(fldr_dialog.SelectedPath);
                        //     listBoxFiles.Items.Add(directoryItem);
                         //    UpdateCapacity();
                         //    EnableBurnButton();
                        // }
                // }
             }
       }

       private void add_other_files_Click(object sender, EventArgs e)
       {
           cls_main main_func = new cls_main();
           file_dialog.Title = "Добавление файла";
           file_dialog.DefaultExt = "*.*";
           DialogResult result = file_dialog.ShowDialog();
           if (result == DialogResult.OK)
           {
               string[] row1 = { main_func.get_filename(file_dialog.FileName), "файл", main_func.get_path(file_dialog.FileName) };
              // dg_prj_files.Rows.Add(row1);
           }
       }

       private void btn_open_prj_Click(object sender, EventArgs e)
       {
           
       }

       private void btn_gb_open_close_Click(object sender, EventArgs e)
       {
           if (prj_open == 1)
           {
               resume_prj();
           }
           gb_open_prj.Visible = false;
       }

       private void btn_dg_create_close_Click(object sender, EventArgs e)
       {
           //if (prj_open == 1)
           //{
           //    resume_prj();
          // }
           gb_new_prj.Visible = false;
           show_dg_open();
       }

       private void btn_gbopen_delete_prj_Click(object sender, EventArgs e)
       {
           if (Microsoft.VisualBasic.Strings.Len(lst_open_prj.SelectedItem.ToString()) > 0)
           {
               DialogResult result = MessageBox.Show("Вы действительно хотите удалить проект " + lst_open_prj.SelectedItem.ToString() + "?", "Удаление проекта", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (result== DialogResult.Yes)
               {
                   Directory.Delete(prj_folder + "\\" + lst_open_prj.SelectedItem.ToString(), true);
                   lst_open_prj.Items.Remove(lst_open_prj.SelectedItem);
               }
           }
       }

       private void btn_prj_open_Click(object sender, EventArgs e)
       {
           if (lst_open_prj.SelectedItems.Count> 0)
           {
               open_prj(lst_open_prj.SelectedItem.ToString());
           }
       }

       private void lst_open_prj_DoubleClick(object sender, EventArgs e)
       {
           //if (Microsoft.VisualBasic.Strings.Len(lst_open_prj.SelectedItem.ToString()) > 0)
           if (lst_open_prj.SelectedIndex>=0)
           {
               open_prj(lst_open_prj.SelectedItem.ToString());
           }
       }

       private void btn_burn_Click(object sender, EventArgs e)
       {
          
       }

       private void btn_delete_element_Click(object sender, EventArgs e)
       {
           //if (dg_prj_files.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
           //{
               //if (dg_prj_files.SelectedRows[0].Cells[0].Value.ToString() != "")
               //{
                   //dg_prj_files.Rows.Remove(dg_prj_files.SelectedRows[0]);
               //}
           //}
       }

       private void btn_back_to_prj_Click(object sender, EventArgs e)
       {
           
       }

       private void textBox2_TextChanged(object sender, EventArgs e)
       {

       }

       private void textBox2_TextChanged_1(object sender, EventArgs e)
       {

       }

       private void tabSettings_Click(object sender, EventArgs e)
       {

       }

       private void button2_Click_1(object sender, EventArgs e)
       {
           tabPageBurn.IsAccessible = false;
           

       }

       private void tabBurn_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (prj_IS_built == false)
           {
              tabBurn.SelectedTab = tabPRJCreate;
              MessageBox.Show("Создайте сначала структуру проекта!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           }
           if (Environment.OSVersion.Version.Major < 6)
           {
               tabBurn.SelectedTab = tabPRJCreate;
           }

       }

       private void btn_start_structurising_Click(object sender, EventArgs e)
       {
           if (m_isStructurising == true)
           {
               m_isStructurising = false;
               backgroundStructurWorker.CancelAsync();
               btn_start_structurising.Enabled = false;
               enableUI(true);
               EnableStructurUI(true);
              btn_start_structurising.Enabled = true;
           }
           else
           {
               if (!backgroundStructurWorker.IsBusy)
               {
                   prepare_for_structur();
                   btn_start_structurising.Enabled = false;
                   EnableStructurUI(false);
                   backgroundStructurWorker.RunWorkerAsync();
                   enableUI(false);
                   m_isStructurising = true;
               }
           }
       }

       void EnableStructurUI(bool visible)
       {
           if (visible == true)
           {
               progressStructur.Visible = false;
               labelStructur_status.Visible = false;
               if (prj_IS_built)
               {
                   btn_explore_distr.Enabled = true;
               }
               else
               {
                   btn_explore_distr.Enabled = false;
               }
               label28.Visible = true;
               lbl_structurize_build_date.Visible = true;
               btn_explore_distr.Visible = true;
               btn_start_structurising.Text = "&Создать структуру";
               btn_start_structurising.Enabled = true;
               enableUI(true);
           }
           else
           {
               progressStructur.Visible = true;
               labelStructur_status.Visible = true;
               labelStructur_status.Text = "0%"; 

               label28.Visible =false;
               lbl_structurize_build_date.Visible = false;
               btn_explore_distr.Visible = false;
               //btn_start_structurising.Text = "&Отменить";
               enableUI(false);
           }

       }

       private void btn_explore_distr_Click(object sender, EventArgs e)
       {
           Process.Start(appdir + "Projects\\" + prj_open_name + "\\distr\\");
       }

       private void checkBox2_CheckedChanged(object sender, EventArgs e)
       {

       }

       private void textBox4_TextChanged(object sender, EventArgs e)
       {

       }

       private void btn_add_splash_Click(object sender, EventArgs e)
       {
           cls_main main_func = new cls_main();
           if (combo_splash.Text == "image")
           {
               file_dialog.Title = "Укажите файл с картинкой";
               file_dialog.DefaultExt = "*.png";
               file_dialog.Filter = "PNG файлы (*.png)|*.png|JPEG файлы (*.jpg)|*.jpg";
           }
           else
           {
               file_dialog.Title = "Укажите файл со страницей";
               file_dialog.DefaultExt = "*.htm";
               file_dialog.Filter = "HTML страница (*.htm)|*.htm|HTML страница (*.html)|*.html";
           };
           DialogResult result = file_dialog.ShowDialog();
           if (result == DialogResult.OK)
           {
               if (combo_splash.Text == "image")
               {
                   File.Copy(file_dialog.FileName, appdir + "Projects\\" + prj_open_name + "\\temp\\splash\\splash." + main_func.get_extention(file_dialog.FileName), true);
               }
               else
               {
                   File.Copy(file_dialog.FileName, appdir + "Projects\\" + prj_open_name + "\\temp\\splash\\splash." + main_func.get_extention(file_dialog.FileName), true);
                   main_func.DirectoryCopy(main_func.get_path(file_dialog.FileName) + main_func.get_filename_without_ex(file_dialog.FileName) + "_files", appdir + "Projects\\" + prj_open_name + "\\temp\\splash\\splash_files", true);
               }
               txt_splash_path.Text = "splash." + main_func.get_extention(file_dialog.FileName);
           }
       }

       private void combo_splash_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (combo_splash.Text == "page" | combo_splash.Text == "image")
           {
               btn_add_splash.Visible = true;
               label23.Text = "Название файла с заставочной картинкой:";
           }
           else
           {
               btn_add_splash.Visible = false;
               label23.Text = "URL заставки:";
               txt_splash_path.Text = "http://";
           }
       }

       private void combo_menu_help_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (combo_menu_help.Text == "page")
           {
               btn_add_help_file.Visible = true;
               label38.Text = "Название файла с  меню:";
           }
           else
           {
               btn_add_help_file.Visible = false;
               label38.Text = "URL меню:";
               txt_menu_help_path.Text = "http://";
           }
       }

       private void btn_add_help_file_Click(object sender, EventArgs e)
       {
           cls_main main_func = new cls_main();
               file_dialog.Title = "Укажите файл со страницей";
               file_dialog.DefaultExt = "*.htm";
               file_dialog.Filter = "HTML страница (*.htm)|*.htm|HTML страница (*.html)|*.html";
           DialogResult result = file_dialog.ShowDialog();
           if (result == DialogResult.OK)
           {
               main_func.DirectoryCopy(main_func.get_path(file_dialog.FileName) + main_func.get_filename_without_ex(file_dialog.FileName) + "_files", appdir + "Projects\\" + prj_open_name + "\\temp\\help\\help_files", true);
               File.Copy(file_dialog.FileName, appdir + "Projects\\" + prj_open_name + "\\temp\\help\\help." + main_func.get_extention(file_dialog.FileName), true);
               txt_menu_help_path.Text = "help." + main_func.get_extention(file_dialog.FileName);
               main_func.replace_in_file(main_func.get_filename_without_ex(file_dialog.FileName) + "_files/", "help_files/", appdir + "Projects\\" + prj_open_name + "\\temp\\help\\help." + main_func.get_extention(file_dialog.FileName));
           }
       }

       private void combo_menu_about_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (combo_menu_about.Text == "page")
           {
               btn_add_about_file.Visible = true;
               label37.Text = "Название файла с  меню:";
           }
           else
           {
               btn_add_about_file.Visible = false;
               label37.Text = "URL меню:";
               txt_menu_about_path.Text = "http://";
           }
       }

       private void btn_add_about_file_Click(object sender, EventArgs e)
       {
           cls_main main_func = new cls_main();
           file_dialog.Title = "Укажите файл со страницей";
           file_dialog.DefaultExt = "*.htm";
           file_dialog.Filter = "HTML страница (*.htm)|*.htm|HTML страница (*.html)|*.html";
           DialogResult result = file_dialog.ShowDialog();
           if (result == DialogResult.OK)
           {
               main_func.DirectoryCopy(main_func.get_path(file_dialog.FileName) + main_func.get_filename_without_ex(file_dialog.FileName) + "_files", appdir + "Projects\\" + prj_open_name + "\\temp\\about\\about_files", true);
               File.Copy(file_dialog.FileName, appdir + "Projects\\" + prj_open_name + "\\temp\\about\\about." + main_func.get_extention(file_dialog.FileName), true);
               txt_menu_about_path.Text = "about." + main_func.get_extention(file_dialog.FileName);
               main_func.replace_in_file(main_func.get_filename_without_ex(file_dialog.FileName) + "_files/", "about_files/", appdir + "Projects\\" + prj_open_name + "\\temp\\about\\about." + main_func.get_extention(file_dialog.FileName));
           }
       }

       private void lst_disk_styles_Click(object sender, EventArgs e)
       {
           //if (Microsoft.VisualBasic.Strings.Len(lst_open_prj.SelectedItem.ToString()) > 0)
           if (lst_disk_styles.SelectedIndex >= 0)
           {
               read_style(lst_disk_styles.SelectedItem.ToString());
           }
       }

       void read_style(string style_name)
       {
           cls_main main_func= new cls_main();
           lbl_style_preview_desk.Visible = false;
           lbl_style_preview_cap.Visible = false;
           lst_style_preview_list.Visible = false;
           System.Collections.ObjectModel.Collection<string> lst_temp1 = new System.Collections.ObjectModel.Collection<string>();
                lst_temp1 = main_func.read_textfile_by_line(appdir + "Styles\\disk_styles\\" + style_name + "\\previews.info");
                if (lst_temp1.Count > 0)
                {
                    lst_style_preview_filename.Clear();
                    lst_style_preview_list.Items.Clear();
                    lbl_style_preview_desk.Visible=true;
                    lbl_style_preview_cap.Visible=true;
                    lst_style_preview_list.Visible=true;
                    for (int i = 0; i < lst_temp1.Count; i++)
                    {
                        string s_temp = lst_temp1[i].ToString();
                        string[] str_temp = s_temp.Split(Convert.ToChar("|"));
                        lst_style_preview_list.Items.Add(str_temp[0].ToString());
                        lst_style_preview_filename.Add(main_func.ReplaceAll(str_temp[1].ToString()," ",""));
                    }
                }
           //
                System.Collections.ObjectModel.Collection<string> lst_temp2 = new System.Collections.ObjectModel.Collection<string>();
                lst_temp2 = main_func.read_textfile_by_line(appdir + "Styles\\disk_styles\\" + style_name + "\\style.info");
                if (lst_temp2.Count > 0)
                {
                    string name = "";
                    string date = "";
                    string author = "";
                    string desc = "";
                    for (int i = 0; i < lst_temp2.Count; i++)
                    {
                        string s_temp = lst_temp2[i].ToString();
                        string[] str_temp = s_temp.Split(Convert.ToChar("="));
                        switch (str_temp[0].ToString())
                        {
                            case "name":
                                name = str_temp[1].ToString();
                                break;
                            case "date":
                                date = str_temp[1].ToString();
                                break;
                            case "author":
                                author = str_temp[1].ToString();
                                break;
                            case "description":
                                desc = str_temp[1].ToString();
                                break;
                        }
                    }
                    lbl_style_desk.Text = name + " [" + date + "]" + "\n" + "Автор: " + author + "\n" + "Описание: " + desc;
                }
                else
                {
                    lbl_style_desk.Text = "Описание отсутствует.";
                }
                disk_style = style_name;
       }

       private void lst_style_preview_list_DoubleClick(object sender, EventArgs e)
       {
           if (lst_style_preview_list.SelectedIndex >= 0)
           {
               frm_show_picture show_picture = new frm_show_picture();
               show_picture.load_picture(appdir + "Styles\\disk_styles\\" + disk_style + "\\previews\\" + lst_style_preview_filename[lst_style_preview_list.SelectedIndex]);
               show_picture.ShowDialog();
           }
       }

       private void label37_Click(object sender, EventArgs e)
       {

       }

       private void combo_menu_edu_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (combo_menu_edu.Text != "url")
           {
               lbl_edu_path.Visible = false;
               txt_menu_edu_path.Visible = false;
           }
           else
           {
               lbl_edu_path.Visible = true;
               txt_menu_edu_path.Visible = true;
               txt_menu_edu_path.Text = "http://";
           }
       }

       private void combo_menu_control_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (combo_menu_control.Text != "url")
           {
               lbl_control_path.Visible = false;
               txt_menu_control_path.Visible = false;
           }
           else
           {
               lbl_control_path.Visible = true;
               txt_menu_control_path.Visible = true;
               txt_menu_control_path.Text = "http://";
           }
       }

       private void pic_projects_Click(object sender, EventArgs e)
       {
           if (m_isBurning || m_isFormatting || m_isStructurising)
           {
               MessageBox.Show("Невозможно выполнить! Остановите сначало текущий процесс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
               if (prj_open == 1)
               {
                   DialogResult result = MessageBox.Show("Данное действие приведёт к закрытию текущего проекта. Продолжить?", "Disk Creator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (result == DialogResult.Yes)
                   {
                       show_dg_open();
                       prj_open = 0;
                   }
               }
               else { show_dg_open(); }
           }
       }

       private void pic_projects_MouseEnter(object sender, EventArgs e)
       {
           pic_projects.Image = Properties.Resources.projects_m;
       }

       private void pic_projects_MouseLeave(object sender, EventArgs e)
       {
           pic_projects.Image = Properties.Resources.projects_n;
       }

       private void pict_save_MouseEnter(object sender, EventArgs e)
       {
           pict_save.Image = Properties.Resources.save2_m;
       }

       private void pict_save_MouseLeave(object sender, EventArgs e)
       {
           pict_save.Image = Properties.Resources.save2_n;
       }

       private void pict_save_Click(object sender, EventArgs e)
       {
           if (m_isBurning || m_isFormatting || m_isStructurising)
           {
               MessageBox.Show("Невозможно выполнить! Остановите сначало текущий процесс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
               if (prj_open == 1) { save_project(prj_open_name); };
           }
       }

       private void pict_exit_Click(object sender, EventArgs e)
       {
           Application.Exit();
       }

       private void pict_exit_MouseEnter(object sender, EventArgs e)
       {
           pict_exit.Image = Properties.Resources.exit_m2;
       }

       private void pict_exit_MouseLeave(object sender, EventArgs e)
       {
           pict_exit.Image = Properties.Resources.exit_n2;
       }

       private void pict_about_Click(object sender, EventArgs e)
       {
           if (m_isBurning || m_isFormatting || m_isStructurising)
           {
               MessageBox.Show("Невозможно выполнить! Остановите сначало текущий процесс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
               developers_components_lib.cls_about_dlg about_frm = new developers_components_lib.cls_about_dlg();
               about_frm.show_dlg("Disc Creator", "Версия: " + Application.ProductVersion.ToString(), "RTM", "Мастер создания дисков ЭУМК (Disc Creator) - программа для создания дисков с ЭУМК. Для работы программы требуется установленный УМК Менеджер." + "\n\n" + "С помощью внутренних стилей и профилей возможна работа данной программы в любом высшем учебном заведении. \n\nВсе материалы (файлы) созданные или отредатированные в этой программе принадлежат их владельцам. Автор не несёт ответственности за содержание этих файлов.", pict_logo.Image, appdir + "help\\licence_disk.html", "","umk_mngr",0,false);
           }
       }

       private void pict_about_MouseEnter(object sender, EventArgs e)
       {
           pict_about.Image = Properties.Resources.about_m2;
       }

       private void pict_about_MouseLeave(object sender, EventArgs e)
       {
           pict_about.Image = Properties.Resources.about_n2;
       }

       private void pict_help_Click(object sender, EventArgs e)
       {
           Process.Start("http://dsoft.studenthost.ru/help_small.aspx?app_code=diskcreator");
       }

       private void pict_help_MouseEnter(object sender, EventArgs e)
       {
           pict_help.Image = Properties.Resources.help_m;
       }

       private void pict_help_MouseLeave(object sender, EventArgs e)
       {
           pict_help.Image = Properties.Resources.help_n;
       }

       private void pict_feedback_Click(object sender, EventArgs e)
       {
           Process.Start("http://dsoft.studenthost.ru/feedback.aspx");
       }

       private void pict_feedback_MouseEnter(object sender, EventArgs e)
       {
           pict_feedback.Image = Properties.Resources.feedback_m;
       }

       private void pict_feedback_MouseLeave(object sender, EventArgs e)
       {
           pict_feedback.Image = Properties.Resources.feedback_n;
       }

       private void pict_data_Click(object sender, EventArgs e)
       {
           if (m_isBurning || m_isFormatting || m_isStructurising)
           {
               MessageBox.Show("Невозможно выполнить! Остановите сначало текущий процесс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
               tabBurn.Visible = false;
               tab_prj.Visible = true;
               pict_data.Enabled = false;
               pict_data.Refresh();
               pict_data.Image = Properties.Resources.data_d;
               pict_data.Refresh();
               pict_actions.Image = Properties.Resources.actions_n;
               pict_actions.Enabled = true;
               devicesComboBox.Visible = false;
               label43.Visible = false;
           }
       }

       private void pict_data_MouseEnter(object sender, EventArgs e)
       {
           pict_data.Image = Properties.Resources.data_m;
       }

       private void pict_data_MouseLeave(object sender, EventArgs e)
       {
           if (pict_data.Enabled == false)
           {
               pict_data.Image = Properties.Resources.data_d;
           }
           else
           {
               pict_data.Image = Properties.Resources.data_n;
           }
       }

       private void pict_actions_Click(object sender, EventArgs e)
       {
           if (m_isBurning || m_isFormatting || m_isStructurising)
           {
               MessageBox.Show("Невозможно выполнить! Остановите сначало текущий процесс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
               if (isBurn_func_show == false)
               {
                   if (File.Exists(plans_dir + "\\" + combo_plans.Text)==true)
                   {
                       toolTip.SetToolTip(pict_actions, "Данные");
                       tabBurn.Visible = true;
                       tab_prj.Visible = false;
                       //pict_data.Enabled = true;
                      // pict_data.Image = Properties.Resources.data_n;
                       if (Environment.OSVersion.Version.Major < 6)
                       {
                           devicesComboBox.Visible = false;
                           label43.Visible = false;
                       }
                       else
                       {
                           devicesComboBox.Visible = true;
                           label43.Visible = true;
                       }
                      // pict_actions.Image = Properties.Resources.actions_d;
                       //pict_actions.Enabled = false;
                       //
                       //Add files_folders to listBoxFiles
                       //
                       add_prj_to_listboxfiles();
                       isBurn_func_show = true;
                       pict_actions.Image = Properties.Resources.data_n2;
                       check_disk();
                   }
                   else
                   {
                       MessageBox.Show("Вы не выбрали учебный план", "Учебный план!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   }
               }
               else
               {
                   isBurn_func_show = false;
                   tabBurn.Visible = false;
                   tab_prj.Visible = true;
                   toolTip.SetToolTip(pict_actions, "Действия");
                  // pict_data.Enabled = false;
                   //pict_data.Refresh();
                   //pict_data.Image = Properties.Resources.data_d;
                   //pict_data.Refresh();
                   //pict_actions.Image = Properties.Resources.actions_n;
                   //pict_actions.Enabled = true;
                   devicesComboBox.Visible = false;
                   label43.Visible = false;
                   pict_actions.Image = Properties.Resources.actions_n2;
               }
           }
       }

       private void pict_actions_MouseEnter(object sender, EventArgs e)
       {
           if (isBurn_func_show == false)
           {
               pict_actions.Image = Properties.Resources.actions_m2;
           }
           else
           {
               pict_actions.Image = Properties.Resources.data_m2;
           }
       }

       private void pict_actions_MouseLeave(object sender, EventArgs e)
       {
           //if (pict_actions.Enabled == false)
           //{
           //    pict_actions.Image = Properties.Resources.actions_d;
           //}
           //else
           //{
               pict_actions.Image = Properties.Resources.actions_n;
          // }
               if (isBurn_func_show == false)
               {
                   pict_actions.Image = Properties.Resources.actions_n2;
               }
               else
               {
                   pict_actions.Image = Properties.Resources.data_n2;
               }
       }

       private void label19_Click(object sender, EventArgs e)
       {

       }

       private void textBox2_TextChanged_2(object sender, EventArgs e)
       {

       }

       private void pic_curriculum_Click(object sender, EventArgs e)
       {
           if (m_isBurning || m_isFormatting || m_isStructurising)
           {
               MessageBox.Show("Невозможно выполнить! Остановите сначало текущий процесс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
               if (prj_open == 1)
               {
                   DialogResult result = MessageBox.Show("Данное действие приведёт к закрытию текущего проекта. Продолжить?", "Disk Creator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (result == DialogResult.Yes)
                   {
                       //show_dg_open();
                       //prj_open = 0;
                   }
               }
               //else { show_dg_open(); }
           }
       }

       private void pic_curriculum_MouseEnter(object sender, EventArgs e)
       {
           pic_curriculum.Image = Properties.Resources.curriculum_m;
       }

       private void pic_curriculum_MouseLeave(object sender, EventArgs e)
       {
           pic_curriculum.Image = Properties.Resources.curriculum_n;
       }

       private void btn_delete_disk_icon_Click(object sender, EventArgs e)
       {
           pic_disk_icon.Image = null;
       }

       private void btn_add_disk_icon_Click(object sender, EventArgs e)
       {
           cls_main main_func = new cls_main();
               file_dialog.Title = "Укажите файл с иконкой";
               file_dialog.DefaultExt = "*.ico";
               file_dialog.Filter = "ICO файлы (*.ico)|*.ico";
           DialogResult result = file_dialog.ShowDialog();
           if (result == DialogResult.OK)
           {
               File.Copy(file_dialog.FileName, appdir + "Projects\\" + prj_open_name + "\\temp\\autorun\\disk_icon.ico", true);
               pic_disk_icon.Load(prj_folder + prj_open_name + "\\temp\\autorun\\disk_icon.ico");
           }
       }

       private void label8_Click(object sender, EventArgs e)
       {

       }

       private void btn_open_pans_Click(object sender, EventArgs e)
       {
           win_plans windows_plans = new win_plans();
           windows_plans.umk_folder = umk_folder;
           windows_plans.ShowDialog();
           //update_list_with_pans();
       }

       private void combo_licence_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (combo_licence.Text == "page")
           {
               label50.Text = "Название файла с соглашением:";
               btn_add_licence.Visible = true;
           }
           else
           {
               label50.Text = "URL соглашения:";
               btn_add_licence.Visible = false;
               txt_licence_path.Text = "http://";
           }
       }

       private void btn_add_licence_Click(object sender, EventArgs e)
       {
           cls_main main_func = new cls_main();
           file_dialog.Title = "Укажите файл со страницей";
           file_dialog.DefaultExt = "*.htm";
           file_dialog.Filter = "HTML страница (*.htm)|*.htm|HTML страница (*.html)|*.html";
           DialogResult result = file_dialog.ShowDialog();
           if (result == DialogResult.OK)
           {
               main_func.DirectoryCopy(main_func.get_path(file_dialog.FileName) + main_func.get_filename_without_ex(file_dialog.FileName) + "_files", appdir + "Projects\\" + prj_open_name + "\\temp\\licence\\licence_files", true);
               File.Copy(file_dialog.FileName, appdir + "Projects\\" + prj_open_name + "\\temp\\licence\\licence." + main_func.get_extention(file_dialog.FileName), true);
               txt_licence_path.Text = "licence." + main_func.get_extention(file_dialog.FileName);
               main_func.replace_in_file(main_func.get_filename_without_ex(file_dialog.FileName) + "_files/", "licence_files/", appdir + "Projects\\" + prj_open_name + "\\temp\\licence\\licence." + main_func.get_extention(file_dialog.FileName));
           }

       }

       private void btn_show_plan_window_Click(object sender, EventArgs e)
       {
           win_plans windows_plans = new win_plans();
           windows_plans.umk_folder = umk_folder;
           windows_plans.ShowDialog();     
           update_list_with_plans();
       }

       private void backgroundStructurWorker_DoWork(object sender, DoWorkEventArgs e)
       {
           try
           {         
               //start_create_structure();
               m_isStructurising = true;
               string temp_str = "";
               developers_components_lib.cls_filesystem filesys_func = new developers_components_lib.cls_filesystem();
               developers_components_lib.cls_converter convert_func = new developers_components_lib.cls_converter();
               cls_prj prj_func = new cls_prj();
               cls_main main_func = new cls_main();
               System.Collections.ObjectModel.Collection<string> db_files = new System.Collections.ObjectModel.Collection<string>();
               System.Collections.ObjectModel.Collection<string> db_temp_list = new System.Collections.ObjectModel.Collection<string>();
               System.Collections.ObjectModel.Collection<string> lst_files = new System.Collections.ObjectModel.Collection<string>();
               System.Collections.ObjectModel.Collection<string> lst_plan = new System.Collections.ObjectModel.Collection<string>();
               System.Collections.ObjectModel.Collection<string> lst_eplan_rows = new System.Collections.ObjectModel.Collection<string>();
               lst_plan = open_plan(s_plan_name);
               db_files.Clear();
               prj_func.create_prj_dir("distr", prj_open_name, true);
               string control_template = main_func.read_all_file(appdir + "Styles\\disk_styles\\" + disk_style + "\\control\\index.htm");
               string control_row_template = main_func.read_all_file(appdir + "Styles\\disk_styles\\" + disk_style + "\\control\\row_template.htm");
               string control_rows_str = "";
               string umk_row_year_template = main_func.read_all_file(appdir + "Styles\\disk_styles\\" + disk_style + "\\umk\\row_year.htm");
               string umk_row_year_temp_str = "";
               string umk_rows_str = "";
               string umk_final_rows_str = "";
               string sub_umk_rows_str = "";
               string sub_umk_template_temp = "";
               string subumk_template = main_func.read_all_file(appdir + "Styles\\disk_styles\\" + disk_style + "\\umk\\sub_umk.htm");
               string subumk_row_template = main_func.read_all_file(appdir + "Styles\\disk_styles\\" + disk_style + "\\umk\\subumk_row_template.htm");
               string umk_template = main_func.read_all_file(appdir + "Styles\\disk_styles\\" + disk_style + "\\umk\\index.htm");
               string umk_row_template = main_func.read_all_file(appdir + "Styles\\disk_styles\\" + disk_style + "\\umk\\row_template.htm");
               //
               //copying system files
               //
               backgroundStructurWorker.ReportProgress(10);
               if (chk_service_enabled.Enabled == true & chk_service_enabled.Checked == true) { main_func.DirectoryCopy(appdir + "system\\service", appdir + "Projects\\" + prj_open_name + "\\distr\\SERVICE", true); }
               main_func.DirectoryCopy(appdir + "system\\umk", appdir + "Projects\\" + prj_open_name + "\\distr\\", true);
               //
               //copying UMK FILES
               //
               backgroundStructurWorker.ReportProgress(20);
               if (lst_plan.Count > 0)
               {
                   //create test
                   if ( s_control_type == "page")
                   {
                       main_func.DirectoryCopy(appdir + "Styles\\disk_styles\\" + disk_style + "\\control\\files", appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\control\\", true);
                       control_template = control_template.Replace("{CAPTION}", txt_menu_control.Text);
                   }
                   //create education 
                   if (s_edu_type == "page")
                   {
                       main_func.DirectoryCopy(appdir + "Styles\\disk_styles\\" + disk_style + "\\umk\\files", appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\", true);
                       umk_template = umk_template.Replace("{SPECIALIZATION}", txt_specialization.Text);
                       umk_template = umk_template.Replace("{all_years}", txt_total_year.Text);
                       //umk_template = umk_template.Replace("{SPECIALIZATION}", txt_specialization.Text);
                       //umk_template = umk_template.Replace("{SPECIALIZATION}", txt_specialization.Text);
                   }
                   main_func.clear_lst_to_file();
                   main_func.add_to_lst_to_file("version=" + shell_search_db_version);
                   string type = "";
                   int n = 0;
                   int Col = 0;
                   string umk_name = "";
                   backgroundStructurWorker.ReportProgress(30);
                   for (int h = 0; h < 7; h++)
                   {
                       Col = 0;
                       for (int i = 0; i < lst_plan.Count; i++)
                       {
                           string ss = lst_plan[i];
                           string[] plan_data = ss.Split(Convert.ToChar(";"));
                           if (plan_data[3] == h.ToString())
                           {
                               lst_files.Clear();
                               lst_files = main_func.get_files_indir(umk_folder + "\\" + plan_data[2]);
                               if (lst_files.Count > 0)
                               {
                                   if (Directory.Exists(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name))
                                   {
                                       umk_name = main_func.get_filename(plan_data[2]) + "_" + h.ToString() + i.ToString();
                                   }
                                   else
                                   {
                                       umk_name = main_func.get_filename(plan_data[2]);
                                   }
                                   Directory.CreateDirectory(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name);
                                   if (s_control_type == "page") { Directory.CreateDirectory(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\test"); }
                                   Directory.CreateDirectory(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html");
                                   temp_str = umk_row_template;
                                   n++;
                                   int nt = i + 1;
                                   string cur_umk = umk_folder + "\\" + plan_data[2] + "\\info.dat";
                                   temp_str = temp_str.Replace("{n}", nt.ToString());
                                   temp_str = temp_str.Replace("{name}", plan_data[0]);
                                   temp_str = temp_str.Replace("{HOURS}", main_func.get_value_from_infofile(cur_umk, "hours"));
                                   temp_str = temp_str.Replace("{LINK}", umk_name + "/html/index.htm");
                                   temp_str = temp_str.Replace("{CODE}", plan_data[1]);
                                   sub_umk_template_temp = subumk_template;
                                   sub_umk_template_temp = sub_umk_template_temp.Replace("{CAPTION}", plan_data[0]);
                                   sub_umk_rows_str = "";
                                   if (main_func.get_value_from_infofile(cur_umk, "exam") == "1")
                                   {
                                       temp_str = temp_str.Replace("{EXAM}", "+");
                                   }
                                   else
                                   {
                                       temp_str = temp_str.Replace("{EXAM}", "-");
                                   }
                                   if (main_func.get_value_from_infofile(cur_umk, "test") == "1")
                                   {
                                       temp_str = temp_str.Replace("{TEST}", "+");
                                   }
                                   else
                                   {
                                       temp_str = temp_str.Replace("{TEST}", "-");
                                   }
                                   if (main_func.get_value_from_infofile(cur_umk, "examination") == "1")
                                   {
                                       temp_str = temp_str.Replace("{EXAMINATION}", "+");
                                   }
                                   else
                                   {
                                       temp_str = temp_str.Replace("{EXAMINATION}", "-");
                                   }
                                   if (main_func.get_value_from_infofile(cur_umk, "prj") == "1")
                                   {
                                       temp_str = temp_str.Replace("{PRJ}", "+");
                                   }
                                   else
                                   {
                                       temp_str = temp_str.Replace("{PRJ}", "-");
                                   }
                                   umk_rows_str = umk_rows_str + temp_str;
                                   main_func.DirectoryCopy(appdir + "Styles\\disk_styles\\" + disk_style + "\\umk\\subfiles", appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\", true);

                                   for (int j = 0; j < lst_files.Count; j++)
                                   {
                                       if (main_func.get_extention(lst_files[j]) != "info")
                                       {
                                           if (File.Exists(umk_folder + "\\" + plan_data[2] + "\\" + lst_files[j] + ".info"))
                                           {
                                               string file_name = umk_folder + "\\" + plan_data[2] + "\\" + lst_files[j];
                                               string tags = main_func.get_value_from_infofile(file_name + ".info", "tags");
                                               if (tags != "" & Microsoft.VisualBasic.Strings.Left(tags, 1) != ",") { tags = "," + tags; }
                                               type = main_func.get_value_from_infofile(file_name + ".info", "file_type");
                                               
                                               string for_course = main_func.get_value_from_infofile(file_name + ".info", "course");
                                               bool file_is_good = false;
                                               if (for_course != "")
                                               {
                                                   if (for_course==Convert.ToString(Convert.ToInt32( plan_data[3])+1))
                                                   {
                                                      file_is_good=true;
                                                   }
                                                   else
                                                   {
                                                       string[] ss1 = for_course.Split(Convert.ToChar(","));
                                                       if (ss1.GetUpperBound(0) > 0)
                                                       {
                                                           for (int a = 0; a < ss1.GetUpperBound(0); a++)
                                                           {
                                                               if (ss1[a] == Convert.ToString(Convert.ToInt32(plan_data[3]) + 1)) { file_is_good = true; };
                                                           }
                                                       }
                                                   }
                                               }
                                               else
                                               {
                                                   file_is_good = true;
                                               }
                                                   switch (type)
                                                   {
                                                       case "Тесты (AIST)":
                                                           temp_str = control_row_template;
                                                           if (chk_zip_tests_enabled.Checked == true)
                                                           {
                                                               File.Copy(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\test\\test.zip", true);
                                                               temp_str = temp_str.Replace("{LINK}", "ztest://" + "umk/" + umk_name + "/test/test.zip");
                                                               if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\test\\test.zip;test,аист,aist,тестирование" + tags); }
                                                           }
                                                           else
                                                           {
                                                               filesys_func.extract_all_to_fldr(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\test\\");
                                                               if (File.Exists(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\test\\Aist-3w.exe"))
                                                               {
                                                                   temp_str = temp_str.Replace("{LINK}", "app://" + "umk/" + umk_name + "/test/Aist-3w.exe");
                                                               }
                                                               else
                                                               {
                                                                   temp_str = temp_str.Replace("{LINK}", "app://" + "umk/" + umk_name + "/test/app_test.exe");
                                                               }
                                                               if (chk_search_enabled.Checked == true)
                                                               {
                                                                   db_temp_list.Clear();
                                                                   db_temp_list = main_func.get_files_indir(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\test\\");
                                                                   if (db_temp_list.Count > 0)
                                                                   {
                                                                       for (int t = 0; t < db_temp_list.Count; t++)
                                                                       {
                                                                           db_files.Add("Content\\umk\\" + umk_name + "\\test\\" + db_temp_list[t] + ";test,тест,тестирование" + tags);
                                                                       }
                                                                   }
                                                               }
                                                           }
                                                           temp_str = temp_str.Replace("{NAME}", plan_data[0]);
                                                           control_rows_str = control_rows_str + temp_str;
                                                           break;
                                                       case "Тесты":
                                                           temp_str = control_row_template;
                                                           if (main_func.get_extention(file_name) == "htm" | main_func.get_extention(file_name) == "html")
                                                           {
                                                               File.Copy(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\test\\" + main_func.get_filename(file_name));
                                                               temp_str = temp_str.Replace("{LINK}", "../umk/" + umk_name + "/test/" + main_func.get_filename(file_name));
                                                               if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\test\\" + main_func.get_filename(file_name) + ";test,тест,тестирование,документ,файл,предмет,автор" + tags); }
                                                           }
                                                           else
                                                           {
                                                               if (s_convert_to_type == "PDF (*.pdf)")
                                                               {
                                                                   temp_str = temp_str.Replace("{LINK}", "other://umk/" + umk_name + "/test/test.pdf");
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\test\\test.pdf", "pdf");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\test\\test.pdf;test,тест,тестирование,документ,файл,предмет,автор" + tags); }
                                                               }
                                                               else
                                                               {
                                                                   temp_str = temp_str.Replace("{LINK}", "../umk/" + umk_name + "/test/test.htm");
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\test\\test.htm", "html");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\test\\test.htm;test,тест,тестирование,страница,предмет,автор" + tags); }
                                                               }
                                                           }
                                                           /*
                                                           if (chk_zip_tests_enabled.Checked == true)
                                                           {
                                                               File.Copy(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + dg_prj_files.Rows[i].Cells[0].Value.ToString() + "\\test\\test.zip", true);
                                                               temp_str = temp_str.Replace("{LINK}", "ztest://" + "umk/" + dg_prj_files.Rows[i].Cells[0].Value.ToString() + "/test/test.zip");
                                                               if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + dg_prj_files.Rows[i].Cells[0].Value.ToString() + "\\test\\test.zip;test,тестирование" + tags); }
                                                           }
                                                           else
                                                           {
                                                               filesys_func.extract_all_to_fldr(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + dg_prj_files.Rows[i].Cells[0].Value.ToString() + "\\test\\");
                                                               temp_str = temp_str.Replace("{LINK}", "app://" + "umk/" + dg_prj_files.Rows[i].Cells[0].Value.ToString() + "/test/app_test.exe");
                                                               if (chk_search_enabled.Checked == true)
                                                               {
                                                                   db_temp_list.Clear();
                                                                   db_temp_list = main_func.get_files_indir(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + dg_prj_files.Rows[i].Cells[0].Value.ToString() + "\\test\\");
                                                                   if (db_temp_list.Count > 0)
                                                                   {
                                                                       for (int t = 0; t < db_temp_list.Count; t++)
                                                                       {
                                                                           db_files.Add("Content\\umk\\" + dg_prj_files.Rows[i].Cells[0].Value.ToString() + "\\test\\" + db_temp_list[t] + ";test,тест,тестирование" + tags);
                                                                       }
                                                                   }
                                                               }                                            
                                                           }*/
                                                           temp_str = temp_str.Replace("{NAME}", plan_data[0]);
                                                           control_rows_str = control_rows_str + temp_str;
                                                           break;
                                                       case "Метод. указания":
                                                           if (file_is_good)
                                                           {
                                                               temp_str = subumk_row_template;
                                                               if (s_convert_to_type == "PDF (*.pdf)")
                                                               {
                                                                   temp_str = temp_str.Replace("{LINK}", "other://umk/" + umk_name + "/html/met.pdf");
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\met.pdf", "pdf");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\html\\met.pdf;методичка,методические,указания,документ,файл,предмет,автор" + tags); }
                                                               }
                                                               else
                                                               {
                                                                   temp_str = temp_str.Replace("{LINK}", "met.htm");
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\met.htm", "html");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\html\\met.htm;методичка,методические,указания,страница,предмет,автор" + tags); }
                                                               }
                                                               temp_str = temp_str.Replace("{NAME}", "Методические указания");
                                                               sub_umk_rows_str = sub_umk_rows_str + temp_str;
                                                           }
                                                           break;
                                                       case "Лекции":
                                                           if (file_is_good)
                                                           {
                                                               temp_str = subumk_row_template;
                                                               if (s_convert_to_type == "PDF (*.pdf)")
                                                               {
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\lectures.pdf", "pdf");
                                                                   temp_str = temp_str.Replace("{LINK}", "other://umk/" + umk_name + "/html/lectures.pdf");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\html\\lectures.pdf;лекции,материал,лекционный,файл,документ,предмет,автор" + tags); }
                                                               }
                                                               else
                                                               {
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\lectures.htm", "html");
                                                                   temp_str = temp_str.Replace("{LINK}", "lectures.htm");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\html\\lectures.htm;лекции,материал,лекционный,страница,предмет,автор" + tags); }
                                                               }
                                                               temp_str = temp_str.Replace("{NAME}", "Лекции");
                                                               sub_umk_rows_str = sub_umk_rows_str + temp_str;
                                                           }
                                                           break;
                                                       case "Билеты":
                                                           if (file_is_good)
                                                           {
                                                               temp_str = subumk_row_template;
                                                               if (s_convert_to_type == "PDF (*.pdf)")
                                                               {
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\notes.pdf", "pdf");
                                                                   temp_str = temp_str.Replace("{LINK}", "other://umk/" + umk_name + "/html/notes.pdf");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\html\\notes.pdf;билеты,задания,файл,документ,предмет,автор" + tags); }
                                                               }
                                                               else
                                                               {
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\notes.htm", "html");
                                                                   temp_str = temp_str.Replace("{LINK}", "notes.htm");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\html\\notes.htm;билеты,задаения,страница,предмет,автор" + tags); }
                                                               }
                                                               temp_str = temp_str.Replace("{NAME}", "Билеты");
                                                               sub_umk_rows_str = sub_umk_rows_str + temp_str;
                                                           }
                                                           break;
                                                       case "Раб.программа":
                                                           if (file_is_good)
                                                           {
                                                               temp_str = subumk_row_template;
                                                               if (s_convert_to_type == "PDF (*.pdf)")
                                                               {
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\programme.pdf", "pdf");
                                                                   temp_str = temp_str.Replace("{LINK}", "other://umk/" + umk_name + "/html/programme.pdf");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\html\\programme.pdf;программа,рабочая,курс,лекции,экзамен,тест,зачёт,зачет,билеты,проект,курсовой,курсовая,курсовик,итог,тестирование,файл,документ,предмет,автор" + tags); }
                                                               }
                                                               else
                                                               {
                                                                   convert_func.convert(file_name, appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\programme.htm", "html");
                                                                   temp_str = temp_str.Replace("{LINK}", "programme.htm");
                                                                   if (chk_search_enabled.Checked == true) { db_files.Add("Content\\umk\\" + umk_name + "\\html\\programme.htm;программа,рабочая,курс,лекции,экзамен,тест,зачёт,зачет,билеты,проект,курсовой,курсовая,курсовик,итог,тестирование,страница,предмет,автор" + tags); }
                                                               }
                                                               temp_str = temp_str.Replace("{NAME}", "Рабочая учебная программа");
                                                               sub_umk_rows_str = sub_umk_rows_str + temp_str;
                                                           }
                                                           break;
                                               }
                                           }
                                       }
                                       Col++;
                                   }
                                   sub_umk_template_temp = sub_umk_template_temp.Replace("{ROWS}", sub_umk_rows_str);
                                   main_func.write_all_text_to_file(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\" + umk_name + "\\html\\index.htm", sub_umk_template_temp);
                               }
                           }
                       }
                       if (Col > 0)
                       {
                           umk_row_year_temp_str = umk_row_year_template;
                           int ts = h + 1;
                           umk_row_year_temp_str = umk_row_year_temp_str.Replace("{YEAR}", ts.ToString());
                           umk_final_rows_str = umk_final_rows_str + umk_row_year_temp_str + umk_rows_str;
                           umk_rows_str = "";
                       }
                   }

                   if (s_control_type == "page")
                   {
                       control_template = control_template.Replace("{ROWS}", control_rows_str);
                       main_func.write_all_text_to_file(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\control\\index.htm", control_template);
                   }
                   if (s_edu_type == "page")
                   {
                       umk_template = umk_template.Replace("{ROWS}", umk_final_rows_str);
                       main_func.write_all_text_to_file(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\umk\\index.htm", umk_template);
                   }
               }
               else
               {
                   MessageBox.Show("В выбранном учебном плане нет файлов!", "Отсутствуют файлы", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
               //
               //create files.db
               //
               backgroundStructurWorker.ReportProgress(50);
               if (chk_search_enabled.Checked == true)
               {
                   main_func.clear_lst_to_file();
                   if (db_files.Count > 0)
                   {
                       for (int i = 0; i < db_files.Count; i++)
                       {
                           main_func.add_to_lst_to_file(db_files[i]);
                       }
                       main_func.write_to_info_file(prj_folder + prj_open_name + "\\distr\\files.db");
                   }
               }
               backgroundStructurWorker.ReportProgress(60);
               //
               //create autorun.inf
               //
               if (chk_create_autorun_inf.Checked == true)
               {
                   main_func.clear_lst_to_file();
                   main_func.add_to_lst_to_file("[autorun]");
                   main_func.add_to_lst_to_file("open=umk_shell.exe");
                   if (File.Exists(appdir + "Projects\\" + prj_open_name + "\\temp\\autorun\\disk_icon.ico"))
                   {
                       File.Copy(appdir + "Projects\\" + prj_open_name + "\\temp\\autorun\\disk_icon.ico", prj_folder + prj_open_name + "\\distr\\autorun.ico", true);
                       main_func.add_to_lst_to_file("icon=autorun.ico");
                   }
                   main_func.write_to_info_file(prj_folder + prj_open_name + "\\distr\\autorun.inf");
               }
               //
               //create strings.inf
               //
               backgroundStructurWorker.ReportProgress(70);
               main_func.clear_lst_to_file();
               main_func.add_to_lst_to_file("version=" + shell_config_version);
               main_func.add_to_lst_to_file("[MAIN_SETTINGS]");
               main_func.add_to_lst_to_file("search_enabled=" + chk_search_enabled.Checked.ToString());
               main_func.add_to_lst_to_file("glass_enabled=" + chk_glass_enabled.Checked.ToString());
               if (s_licence_enabled == true)
               {
                   if (s_licence_type == "url")
                   {
                       main_func.add_to_lst_to_file("licence_path=" + txt_licence_path.Text);
                   }
                   else
                   {
                       main_func.add_to_lst_to_file("licence_path=" + "licence/licence.htm");
                   }
                   main_func.add_to_lst_to_file("licence_type=" + s_licence_type);
               }
               main_func.add_to_lst_to_file("[CAPTIONS]");
               main_func.add_to_lst_to_file("caption=" + txt_disk_name.Text);
               main_func.add_to_lst_to_file("author=" + txt_menu_about.Text);
               main_func.add_to_lst_to_file("learn_caption=" + txt_menu_edu.Text);
               main_func.add_to_lst_to_file("control_caption=" + txt_menu_control.Text);
               main_func.add_to_lst_to_file("[BUTTONS]");
               main_func.add_to_lst_to_file("splash_type=" + s_splash_type);
               if (s_splash_type == "url")
               {
                   main_func.add_to_lst_to_file("splash_path=" + txt_splash_path.Text);
               }
               else
               {
                   main_func.add_to_lst_to_file("splash_path=splash\\" + txt_splash_path.Text);
               }
               main_func.add_to_lst_to_file("splash_enabled=" + chk_splash_enabled.Checked.ToString());
               main_func.add_to_lst_to_file("help_type=page");
               //+ s_help_type  chk_help_enabled.Checked.ToString()
               main_func.add_to_lst_to_file("help_enabled=True" );
               main_func.add_to_lst_to_file("help_path=help\\index.htm");
               main_func.add_to_lst_to_file("umk_type=" + s_edu_type);
               main_func.add_to_lst_to_file("umk_enabled=" + chk_edu_enabled.Checked.ToString());
               if (s_edu_type == "url")
               {
                   main_func.add_to_lst_to_file("umk_path=" + txt_menu_edu_path.Text);
               }
               else
               {
                   main_func.add_to_lst_to_file("umk_path=umk\\index.htm");
               }
               main_func.add_to_lst_to_file("test_type=" + s_control_type);
               main_func.add_to_lst_to_file("test_enabled=" + chk_control_enabled.Checked.ToString());
               if (s_control_type == "url")
               {
                   main_func.add_to_lst_to_file("test_path=" + txt_menu_control_path.Text);
               }
               else
               {
                   main_func.add_to_lst_to_file("test_path=control\\index.htm");
               }
               main_func.add_to_lst_to_file("about_type=" + s_about_type);
               main_func.add_to_lst_to_file("about_enabled=" + chk_about_enabled.Checked.ToString());
               if (s_about_type == "url")
               {
                   main_func.add_to_lst_to_file("about_path=" + txt_menu_about_path.Text);
               }
               else
               {
                   main_func.add_to_lst_to_file("about_path=about\\" + txt_menu_about_path.Text);
               }
               main_func.write_to_info_file(prj_folder + prj_open_name + "\\distr\\strings.inf");
               //
               //copy files from temp
               //
               backgroundStructurWorker.ReportProgress(80);
               if (s_splash_type != "url")
               {
                   //copy splash
                   if (Directory.Exists(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\splash") == false) { Directory.CreateDirectory(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\splash"); }
                   main_func.DirectoryCopy(appdir + "Projects\\" + prj_open_name + "\\temp\\splash", appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\splash", true);
               }
               if (s_help_type == "page")
               {
                   //copy help
                   if (Directory.Exists(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\help") == false) { Directory.CreateDirectory(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\help"); }
                   main_func.DirectoryCopy(appdir + "Projects\\" + prj_open_name + "\\temp\\help", appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\help", true);
               }
               if (s_about_type == "page")
               {
                   //copy about
                   if (Directory.Exists(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\about") == false) { Directory.CreateDirectory(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\about"); }
                   main_func.DirectoryCopy(appdir + "Projects\\" + prj_open_name + "\\temp\\about", appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\about", true);
               }
               //copy service files
               //main_func.DirectoryCopy(appdir + "system\\service", appdir + "Projects\\" + prj_open_name + "\\distr\\SERVICE", true);
               //
               //SET CHANGES
               //
               backgroundStructurWorker.ReportProgress(90);
               prj_IS_built = true;
               prj_build_date = DateTime.Now.Date.Day.ToString() + "." + DateTime.Now.Date.Month.ToString() + "." + DateTime.Now.Date.Year.ToString();
               //create help
                   main_func.DirectoryCopy(appdir + "Styles\\disk_styles\\" + disk_style + "\\help\\files", appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\help\\", true);
                   string help_template = main_func.read_all_file(appdir + "Styles\\disk_styles\\" + disk_style + "\\help\\index.htm");
                   if (txt_menu_help_path.Text != "" & chk_help_enabled.Checked.ToString()=="True")
                   {
                       help_template = help_template.Replace("{HELP_LINK}", txt_menu_help_path.Text);
                       help_template = help_template.Replace("{HELP_LINK_ENABLED}", "block");
                   }
                   else
                   {
                       help_template = help_template.Replace("{HELP_LINK}", "#");
                       help_template = help_template.Replace("{HELP_LINK_ENABLED}", "none");
                   }
                   main_func.write_all_text_to_file(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\help\\index.htm", help_template);
               if (s_licence_type == "page")
               {
                   //copy licence
                   if (Directory.Exists(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\licence") == false) { Directory.CreateDirectory(appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\licence"); }
                   main_func.DirectoryCopy(appdir + "Projects\\" + prj_open_name + "\\temp\\licence", appdir + "Projects\\" + prj_open_name + "\\distr\\Content\\licence", true);
               }
               //
               //Add files_folders to listBoxFiles
               //
               add_prj_to_listboxfiles();
               backgroundStructurWorker.ReportProgress(100);
               e.Result = 0;
           }
           catch ( Exception ex)
           {
               MessageBox.Show(ex.Message);
               e.Result = 1;
           }
       }

       private void backgroundStructurWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
       {
           progressStructur.Value = e.ProgressPercentage;
           labelStructur_status.Text = e.ProgressPercentage.ToString() + "%"; 
       }

       private void backgroundStructurWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
          /* if (e.Cancelled == true)
           {
               //cancelled
               lbl_structurize_build_date.Text = "Создание проекта отменено";
               prj_IS_built = false;
               m_isStructurising = false;
               EnableStructurUI(true);
               enableUI(true);
               return;
           }*/
           if ((int)e.Result != 0)
           {
               //error
               prj_IS_built = false;
               m_isStructurising = false;
               EnableStructurUI(true);
               lbl_structurize_build_date.Text = "Ошибка";
           }
           else
           {
               //succsess
               prj_IS_built = true;
               m_isStructurising = false;
               EnableStructurUI(true);
               lbl_structurize_build_date.Text = prj_build_date;
               save_project(prj_open_name);
           }
       }

       private void pict_mngr_Click(object sender, EventArgs e)
       {
           developers_components_lib.cls_interract app_func=new developers_components_lib.cls_interract();
           if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "umk_manager_08.exe"))
           {
               if (app_func.is_app_is_running("umk_manager_08") == false) { Process.Start(AppDomain.CurrentDomain.BaseDirectory + "umk_manager_08.exe"); }
           }
       }

       private void pict_mngr_MouseEnter(object sender, EventArgs e)
       {
           pict_mngr.Image = Properties.Resources.mngr_m;
       }

       private void pict_mngr_MouseLeave(object sender, EventArgs e)
       {
           pict_mngr.Image = Properties.Resources.mngr_n;
       }

 
  


    }
}
