using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Web;
using processManagement.Service;

namespace processManagement
{
    public partial class Form1 : Form
    {
        //테스트용 콘솔 출력
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        IniFileSysteam ini = new IniFileSysteam();

        public Form1()
        {
            InitializeComponent();
            label2.Text = ini.ReadlniFile("Setting", "Path", "Path").ToString();
            comboBox1.Items.Add($"{ini.ReadlniFile("Setting", "ProcessName", "ProcessName").ToString()}.exe");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(ini.SectionReadlniFile("Log").ToArray());
            comboBox2.SelectedIndex = 0;

            label2.AutoSize = false;
            label2.Width = 300;
        }

        ProcessService ps = new ProcessService();
        Thread t;


        private void fileOpen_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    label2.Text = folderDialog.SelectedPath;
                }
                string[] exeFiles = Directory.GetFiles(label2.Text, "*.exe");
                comboBox1.Items.AddRange(exeFiles.Select(f => Path.GetFileName(f)).ToArray());
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ps.ProcessPath = $"{label2.Text}\\{comboBox1.SelectedItem}";
            ps.ProcessName = Path.GetFileNameWithoutExtension($"{comboBox1.SelectedItem}");
            t = new Thread(() => ps.ReStartProcess());
            t.Start();

            ini.CreateAndWriteIniFile("Setting", "ReStartButton", "ON/OFF", $"{restartCheck.Checked}");
            ini.CreateAndWriteIniFile("Setting", "Path", "Path", $"{label2.Text}");
            ini.CreateAndWriteIniFile("Setting", "ProcessName", "ProcessName", $"{ps.ProcessName}");
        }

        private void ButtonCheck(object sender, EventArgs e)
        {
            ps.ReStartCheck = restartCheck.Checked;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(ini.KeyValueReadIniFile("Log", $"{comboBox2.SelectedItem}").ToArray());
        }
    }
}
