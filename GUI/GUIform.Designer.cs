﻿namespace GUI
{
    partial class GUIform
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
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.gaButton = new System.Windows.Forms.RadioButton();
            this.saButton = new System.Windows.Forms.RadioButton();
            this.hcButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.openFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.openFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.openFileButton.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileButton.ForeColor = System.Drawing.Color.Black;
            this.openFileButton.Location = new System.Drawing.Point(168, 304);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(145, 49);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Solving Algorithm:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // radioButton1
            // 
            this.hcButton.AutoSize = true;
            this.hcButton.Location = new System.Drawing.Point(338, 171);
            this.hcButton.Name = "radioButton1";
            this.hcButton.Size = new System.Drawing.Size(119, 24);
            this.hcButton.TabIndex = 4;
            this.hcButton.TabStop = true;
            this.hcButton.Text = "Hill Climbing";
            this.hcButton.UseVisualStyleBackColor = true;
            this.hcButton.CheckedChanged += new System.EventHandler(this.hcButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.saButton.AutoSize = true;
            this.saButton.Location = new System.Drawing.Point(338, 201);
            this.saButton.Name = "radioButton2";
            this.saButton.Size = new System.Drawing.Size(180, 24);
            this.saButton.TabIndex = 5;
            this.saButton.TabStop = true;
            this.saButton.Text = "Simulated Annealing";
            this.saButton.UseVisualStyleBackColor = true;
            this.hcButton.CheckedChanged += new System.EventHandler(this.saButton_CheckedChanged);
            // 
            // radioButton3
            // 
            this.gaButton.AutoSize = true;
            this.gaButton.Location = new System.Drawing.Point(338, 231);
            this.gaButton.Name = "radioButton3";
            this.gaButton.Size = new System.Drawing.Size(161, 24);
            this.gaButton.TabIndex = 6;
            this.gaButton.TabStop = true;
            this.gaButton.Text = "Genetic Algorithm";
            this.gaButton.UseVisualStyleBackColor = true;
            this.hcButton.CheckedChanged += new System.EventHandler(this.gaButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 108);
            this.label1.TabIndex = 7;
            this.label1.Text = "SLS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "SLS";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(419, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 54);
            this.button1.TabIndex = 9;
            this.button1.Text = "Solve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GUIform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 406);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hcButton);
            this.Controls.Add(this.saButton);
            this.Controls.Add(this.gaButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openFileButton);
            this.Name = "GUIform";
            this.Text = "SLS | Your Reliable Problem Solving Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton hcButton;
        private System.Windows.Forms.RadioButton saButton;
        private System.Windows.Forms.RadioButton gaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private string openedTestCasePath;

    }
}
