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
        string FilePath = string.Empty;

        [DllImport("kernel32.dll")]
        private static extern uint GetPrivateProfileString(
            string section,
            string key,
            string defualt,
            StringBuilder value,
            uint size,
            string filePath);

        [DllImport("kernel32.dll")]
        private static extern bool WritePrivateProfileString(
            string section,
            string key,
            string value,
            string filePath);

        public void CreateAndWriteIniFile(string FileName, string section, string Key, string Value)
        {
            FilePath = Path.Combine($"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\Data", $"{FileName}.ini");

            if (!File.Exists(FilePath))
            {
                using (File.Create(FilePath)) { }
            }

            WritePrivateProfileString(section, Key, Value, FilePath);
        }

        public StringBuilder ReadlniFile(string FileName, string Section)
        {
            FilePath = Path.Combine($"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\Data", $"{FileName}.ini");
            StringBuilder sb = new StringBuilder(1500);
            GetPrivateProfileString(Section, Section, string.Empty, sb, (uint)sb.Capacity, FilePath);
            return sb;
        }
    }
}
