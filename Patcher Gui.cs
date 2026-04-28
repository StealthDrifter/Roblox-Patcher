using Roblox_Patcher;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool _changingVisibility = false;

        public Form1()
        {
            InitializeComponent();
            Program.ShowFormEvent += ShowForm;
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // change cursor checkbox
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // change death sound checkbox
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
            Program.modifyConfig = vulkanCheckBox.Checked;
            Program.vulkan = vulkanCheckBox.Checked;
            Program.setVolume = volumeControl.Checked;
        }

        public void ShowForm()
        {
            Show();
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
            BringToFront();
            Activate();
            Program.background = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Contains("--startup"))
            {
                WindowState = FormWindowState.Minimized;
                Hide();
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                Program.background = true;
                _ = new Listener().RobloxListener(Logs);
                Program.ListenerStarted = true;
            }
        }

        private void Logs_TextChanged(object sender, EventArgs e)
        {
        }

        private void FPS_TextChanged(object sender, EventArgs e)
        {
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            ChangeCursor.Checked = true;
            ChangeSound.Checked = true;
            vulkanCheckBox.Checked = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                Program.background = true;
                Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
            BringToFront();
            Activate();
            Program.background = false;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            // volume control
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // volume display
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            Program.volume = trackBar1.Value;
        }

        private void onStartup_CheckedChanged(object sender, EventArgs e)
        {
            Program.SetStartup(onStartup.Checked);
        }
    }
}
