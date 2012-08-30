using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace developers_components_lib
{
    public class cls_interract
    {
        public bool is_app_is_running(string app_name)
        {
            foreach (Process clsProcess in Process.GetProcesses()) {
                    if (clsProcess.ProcessName.Contains(app_name))
                    {
                            return true;
                    }
            }
            return false;
         }
    }
}
