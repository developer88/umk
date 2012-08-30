using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace DiskCreator
{
	class cls_main
	{
          public System.Collections.ObjectModel.Collection<string> lst_to_file=new System.Collections.ObjectModel.Collection<string>();

          public void replace_in_file(string string_to_find, string string_replace_with, string filename)
          {
              string all_file=this.read_all_file(filename);
              all_file = all_file.Replace(string_to_find, string_replace_with);
              this.write_all_text_to_file(filename, all_file);
          }

          public bool check_for_components(bool silent)
          {
              bool result=true;
              if (Environment.OSVersion.Version.Major < 6)
              {
                 // if (!silent) { MessageBox.Show("Данная программа не совместима с вашей ОС", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                 // result = false;
                 // Application.Exit();
              }
              if (Directory.Exists( AppDomain.CurrentDomain.BaseDirectory + "system\\umk") == false)
              {
                  if (!silent) { MessageBox.Show("Компоненты для создания УМК не обнаружены. Переустановите программу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                  result = false;
                  Application.Exit();
              }
              //check for Word
              try
              {
                  string word_ver = get_registry("HKEY_CLASSES_ROOT\\Word.Application\\CurVer");
                  if ((word_ver.Length - 17) > 0)
                  {
                      word_ver = Microsoft.VisualBasic.Strings.Right(word_ver, word_ver.Length - 17);
                  }
                  if (Convert.ToInt32(word_ver) < 12)
                  {
                      if (!silent) { MessageBox.Show("Установите Microsoft Word 2007 или более новый!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                      result = false;
                      Application.Exit();
                  }
              }
              catch
              {
                  if (!silent) { MessageBox.Show("Установите Microsoft Word 2007 или более новый!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                  result = false;
                  Application.Exit();
              }
              return result;
          }
        
        
        public void open_webdoc (string web_path)
          {
             string windir="";
              windir = Environment.GetEnvironmentVariable("windir");
              Process.Start (web_path);
          }

          public string show_opendialog(string dialog_caption)
          {
              string dialog_result = "";
              OpenFileDialog dlg = new OpenFileDialog();
              dlg.FileName = "anyfile";
              dlg.DefaultExt = ".*";
              dlg.Filter = "Any files (.*)|*.*";
              if (dlg.ShowDialog()==System.Windows.Forms.DialogResult.OK ) { dialog_result = dlg.FileName; }
              return dialog_result;
          }

          public string get_value_from_infofile(string path, string var)
          {
              string result="";
              System.Collections.ObjectModel.Collection<string> lst_files = new System.Collections.ObjectModel.Collection<string>();
              lst_files = read_textfile_by_line(path);
              if (lst_files.Count > 0)
              {
                  for (int i = 0; i < lst_files.Count; i++)
                  {
                      string[] str = lst_files[i].Split(Convert.ToChar("="));
                      if (str[0] == var)
                      {
                          result = str[1];
                      }
                  }
              }
              else
              {
                  result = "";
              }
              return result;
          }

          public string show_createdialog(string dialog_caption)
          {
              string dialog_result = "";
              SaveFileDialog dlg = new SaveFileDialog();
              dlg.FileName = "anyfile";
              dlg.DefaultExt = ".*";
              dlg.Filter = "Any files (.*)|*.*";
              if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) { dialog_result = dlg.FileName; }
              return dialog_result;
          }

          public void write_to_info_file(string file_path)
          {
             if (lst_to_file.Count>0)
             {
                  if (File.Exists(file_path)==true)
                  {
                      File.Delete(file_path);
                  };
                  try 
			      {
                      StreamWriter sw = new StreamWriter(file_path);
                        for (int i=0;i<lst_to_file.Count;i++)
                        {
                            sw.WriteLine(lst_to_file.ElementAt(i).ToString());
                        }
				        sw.Close();
			        }
			        catch(Exception e)
			        {
				        MessageBox.Show(e.Message,"Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
			        }
             }
          }

          public string read_all_file(string file_path)
          {
              string return_string = "";
              if (File.Exists(file_path))
              {
                return_string = File.ReadAllText(file_path,UTF8Encoding.UTF8);
              }
              return return_string;
          }

          public void write_all_text_to_file(string file_path,string file_text)
          {
                 if (File.Exists(file_path))
                 {
                     File.Delete(file_path);
                 }
                 File.WriteAllText(file_path,file_text,UTF8Encoding.UTF8);
          }

          public void clear_lst_to_file()
          {
              lst_to_file.Clear();
          }

          public void add_to_lst_to_file(string text_to_add)
          {
              lst_to_file.Add(text_to_add);
          }

          public void create_registry()
          {
              const string userRoot=   "HKEY_CURRENT_USER";
              const string subkey= "Software\\dsoft\\UMK\\";
              const string keyName = userRoot + "\\" +subkey;
              Microsoft.Win32.Registry.SetValue(keyName, "disk_writer_path", "" + Application.ExecutablePath.ToString() + "", Microsoft.Win32.RegistryValueKind.String);
          }

        public System.Collections.ObjectModel.Collection<string> read_textfile_by_line(string file_path)
        {
            System.Collections.ObjectModel.Collection<string> return_lst=new System.Collections.ObjectModel.Collection<string>();
            if (File.Exists(file_path))
            {
                StreamReader ioFile=new StreamReader(file_path);
                string ioLine= "   1";
                while ((ioLine = ioFile.ReadLine()) != null)
                {
                    if (Microsoft.VisualBasic.Strings.Len(ioLine) > 0)
                    {
                        return_lst.Add(ioLine);
                    }
                }
                ioFile.Close();
            }
            return return_lst;
        }

          public string get_my_registry(string registry_name)
          {
              string registry_value = "";
              const string userRoot=   "HKEY_CURRENT_USER";
              const string subkey= "Software\\dsoft\\UMK\\";
              const string keyName = userRoot + "\\" +subkey;
              registry_value=Microsoft.Win32.Registry.GetValue(keyName, registry_name, String.Empty).ToString();
              if (Microsoft.VisualBasic.Strings.Right(registry_value,1)=="\\")
              {
                  registry_value = Microsoft.VisualBasic.Strings.Left(registry_value, Microsoft.VisualBasic.Strings.Len(registry_value) - 1);
              }
              return registry_value;
          }

         public string get_registry(string registry_path)
         {
              string registry_value = "";
              //const string userRoot=   "HKEY_CURRENT_USER";
              //const string subkey= "Software\\dsoft\\UMK\\";
              //const string keyName = userRoot + "\\" +subkey;
              registry_value = Microsoft.Win32.Registry.GetValue(registry_path, "", String.Empty).ToString();
              //if (Microsoft.VisualBasic.Strings.Right(registry_value,1)=="\\")
              //{
              //    registry_value = Microsoft.VisualBasic.Strings.Left(registry_value, Microsoft.VisualBasic.Strings.Len(registry_value) - 1);
              //}
              return registry_value;
          }

        public System.Collections.ObjectModel.Collection<string> get_dir(string dir_path)
        {
            System.Collections.ObjectModel.Collection<string> return_lst=new System.Collections.ObjectModel.Collection<string>();
            if (Directory.Exists(dir_path)==true)
            {
                foreach (string founddir in Directory.GetDirectories(dir_path))
	            {
            		 return_lst.Add(get_filename(founddir));
	            }
            }
            return return_lst;
        }

        public string get_filename(string str)
        {
            string str_return = "";
            string[] path_temp=str.Split(Convert.ToChar("\\"));
            str_return = path_temp[path_temp.GetUpperBound(0)];
            return str_return;
        }

        public string get_filename_without_ex(string str)
        {
            string str_return = "";
            string[] path_temp = str.Split(Convert.ToChar("\\"));
            str_return = path_temp[path_temp.GetUpperBound(0)];
            string[] filename = str_return.Split(Convert.ToChar("."));
            str_return = filename[0];          
            return str_return;
        }

        public System.Collections.ObjectModel.Collection<string> get_files_indir(string dir_path)
        {
            string files_pattern = "*.*";
            System.Collections.ObjectModel.Collection<string> return_lst = new System.Collections.ObjectModel.Collection<string>();
            if (Directory.Exists(dir_path) == true)
            {
                foreach (string founddir in Directory.GetFiles(dir_path, files_pattern, SearchOption.TopDirectoryOnly))
                {
                    return_lst.Add(get_filename(founddir));
                }
            }
            return return_lst;
        }

        public System.Collections.ObjectModel.Collection<string> get_allfiles(string dir_path)
        {
            string files_pattern = "*.*";
            System.Collections.ObjectModel.Collection<string> return_lst = new System.Collections.ObjectModel.Collection<string>();
            if (Directory.Exists(dir_path) == true)
            {
                foreach (string founddir in Directory.GetFiles(dir_path, files_pattern, SearchOption.AllDirectories))
                {
                    return_lst.Add(get_filename(founddir));
                }
            }
            return return_lst;
        }

        public System.Collections.ObjectModel.Collection<string> get_allfiles_with_path(string dir_path,string base_path)
        {
            string files_pattern = "*.*";
            System.Collections.ObjectModel.Collection<string> return_lst = new System.Collections.ObjectModel.Collection<string>();
            if (Directory.Exists(dir_path) == true)
            {
                foreach (string founddir in Directory.GetFiles(dir_path, files_pattern, SearchOption.AllDirectories))
                {
                    return_lst.Add(founddir.Replace(base_path,""));
                }
            }
            return return_lst;
        }

        public string get_extention(string filename)
        {
            string file_extension="";
            string[] c_temp=filename.Split(Convert.ToChar("."));
 
                file_extension=c_temp[c_temp.GetUpperBound(0)];
          
            return file_extension;
        }

        public string get_path(string str)
        {
            string str_return = "";
            string[] path_temp = str.Split(Convert.ToChar("\\"));
            str_return = Left(str, Microsoft.VisualBasic.Strings.Len(str) - Microsoft.VisualBasic.Strings.Len(path_temp[path_temp.GetUpperBound(0)]));
            return str_return;
        }

        public static string Left(string text, int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException("length", length, "length must be > 0");
            else if (length == 0 || text.Length == 0)
                return "";
            else if (text.Length <= length)
                return text;
            else
                return text.Substring(0, length);
        }

        public string ReplaceAll(string SourceString, string ReplaceThis, string WithThis)
        {
            string result="";
            result = SourceString.Replace(ReplaceThis,WithThis);
            return result;
        }



    public void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        if (Directory.Exists(sourceDirName))
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                try
                {
                    Directory.CreateDirectory(destDirName);
                }
                catch { };
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                try
                {
                    file.CopyTo(temppath, true);
                }
                catch  {};                
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }

      
	}
}
