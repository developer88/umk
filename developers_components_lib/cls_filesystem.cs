using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Ionic.Zip;
using System.Windows;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace developers_components_lib
{
    public class cls_filesystem
    {

        public System.Collections.ObjectModel.Collection<string> read_textfile_by_line(string file_path)
        {
            System.Collections.ObjectModel.Collection<string> return_lst = new System.Collections.ObjectModel.Collection<string>();
            if (File.Exists(file_path))
            {
                StreamReader ioFile = new StreamReader(file_path);
                string ioLine = "   1";
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

        public string get_extention(string filename)
        {
            string file_extension = "";
            string[] c_temp = filename.Split(Convert.ToChar("."));

            file_extension = c_temp[c_temp.GetUpperBound(0)];

            return file_extension;
        }
        
        public string get_filename(string str)
        {
            string str_return = "";
            string[] path_temp = str.Split(Convert.ToChar("\\"));
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
        
        public void add_fldr_to_zip(string frlR_path_source , string file_path_destination )
        {
            try 
	        {	        
		        using(ZipFile zip1=new ZipFile())
                {    
                    zip1.AddDirectory(frlR_path_source);
                    zip1.Save(file_path_destination);
                }
	        }
	        catch (Exception exc1)
	        {
                MessageBox.Show(String.Format("Ошибка при создании zip-файла", exc1.Message));
		        //throw;
	        }
        }
        public bool extract_all_to_fldr(string archive_path, string destination_path)
        {
            if (archive_path != "" & File.Exists(archive_path))
            {
                if (Directory.Exists(destination_path) == false) { Directory.CreateDirectory(destination_path); };
                try
                {
                    using (ZipFile zip1 = new ZipFile(archive_path))
                    {
                        zip1.ExtractAll(destination_path, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                catch (Exception exc1)
                {
                    MessageBox.Show(String.Format("Ошибка при разархивировании zip-файла", exc1.Message));
                    return false;
                    // throw;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
