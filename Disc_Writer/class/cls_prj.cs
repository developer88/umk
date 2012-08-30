using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DiskCreator
{
	class cls_prj
	{
        public void create_prj(string prj_name)
        {
            cls_main file_func = new cls_main();
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name);
            file_func.clear_lst_to_file();
            file_func.add_to_lst_to_file("prj_name=" + prj_name);
            file_func.add_to_lst_to_file("prj_create_date=" + DateTime.Now.Date.ToString());
            file_func.write_to_info_file(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\index.prj");
        }

        public void create_prj_dir(string dir_type,string prj_name,bool delete_old_folders)
        {
            switch (dir_type)
            {
                case "distr":
                    if (delete_old_folders == true)
                    {
                        try
                        {
                            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\distr") == true)
                            {
                                Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\distr", true);
                            }
                        }
                        catch (Exception)
                        { 
                            //throw;
                        }                       
                    }
                    try
                    {
                        if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\distr") == false)
                        {
                            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\distr");
                        }
                        if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\distr\\Content") == false)
                        {
                            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\distr\\Content");
                        }
                    }
                    catch (Exception)
                    {
                        //throw;
                    }  
                    break;
                case "system":
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp") == false)
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp");
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\splash");
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\help");
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\about");
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\autorun");
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\licence");
                    }
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\splash") == false)
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\splash");
                    }
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\help") == false)
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\help");
                    }
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\about") == false)
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\about");
                    }
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\autorun") == false)
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\autorun");
                    }
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\licence") == false)
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Projects\\" + prj_name + "\\temp\\licence");
                    }
                    break;
            }





        }







	}
}
