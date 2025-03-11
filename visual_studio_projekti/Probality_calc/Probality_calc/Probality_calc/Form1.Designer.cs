namespace Probality_calc
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AnsInfo = new System.Windows.Forms.Label();
            this.EventBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Calculate = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.Setting_Button = new System.Windows.Forms.Button();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.D10 = new System.Windows.Forms.Button();
            this.D6 = new System.Windows.Forms.Button();
            this.D20 = new System.Windows.Forms.Button();
            this.D4 = new System.Windows.Forms.Button();
            this.D12 = new System.Windows.Forms.Button();
            this.D8 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AnsInfo
            // 
            this.AnsInfo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AnsInfo.Location = new System.Drawing.Point(220, 281);
            this.AnsInfo.Name = "AnsInfo";
            this.AnsInfo.Size = new System.Drawing.Size(564, 145);
            this.AnsInfo.TabIndex = 6;
            // 
            // EventBoard
            // 
            this.EventBoard.AutoScroll = true;
            this.EventBoard.BackColor = System.Drawing.SystemColors.ControlDark;
            this.EventBoard.Location = new System.Drawing.Point(223, 12);
            this.EventBoard.Name = "EventBoard";
            this.EventBoard.Size = new System.Drawing.Size(561, 220);
            this.EventBoard.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.D10);
            this.panel2.Controls.Add(this.D6);
            this.panel2.Controls.Add(this.D20);
            this.panel2.Controls.Add(this.D4);
            this.panel2.Controls.Add(this.D12);
            this.panel2.Controls.Add(this.D8);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 256);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Location = new System.Drawing.Point(12, 281);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 145);
            this.panel3.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 59);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 59);
            this.button4.TabIndex = 1;
            this.button4.Text = "custom";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 72);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 59);
            this.button6.TabIndex = 3;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(223, 238);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 30);
            this.Clear.TabIndex = 6;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(314, 238);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(75, 30);
            this.Calculate.TabIndex = 7;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(405, 238);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 30);
            this.button7.TabIndex = 10;
            this.button7.Text = "Roll";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // Setting_Button
            // 
            this.Setting_Button.Location = new System.Drawing.Point(728, 238);
            this.Setting_Button.Name = "Setting_Button";
            this.Setting_Button.Size = new System.Drawing.Size(55, 29);
            this.Setting_Button.TabIndex = 11;
            this.Setting_Button.Text = "Settings";
            this.Setting_Button.UseVisualStyleBackColor = true;
            this.Setting_Button.Click += new System.EventHandler(this.Setting_Button_Click);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Location = new System.Drawing.Point(662, 257);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(10, 10);
            this.settingsPanel.TabIndex = 12;
            // 
            // D10
            // 
            this.D10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("D10.BackgroundImage")));
            this.D10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.D10.Location = new System.Drawing.Point(93, 72);
            this.D10.Name = "D10";
            this.D10.Size = new System.Drawing.Size(75, 59);
            this.D10.TabIndex = 2;
            this.D10.UseVisualStyleBackColor = true;
            this.D10.Click += new System.EventHandler(this.D21_Click);
            // 
            // D6
            // 
            this.D6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("D6.BackgroundImage")));
            this.D6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.D6.Location = new System.Drawing.Point(93, 7);
            this.D6.Name = "D6";
            this.D6.Size = new System.Drawing.Size(75, 59);
            this.D6.TabIndex = 0;
            this.D6.UseVisualStyleBackColor = true;
            this.D6.Click += new System.EventHandler(this.D6_Click);
            // 
            // D20
            // 
            this.D20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("D20.BackgroundImage")));
            this.D20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.D20.Location = new System.Drawing.Point(93, 137);
            this.D20.Name = "D20";
            this.D20.Size = new System.Drawing.Size(75, 59);
            this.D20.TabIndex = 5;
            this.D20.UseVisualStyleBackColor = true;
            this.D20.Click += new System.EventHandler(this.D60_Click);
            // 
            // D4
            // 
            this.D4.BackgroundImage = global::Probality_calc.Properties.Resources.D4;
            this.D4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.D4.Location = new System.Drawing.Point(12, 7);
            this.D4.Name = "D4";
            this.D4.Size = new System.Drawing.Size(75, 59);
            this.D4.TabIndex = 1;
            this.D4.UseVisualStyleBackColor = true;
            this.D4.Click += new System.EventHandler(this.Coin_Click);
            // 
            // D12
            // 
            this.D12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("D12.BackgroundImage")));
            this.D12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.D12.Location = new System.Drawing.Point(12, 137);
            this.D12.Name = "D12";
            this.D12.Size = new System.Drawing.Size(75, 59);
            this.D12.TabIndex = 4;
            this.D12.UseVisualStyleBackColor = true;
            this.D12.Click += new System.EventHandler(this.D40_Click);
            // 
            // D8
            // 
            this.D8.BackgroundImage = global::Probality_calc.Properties.Resources.D8;
            this.D8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.D8.Location = new System.Drawing.Point(12, 72);
            this.D8.Name = "D8";
            this.D8.Size = new System.Drawing.Size(75, 59);
            this.D8.TabIndex = 3;
            this.D8.UseVisualStyleBackColor = true;
            this.D8.Click += new System.EventHandler(this.D12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 450);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.Setting_Button);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.EventBoard);
            this.Controls.Add(this.AnsInfo);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button D6;
        private System.Windows.Forms.Button D4;
        private System.Windows.Forms.Button D10;
        private System.Windows.Forms.Button D8;
        private System.Windows.Forms.Button D12;
        private System.Windows.Forms.Button D20;
        private System.Windows.Forms.Label AnsInfo;
        private System.Windows.Forms.Panel EventBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button Setting_Button;
        private System.Windows.Forms.Panel settingsPanel;
    }
}

