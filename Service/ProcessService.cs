using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace processManagement.Service
{
    internal class ProcessService
    {
        public string ProcessPath;
        public string ProcessName; 

        public ProcessService(string ProcessPath, string ProcessName)
        {
            this.ProcessPath = ProcessPath;
            this.ProcessName = Path.GetFileNameWithoutExtension(ProcessName);
        }

        public void ReStartProcess()
        {
            Process[] p = Process.GetProcessesByName(ProcessName);
            if (p == null)
            {
                Process.Start(ProcessName);
            }
            

        }
    }
}
