using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FPS.Visible = false;
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // change cursor checkbox
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // change death sound checkbox
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            // change FPS cap checkbox
            FPS.Visible = ChangeFPSCap.Checked;
            if (!ChangeFPSCap.Checked) 
            {
                Program.fps = 0;
            }
        }
        
        private void UnlockFPS_CheckedChanged(object sender, EventArgs e)
        {
            if (UnlockFPS.Checked)
            {
                ChangeFPSCap.Visible = false;
                ChangeFPSCap.Checked = false;
                Program.fps = 99999999;
            }
            if (!UnlockFPS.Checked)
            {
                ChangeFPSCap.Visible = true;
                Program.fps = 0;
            }
        }
        private void vulkanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void GraphicUnlock_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateBools();
            Program.Start(Logs);
        }

        public void updateBools()
        {
            Program.modifyCursor = ChangeCursor.Checked;
            Program.modifyDeathSound = ChangeSound.Checked;
            Program.modifyConfig = UnlockFPS.Checked || ChangeFPSCap.Checked || vulkanCheckBox.Checked || GraphicUnlock.Checked;
            Program.vulkan = vulkanCheckBox.Checked;
            Program.allGraphics = GraphicUnlock.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Logs_TextChanged(object sender, EventArgs e)
        {
        }

        private void FPS_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(FPS.Text, out var fpsvar))
            {
                Program.fps = fpsvar;
            }
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            ChangeCursor.Checked = true;
            ChangeSound.Checked = true;
            UnlockFPS.Checked = true;
            vulkanCheckBox.Checked = true;
            GraphicUnlock.Checked = true;
        }

    }
}