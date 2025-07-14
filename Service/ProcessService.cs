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
        public string ProcessPath = string.Empty;
        public string ProcessName = string.Empty;
        IniFileSysteam ini = new IniFileSysteam();


        public bool ReStartCheck = false;

        public void ReStartProcess()
        {
            while (ReStartCheck)
            { 
                Process[] p = Process.GetProcessesByName(ProcessName);
                if (p.Length == 0)
                {
                    Process.Start(ProcessPath);
                    ini.CreateAndWriteIniFile("Log", DateTime.Now.ToString(), "ReStartEvent", "발생");
                }
                Thread.Sleep(500); // 0.5초 대기
            }
        }
    }
}
