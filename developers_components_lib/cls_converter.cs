using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Diagnostics;

namespace developers_components_lib
{
    public class cls_converter : MarshalByRefObject
    {
        object paramMissing = Type.Missing;
        public string errormessage;
        private bool wordavailable=false;
        private bool checkedword = false;

        public bool WordIsAvailable()
        {
            //don't check every time.... first time only
            if (!checkedword)
            {

                try
                {
                    ApplicationClass wordApplication = new ApplicationClass();
                    wordApplication.Visible = true;
                    wordApplication.Quit(ref paramMissing, ref paramMissing,
                                         ref paramMissing);
                    wordavailable = true;
                }
                catch
                {
                    wordavailable = false;
                }
                checkedword = true;
            }
            return wordavailable;
          
        }

        public bool convert(string source, string output,string file_type)
        {
           bool result=false;
           cls_filesystem file_func = new cls_filesystem();
           string ex = file_func.get_extention(source);
           if (ex == "doc" | ex == "txt" | ex == "docx" | ex == "rtf")
           {
               result = word_convert_file(source, output, file_type);
           }
           return result;
        }

       private bool word_convert_file(string source, string output,string file_type)
        {
            if (System.IO.File.Exists(source))
            {
                //start conversion
                try
                {
                    Microsoft.Office.Interop.Word.ApplicationClass MSdoc = new Microsoft.Office.Interop.Word.ApplicationClass();
                    object paramSourceDocPath = source;
                    object Unknown = Type.Missing;

                    object paramTrue = true;
                    object paramFalse = false;
                    object paramExportFilePath = output;
                    object paramSaveFormat = WdSaveFormat.wdFormatHTML;
                    object paramEncoding = Encoding.ASCII;
                    object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                    //WdExportFormat paramExportFormat = WdExportFormat.wdExportFormatPDF;
                                        
                    switch (file_type)
                    {
                        case "pdf":
                            //set exportformat to pdf
                            format = WdSaveFormat.wdFormatPDF;
                            break;
                        case "html":
                            //set exportformat to pdf
                            format = WdSaveFormat.wdFormatHTML;
                            break;
                    }
                        MSdoc.Documents.Open(
                            ref paramSourceDocPath, ref Unknown, ref paramTrue,
                            ref paramFalse, ref Unknown, ref Unknown,
                            ref Unknown, ref Unknown, ref Unknown,
                            ref Unknown, ref Unknown, ref Unknown,
                            ref Unknown, ref Unknown, ref Unknown,
                            ref Unknown);
                        MSdoc.Application.Visible = false;
                        MSdoc.WindowState = Microsoft.Office.Interop.Word.WdWindowState.wdWindowStateMinimize;

                        MSdoc.ActiveDocument.SaveAs(ref paramExportFilePath, ref format, ref Unknown, ref Unknown,
                            ref paramFalse, ref Unknown, ref Unknown, ref Unknown, ref Unknown,
                            ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown,
                            ref Unknown, ref Unknown);

                        object saveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdPromptToSaveChanges;
                        MSdoc.Quit(ref saveChanges, ref Unknown, ref Unknown);
                    



                        //MSdoc.ActiveDocument.Close(ref Unknown, ref Unknown, ref Unknown);
                        //MSdoc.Documents.Close(ref Unknown, ref Unknown, ref Unknown);
                        //MSdoc.Quit(ref paramFalse, ref Unknown, ref Unknown);
                       // MSdoc.Application.Quit(ref Unknown, ref Unknown, ref Unknown);
                        //MSdoc = null;                    
                }
                catch (Exception err)
                {
                    errormessage=err.Message;
                }
                    return true;

            }
            else
            {
                errormessage="ERROR: Inputfile not found";
            }
             return false;

        }
        
    }
}
