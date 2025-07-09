using System.Web;
using processManagement.Service;

namespace processManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = string.Empty;
            label2.AutoSize = false;
            label2.Width = 300;
            label3.Text = "실행 할 프로그램을 종료하신 후 적용을 눌러주세요.";
        }

        ProcessService ps = new ProcessService();
        Thread t;



        private void fileOpen_Click(object sender, EventArgs e)
        {
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
        }

        private void ButtonCheck(object sender, EventArgs e)
        {
            ps.ReStartCheck = restartCheck.Checked;
        }
    }
}
