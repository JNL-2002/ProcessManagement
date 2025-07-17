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

        public StringBuilder ReadlniFile(string FileName, string Section, string Key)
        {
            FilePath = Path.Combine($"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\Data", $"{FileName}.ini");
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(Section, Key, string.Empty, sb, (uint)sb.Capacity, FilePath);
            return sb;
        }

        public List<string> SectionReadlniFile(string FileName)
        {
            FilePath = Path.Combine($"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\Data", $"{FileName}.ini");
            List<string> sections = new List<string>();
            string[] lines = File.ReadAllLines(FilePath);

            foreach (var line in lines)
            {
                if (line.TrimStart().StartsWith("["))
                {
                    sections.Add(line);
                }
            }

            return sections;
        }

        public List<string> KeyValueReadIniFile(string FileName, string LogDay)
        {
            FilePath = Path.Combine($"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\Data", $"{FileName}.ini");
            bool firstStart = false;

            string[] KeyValues = File.ReadAllLines(FilePath);
            List<string> lines = new List<string>();

            foreach (string line in KeyValues)
            {
                if (line.StartsWith(LogDay) || firstStart)
                {
                    if (line.ToString().StartsWith("["))
                    {
                        if (firstStart)
                        {
                                break;
                        }
                        firstStart = true;
                    }
                    lines.Add(line.ToString());
                }
            }
            lines.RemoveAt(0);
            return lines;
        }
    }
}
