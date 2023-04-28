using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateBools();
            Program.Start(Logs);
        }

        public void updateBools()
        {
            Program.modifyCursor = checkBox1.Checked;
            Program.modifyDeathSound = checkBox2.Checked;
            Program.modifyFps = checkBox3.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void addItemToListBox(string item)
        {
            Logs.Text += item + Environment.NewLine;
        }

        private void Logs_TextChanged(object sender, EventArgs e)
        {

        }
    }
}