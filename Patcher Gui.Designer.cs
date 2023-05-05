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
            this.ChangeCursor = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ChangeSound = new System.Windows.Forms.CheckBox();
            this.ChangeFPSCap = new System.Windows.Forms.CheckBox();
            this.Logs = new System.Windows.Forms.TextBox();
            this.vulkanCheckBox = new System.Windows.Forms.CheckBox();
            this.FPS = new System.Windows.Forms.TextBox();
            this.UnlockFPS = new System.Windows.Forms.CheckBox();
            this.SelectAll = new System.Windows.Forms.Button();
            this.GraphicUnlock = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ChangeCursor
            // 
            this.ChangeCursor.AutoSize = true;
            this.ChangeCursor.Location = new System.Drawing.Point(330, 12);
            this.ChangeCursor.Name = "ChangeCursor";
            this.ChangeCursor.Size = new System.Drawing.Size(146, 19);
            this.ChangeCursor.TabIndex = 0;
            this.ChangeCursor.Text = "Change Cursor Texture";
            this.ChangeCursor.UseVisualStyleBackColor = true;
            this.ChangeCursor.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 63F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(204, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(286, 122);
            this.button1.TabIndex = 1;
            this.button1.Text = "Patch!";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangeSound
            // 
            this.ChangeSound.AutoSize = true;
            this.ChangeSound.Location = new System.Drawing.Point(330, 37);
            this.ChangeSound.Name = "ChangeSound";
            this.ChangeSound.Size = new System.Drawing.Size(138, 19);
            this.ChangeSound.TabIndex = 2;
            this.ChangeSound.Text = "Change Death Sound";
            this.ChangeSound.UseVisualStyleBackColor = true;
            this.ChangeSound.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ChangeFPSCap
            // 
            this.ChangeFPSCap.AutoSize = true;
            this.ChangeFPSCap.Location = new System.Drawing.Point(195, 62);
            this.ChangeFPSCap.Name = "ChangeFPSCap";
            this.ChangeFPSCap.Size = new System.Drawing.Size(113, 19);
            this.ChangeFPSCap.TabIndex = 3;
            this.ChangeFPSCap.Text = "Change FPS Cap";
            this.ChangeFPSCap.UseVisualStyleBackColor = true;
            this.ChangeFPSCap.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // Logs
            // 
            this.Logs.Location = new System.Drawing.Point(10, 112);
            this.Logs.Multiline = true;
            this.Logs.Name = "Logs";
            this.Logs.ReadOnly = true;
            this.Logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logs.Size = new System.Drawing.Size(188, 122);
            this.Logs.TabIndex = 4;
            this.Logs.TextChanged += new System.EventHandler(this.Logs_TextChanged);
            // 
            // vulkanCheckBox
            // 
            this.vulkanCheckBox.AutoSize = true;
            this.vulkanCheckBox.Location = new System.Drawing.Point(330, 87);
            this.vulkanCheckBox.Name = "vulkanCheckBox";
            this.vulkanCheckBox.Size = new System.Drawing.Size(154, 19);
            this.vulkanCheckBox.TabIndex = 5;
            this.vulkanCheckBox.Text = "Use Vulkan Graphics API";
            this.vulkanCheckBox.UseVisualStyleBackColor = true;
            this.vulkanCheckBox.CheckedChanged += new System.EventHandler(this.vulkanCheckBox_CheckedChanged);
            // 
            // FPS
            // 
            this.FPS.Location = new System.Drawing.Point(89, 60);
            this.FPS.Name = "FPS";
            this.FPS.Size = new System.Drawing.Size(100, 23);
            this.FPS.TabIndex = 6;
            this.FPS.TextChanged += new System.EventHandler(this.FPS_TextChanged);
            // 
            // UnlockFPS
            // 
            this.UnlockFPS.AutoSize = true;
            this.UnlockFPS.Location = new System.Drawing.Point(330, 62);
            this.UnlockFPS.Name = "UnlockFPS";
            this.UnlockFPS.Size = new System.Drawing.Size(85, 19);
            this.UnlockFPS.TabIndex = 7;
            this.UnlockFPS.Text = "Unlock FPS";
            this.UnlockFPS.UseVisualStyleBackColor = true;
            this.UnlockFPS.CheckedChanged += new System.EventHandler(this.UnlockFPS_CheckedChanged);
            // 
            // SelectAll
            // 
            this.SelectAll.Location = new System.Drawing.Point(10, 8);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(75, 23);
            this.SelectAll.TabIndex = 9;
            this.SelectAll.Text = "Select All";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // GraphicUnlock
            // 
            this.GraphicUnlock.AutoSize = true;
            this.GraphicUnlock.Location = new System.Drawing.Point(195, 12);
            this.GraphicUnlock.Name = "GraphicUnlock";
            this.GraphicUnlock.Size = new System.Drawing.Size(129, 19);
            this.GraphicUnlock.TabIndex = 10;
            this.GraphicUnlock.Text = "Unlock All Graphics";
            this.GraphicUnlock.UseVisualStyleBackColor = true;
            this.GraphicUnlock.CheckedChanged += new System.EventHandler(this.GraphicUnlock_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 240);
            this.Controls.Add(this.GraphicUnlock);
            this.Controls.Add(this.SelectAll);
            this.Controls.Add(this.UnlockFPS);
            this.Controls.Add(this.FPS);
            this.Controls.Add(this.vulkanCheckBox);
            this.Controls.Add(this.Logs);
            this.Controls.Add(this.ChangeFPSCap);
            this.Controls.Add(this.ChangeSound);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ChangeCursor);
            this.Name = "Form1";
            this.Text = "Roblox Patcher Made by StealthDrifter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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