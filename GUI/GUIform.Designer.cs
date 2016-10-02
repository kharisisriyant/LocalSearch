namespace GUI
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
            this.SolveButton = new System.Windows.Forms.Button();
            this.FileText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.openFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.openFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.openFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileButton.ForeColor = System.Drawing.Color.Black;
            this.openFileButton.Location = new System.Drawing.Point(119, 293);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(117, 35);
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
            this.label2.Location = new System.Drawing.Point(127, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Solving Algorithm:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gaButton
            // 
            this.gaButton.AutoSize = true;
            this.gaButton.Location = new System.Drawing.Point(225, 220);
            this.gaButton.Margin = new System.Windows.Forms.Padding(2);
            this.gaButton.Name = "gaButton";
            this.gaButton.Size = new System.Drawing.Size(108, 17);
            this.gaButton.TabIndex = 6;
            this.gaButton.TabStop = true;
            this.gaButton.Text = "Genetic Algorithm";
            this.gaButton.UseVisualStyleBackColor = true;
            this.gaButton.CheckedChanged += new System.EventHandler(this.gaButton_CheckedChanged);
            // 
            // saButton
            // 
            this.saButton.AutoSize = true;
            this.saButton.Location = new System.Drawing.Point(225, 199);
            this.saButton.Margin = new System.Windows.Forms.Padding(2);
            this.saButton.Name = "saButton";
            this.saButton.Size = new System.Drawing.Size(121, 17);
            this.saButton.TabIndex = 5;
            this.saButton.TabStop = true;
            this.saButton.Text = "Simulated Annealing";
            this.saButton.UseVisualStyleBackColor = true;
            this.saButton.CheckedChanged += new System.EventHandler(this.saButton_CheckedChanged);
            // 
            // hcButton
            // 
            this.hcButton.AutoSize = true;
            this.hcButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hcButton.Location = new System.Drawing.Point(225, 178);
            this.hcButton.Margin = new System.Windows.Forms.Padding(2);
            this.hcButton.Name = "hcButton";
            this.hcButton.Size = new System.Drawing.Size(81, 17);
            this.hcButton.TabIndex = 4;
            this.hcButton.TabStop = true;
            this.hcButton.Text = "Hill Climbing";
            this.hcButton.UseVisualStyleBackColor = true;
            this.hcButton.CheckedChanged += new System.EventHandler(this.hcButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 55);
            this.label1.TabIndex = 7;
            this.label1.Text = "SLS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(379, 36);
            this.label3.TabIndex = 8;
            this.label3.Text = "SLS is a software that can solve the scheduling problem \r\n             by applyin" +
    "g a local search algorithm";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // SolveButton
            // 
            this.SolveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SolveButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SolveButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.SolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolveButton.ForeColor = System.Drawing.Color.Black;
            this.SolveButton.Location = new System.Drawing.Point(328, 293);
            this.SolveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(126, 35);
            this.SolveButton.TabIndex = 9;
            this.SolveButton.Text = "Solve";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // FileText
            // 
            this.FileText.AutoSize = true;
            this.FileText.Location = new System.Drawing.Point(116, 278);
            this.FileText.Name = "FileText";
            this.FileText.Size = new System.Drawing.Size(85, 13);
            this.FileText.TabIndex = 10;
            this.FileText.Text = "No File Choosen";
            this.FileText.Click += new System.EventHandler(this.FileText_Click);
            // 
            // GUIform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 373);
            this.Controls.Add(this.FileText);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hcButton);
            this.Controls.Add(this.saButton);
            this.Controls.Add(this.gaButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openFileButton);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.Label FileText;
        public  string openedTestCasePath;
        public int AlgoChoosed = 1;
        public SolutionForm S;
    }
}

