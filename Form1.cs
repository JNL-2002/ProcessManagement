using System.Web;
using processService;

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
        }

        string restartPath = string.Empty;

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
            processServiceClass processServiceClass = new processServiceClass($"{label2}\\{comboBox1.SelectedItem}");

            processServiceClass.Restart(restartCheck.Checked);
            
        }
    }
}
