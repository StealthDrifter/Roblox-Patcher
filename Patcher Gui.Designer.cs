using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ChangeCursor = new CheckBox();
            button1 = new Button();
            ChangeSound = new CheckBox();
            Logs = new TextBox();
            vulkanCheckBox = new CheckBox();
            SelectAll = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            volumeControl = new CheckBox();
            textBox1 = new TextBox();
            trackBar1 = new TrackBar();
            label1 = new Label();
            notifyIcon1 = new NotifyIcon(components);
            onStartup = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // ChangeCursor
            // 
            ChangeCursor.Anchor = AnchorStyles.None;
            ChangeCursor.AutoSize = true;
            ChangeCursor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ChangeCursor.Location = new Point(8, 51);
            ChangeCursor.Margin = new Padding(4, 3, 4, 3);
            ChangeCursor.Name = "ChangeCursor";
            ChangeCursor.Size = new Size(186, 25);
            ChangeCursor.TabIndex = 0;
            ChangeCursor.Text = "Change Cursor Texture";
            ChangeCursor.UseVisualStyleBackColor = true;
            ChangeCursor.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(24, 24, 24);
            button1.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(179, 29);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(179, 147);
            button1.TabIndex = 1;
            button1.Text = "Patch";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ChangeSound
            // 
            ChangeSound.Anchor = AnchorStyles.None;
            ChangeSound.AutoSize = true;
            ChangeSound.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ChangeSound.Location = new Point(8, 20);
            ChangeSound.Margin = new Padding(4, 3, 4, 3);
            ChangeSound.Name = "ChangeSound";
            ChangeSound.Size = new Size(176, 25);
            ChangeSound.TabIndex = 2;
            ChangeSound.Text = "Change Death Sound";
            ChangeSound.UseVisualStyleBackColor = true;
            ChangeSound.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // Logs
            // 
            Logs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Logs.BackColor = Color.FromArgb(24, 24, 24);
            Logs.BorderStyle = BorderStyle.FixedSingle;
            Logs.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Logs.ForeColor = SystemColors.Window;
            Logs.Location = new Point(8, 24);
            Logs.Margin = new Padding(4, 3, 4, 3);
            Logs.Multiline = true;
            Logs.Name = "Logs";
            Logs.ReadOnly = true;
            Logs.ScrollBars = ScrollBars.Vertical;
            Logs.Size = new Size(166, 154);
            Logs.TabIndex = 4;
            Logs.TextChanged += Logs_TextChanged;
            // 
            // vulkanCheckBox
            // 
            vulkanCheckBox.Anchor = AnchorStyles.None;
            vulkanCheckBox.AutoSize = true;
            vulkanCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            vulkanCheckBox.Location = new Point(8, 82);
            vulkanCheckBox.Margin = new Padding(4, 3, 4, 3);
            vulkanCheckBox.Name = "vulkanCheckBox";
            vulkanCheckBox.Size = new Size(199, 25);
            vulkanCheckBox.TabIndex = 5;
            vulkanCheckBox.Text = "Use Vulkan Graphics API";
            vulkanCheckBox.UseVisualStyleBackColor = true;
            vulkanCheckBox.CheckedChanged += vulkanCheckBox_CheckedChanged;
            // 
            // SelectAll
            // 
            SelectAll.Anchor = AnchorStyles.None;
            SelectAll.BackColor = Color.FromArgb(24, 24, 24);
            SelectAll.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            SelectAll.FlatStyle = FlatStyle.Flat;
            SelectAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SelectAll.Location = new Point(226, 158);
            SelectAll.Margin = new Padding(4, 3, 4, 3);
            SelectAll.Name = "SelectAll";
            SelectAll.Size = new Size(132, 33);
            SelectAll.TabIndex = 9;
            SelectAll.Text = "Select All";
            SelectAll.UseVisualStyleBackColor = false;
            SelectAll.Click += SelectAll_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.FromArgb(15, 15, 15);
            groupBox1.Controls.Add(Logs);
            groupBox1.Controls.Add(button1);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(14, 217);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(366, 189);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Main";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.BackColor = Color.FromArgb(15, 15, 15);
            groupBox2.Controls.Add(onStartup);
            groupBox2.Controls.Add(volumeControl);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(trackBar1);
            groupBox2.Controls.Add(ChangeCursor);
            groupBox2.Controls.Add(SelectAll);
            groupBox2.Controls.Add(ChangeSound);
            groupBox2.Controls.Add(vulkanCheckBox);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(14, 14);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(366, 197);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Patches";
            // 
            // volumeControl
            // 
            volumeControl.AutoSize = true;
            volumeControl.Location = new Point(8, 116);
            volumeControl.Name = "volumeControl";
            volumeControl.Size = new Size(78, 24);
            volumeControl.TabIndex = 12;
            volumeControl.Text = "Volume";
            volumeControl.UseVisualStyleBackColor = true;
            volumeControl.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(24, 24, 24);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(92, 115);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 27);
            textBox1.TabIndex = 11;
            textBox1.Text = "100";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(8, 146);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(199, 45);
            trackBar1.TabIndex = 10;
            trackBar1.TickFrequency = 25;
            trackBar1.Value = 100;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(193, 1);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(160, 20);
            label1.TabIndex = 11;
            label1.Text = "Made by StealthDrifter";
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "RBXPatcher";
            notifyIcon1.DoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // onStartup
            // 
            onStartup.AutoSize = true;
            onStartup.Location = new Point(230, 20);
            onStartup.Name = "onStartup";
            onStartup.Size = new Size(128, 24);
            onStartup.TabIndex = 13;
            onStartup.Text = "Run On Startup";
            onStartup.UseVisualStyleBackColor = true;
            onStartup.CheckedChanged += onStartup_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(394, 418);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.Control;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(410, 429);
            Name = "Form1";
            Text = "RBXPatcher";
            Load += Form1_Load;
            Resize += Form1_Resize;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox ChangeCursor;
        private Button button1;
        private CheckBox ChangeSound;
        private TextBox Logs;
        private CheckBox vulkanCheckBox;
        private Button SelectAll;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private NotifyIcon notifyIcon1;
        private TrackBar trackBar1;
        private TextBox textBox1;
        private CheckBox volumeControl;
        private CheckBox onStartup;
    }
}

