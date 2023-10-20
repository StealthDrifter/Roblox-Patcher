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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ChangeCursor = new CheckBox();
            button1 = new Button();
            ChangeSound = new CheckBox();
            ChangeFPSCap = new CheckBox();
            Logs = new TextBox();
            vulkanCheckBox = new CheckBox();
            FPS = new TextBox();
            UnlockFPS = new CheckBox();
            SelectAll = new Button();
            GraphicUnlock = new CheckBox();
            SuspendLayout();
            // 
            // ChangeCursor
            // 
            ChangeCursor.AutoSize = true;
            ChangeCursor.Location = new Point(330, 12);
            ChangeCursor.Name = "ChangeCursor";
            ChangeCursor.Size = new Size(146, 19);
            ChangeCursor.TabIndex = 0;
            ChangeCursor.Text = "Change Cursor Texture";
            ChangeCursor.UseVisualStyleBackColor = true;
            ChangeCursor.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(24, 24, 24);
            button1.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 63F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(204, 112);
            button1.Name = "button1";
            button1.Size = new Size(286, 122);
            button1.TabIndex = 1;
            button1.Text = "Patch!";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ChangeSound
            // 
            ChangeSound.AutoSize = true;
            ChangeSound.Location = new Point(330, 37);
            ChangeSound.Name = "ChangeSound";
            ChangeSound.Size = new Size(138, 19);
            ChangeSound.TabIndex = 2;
            ChangeSound.Text = "Change Death Sound";
            ChangeSound.UseVisualStyleBackColor = true;
            ChangeSound.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // ChangeFPSCap
            // 
            ChangeFPSCap.AutoSize = true;
            ChangeFPSCap.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 192, 0);
            ChangeFPSCap.Location = new Point(195, 62);
            ChangeFPSCap.Name = "ChangeFPSCap";
            ChangeFPSCap.Size = new Size(113, 19);
            ChangeFPSCap.TabIndex = 3;
            ChangeFPSCap.Text = "Change FPS Cap";
            ChangeFPSCap.UseVisualStyleBackColor = true;
            ChangeFPSCap.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // Logs
            // 
            Logs.BackColor = Color.FromArgb(24, 24, 24);
            Logs.BorderStyle = BorderStyle.FixedSingle;
            Logs.ForeColor = SystemColors.Window;
            Logs.Location = new Point(10, 112);
            Logs.Multiline = true;
            Logs.Name = "Logs";
            Logs.ReadOnly = true;
            Logs.ScrollBars = ScrollBars.Vertical;
            Logs.Size = new Size(188, 122);
            Logs.TabIndex = 4;
            Logs.TextChanged += Logs_TextChanged;
            // 
            // vulkanCheckBox
            // 
            vulkanCheckBox.AutoSize = true;
            vulkanCheckBox.Location = new Point(330, 87);
            vulkanCheckBox.Name = "vulkanCheckBox";
            vulkanCheckBox.Size = new Size(154, 19);
            vulkanCheckBox.TabIndex = 5;
            vulkanCheckBox.Text = "Use Vulkan Graphics API";
            vulkanCheckBox.UseVisualStyleBackColor = true;
            vulkanCheckBox.CheckedChanged += vulkanCheckBox_CheckedChanged;
            // 
            // FPS
            // 
            FPS.BackColor = Color.FromArgb(24, 24, 24);
            FPS.BorderStyle = BorderStyle.FixedSingle;
            FPS.ForeColor = SystemColors.Window;
            FPS.Location = new Point(89, 60);
            FPS.Name = "FPS";
            FPS.Size = new Size(100, 23);
            FPS.TabIndex = 6;
            FPS.TextChanged += FPS_TextChanged;
            // 
            // UnlockFPS
            // 
            UnlockFPS.AutoSize = true;
            UnlockFPS.Location = new Point(330, 62);
            UnlockFPS.Name = "UnlockFPS";
            UnlockFPS.Size = new Size(85, 19);
            UnlockFPS.TabIndex = 7;
            UnlockFPS.Text = "Unlock FPS";
            UnlockFPS.UseVisualStyleBackColor = true;
            UnlockFPS.CheckedChanged += UnlockFPS_CheckedChanged;
            // 
            // SelectAll
            // 
            SelectAll.BackColor = Color.FromArgb(24, 24, 24);
            SelectAll.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            SelectAll.FlatStyle = FlatStyle.Flat;
            SelectAll.Location = new Point(10, 8);
            SelectAll.Name = "SelectAll";
            SelectAll.Size = new Size(75, 23);
            SelectAll.TabIndex = 9;
            SelectAll.Text = "Select All";
            SelectAll.UseVisualStyleBackColor = false;
            SelectAll.Click += SelectAll_Click;
            // 
            // GraphicUnlock
            // 
            GraphicUnlock.AutoSize = true;
            GraphicUnlock.Location = new Point(195, 12);
            GraphicUnlock.Name = "GraphicUnlock";
            GraphicUnlock.Size = new Size(129, 19);
            GraphicUnlock.TabIndex = 10;
            GraphicUnlock.Text = "Unlock All Graphics";
            GraphicUnlock.UseVisualStyleBackColor = true;
            GraphicUnlock.CheckedChanged += GraphicUnlock_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(496, 240);
            Controls.Add(GraphicUnlock);
            Controls.Add(SelectAll);
            Controls.Add(UnlockFPS);
            Controls.Add(FPS);
            Controls.Add(vulkanCheckBox);
            Controls.Add(Logs);
            Controls.Add(ChangeFPSCap);
            Controls.Add(ChangeSound);
            Controls.Add(button1);
            Controls.Add(ChangeCursor);
            ForeColor = SystemColors.Control;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Roblox Patcher Made by StealthDrifter";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox ChangeCursor;
        private Button button1;
        private CheckBox ChangeSound;
        private CheckBox ChangeFPSCap;
        private TextBox Logs;
        private CheckBox vulkanCheckBox;
        private TextBox FPS;
        private CheckBox UnlockFPS;
        private Button SelectAll;
        private CheckBox GraphicUnlock;
    }
}