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
            updateBools();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            updateBools();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            updateBools();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateBools();
            Roblox_Patcher.Start();
        }

        public void updateBools()
        {
            Roblox_Patcher.modifyCursor = checkBox1.Checked;
            Roblox_Patcher.modifyDeathSound = checkBox2.Checked;
            Roblox_Patcher.modifyFps= checkBox3.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}