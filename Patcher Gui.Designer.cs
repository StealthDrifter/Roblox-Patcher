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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // ChangeCursor
            // 
            ChangeCursor.Anchor = AnchorStyles.Right;
            ChangeCursor.AutoSize = true;
            ChangeCursor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ChangeCursor.Location = new Point(10, 88);
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
            button1.Location = new Point(179, 27);
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
            ChangeSound.Anchor = AnchorStyles.Right;
            ChangeSound.AutoSize = true;
            ChangeSound.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ChangeSound.Location = new Point(10, 57);
            ChangeSound.Margin = new Padding(4, 3, 4, 3);
            ChangeSound.Name = "ChangeSound";
            ChangeSound.Size = new Size(176, 25);
            ChangeSound.TabIndex = 2;
            ChangeSound.Text = "Change Death Sound";
            ChangeSound.UseVisualStyleBackColor = true;
            ChangeSound.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // ChangeFPSCap
            // 
            ChangeFPSCap.Anchor = AnchorStyles.Right;
            ChangeFPSCap.AutoSize = true;
            ChangeFPSCap.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 192, 0);
            ChangeFPSCap.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ChangeFPSCap.Location = new Point(125, 26);
            ChangeFPSCap.Margin = new Padding(4, 3, 4, 3);
            ChangeFPSCap.Name = "ChangeFPSCap";
            ChangeFPSCap.Size = new Size(143, 25);
            ChangeFPSCap.TabIndex = 3;
            ChangeFPSCap.Text = "Change FPS Cap";
            ChangeFPSCap.UseVisualStyleBackColor = true;
            ChangeFPSCap.CheckedChanged += checkBox3_CheckedChanged;
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
            Logs.Size = new Size(166, 150);
            Logs.TabIndex = 4;
            Logs.TextChanged += Logs_TextChanged;
            // 
            // vulkanCheckBox
            // 
            vulkanCheckBox.Anchor = AnchorStyles.Right;
            vulkanCheckBox.AutoSize = true;
            vulkanCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            vulkanCheckBox.Location = new Point(10, 150);
            vulkanCheckBox.Margin = new Padding(4, 3, 4, 3);
            vulkanCheckBox.Name = "vulkanCheckBox";
            vulkanCheckBox.Size = new Size(199, 25);
            vulkanCheckBox.TabIndex = 5;
            vulkanCheckBox.Text = "Use Vulkan Graphics API";
            vulkanCheckBox.UseVisualStyleBackColor = true;
            vulkanCheckBox.CheckedChanged += vulkanCheckBox_CheckedChanged;
            // 
            // FPS
            // 
            FPS.Anchor = AnchorStyles.Right;
            FPS.BackColor = Color.FromArgb(24, 24, 24);
            FPS.BorderStyle = BorderStyle.FixedSingle;
            FPS.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FPS.ForeColor = SystemColors.Window;
            FPS.Location = new Point(276, 23);
            FPS.Margin = new Padding(4, 3, 4, 3);
            FPS.Name = "FPS";
            FPS.Size = new Size(82, 29);
            FPS.TabIndex = 6;
            FPS.TextChanged += FPS_TextChanged;
            // 
            // UnlockFPS
            // 
            UnlockFPS.Anchor = AnchorStyles.Right;
            UnlockFPS.AutoSize = true;
            UnlockFPS.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UnlockFPS.Location = new Point(10, 26);
            UnlockFPS.Margin = new Padding(4, 3, 4, 3);
            UnlockFPS.Name = "UnlockFPS";
            UnlockFPS.Size = new Size(107, 25);
            UnlockFPS.TabIndex = 7;
            UnlockFPS.Text = "Unlock FPS";
            UnlockFPS.UseVisualStyleBackColor = true;
            UnlockFPS.CheckedChanged += UnlockFPS_CheckedChanged;
            // 
            // SelectAll
            // 
            SelectAll.Anchor = AnchorStyles.Right;
            SelectAll.BackColor = Color.FromArgb(24, 24, 24);
            SelectAll.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            SelectAll.FlatStyle = FlatStyle.Flat;
            SelectAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SelectAll.Location = new Point(226, 161);
            SelectAll.Margin = new Padding(4, 3, 4, 3);
            SelectAll.Name = "SelectAll";
            SelectAll.Size = new Size(132, 33);
            SelectAll.TabIndex = 9;
            SelectAll.Text = "Select All";
            SelectAll.UseVisualStyleBackColor = false;
            SelectAll.Click += SelectAll_Click;
            // 
            // GraphicUnlock
            // 
            GraphicUnlock.Anchor = AnchorStyles.Right;
            GraphicUnlock.AutoSize = true;
            GraphicUnlock.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GraphicUnlock.Location = new Point(10, 119);
            GraphicUnlock.Margin = new Padding(4, 3, 4, 3);
            GraphicUnlock.Name = "GraphicUnlock";
            GraphicUnlock.Size = new Size(164, 25);
            GraphicUnlock.TabIndex = 10;
            GraphicUnlock.Text = "Unlock All Graphics";
            GraphicUnlock.UseVisualStyleBackColor = true;
            GraphicUnlock.CheckedChanged += GraphicUnlock_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.FromArgb(15, 15, 15);
            groupBox1.Controls.Add(Logs);
            groupBox1.Controls.Add(button1);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(14, 220);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(366, 185);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Main";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.BackColor = Color.FromArgb(15, 15, 15);
            groupBox2.Controls.Add(GraphicUnlock);
            groupBox2.Controls.Add(ChangeCursor);
            groupBox2.Controls.Add(SelectAll);
            groupBox2.Controls.Add(ChangeSound);
            groupBox2.Controls.Add(FPS);
            groupBox2.Controls.Add(ChangeFPSCap);
            groupBox2.Controls.Add(UnlockFPS);
            groupBox2.Controls.Add(vulkanCheckBox);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(14, 14);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(366, 200);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Patches";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(394, 417);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.Control;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(410, 456);
            Name = "Form1";
            Text = "RBXPatcher";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
    }
}

