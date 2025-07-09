using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace processManagement.Service
{
    internal class IniFileSysteam
    {
        [DllImport("kernel32.dll")]
        private static extern uint GetPrivateProfileString(
            string section,
            string key,
            string defaultValue,
            StringBuilder value,
            uint size,
            string filePath);

        [DllImport("kernel32.dll")]
        private static extern bool WritePrivateProfileString(
            string section,
            string key,
            string value,
            string filePath);


    }
}
