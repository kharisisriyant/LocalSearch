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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUIform));
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gaButton = new System.Windows.Forms.RadioButton();
            this.saButton = new System.Windows.Forms.RadioButton();
            this.hcButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SolveButton = new System.Windows.Forms.Button();
            this.FileText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.openFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.openFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.openFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileButton.ForeColor = System.Drawing.Color.Black;
            this.openFileButton.Location = new System.Drawing.Point(193, 483);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(156, 43);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text|*.txt";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk_1);
            // 
            // gaButton
            // 
            this.gaButton.AutoSize = true;
            this.gaButton.Location = new System.Drawing.Point(22, 76);
            this.gaButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gaButton.Name = "gaButton";
            this.gaButton.Size = new System.Drawing.Size(164, 24);
            this.gaButton.TabIndex = 6;
            this.gaButton.Text = "Genetic Algorithm";
            this.gaButton.UseVisualStyleBackColor = true;
            this.gaButton.CheckedChanged += new System.EventHandler(this.gaButton_CheckedChanged);
            // 
            // saButton
            // 
            this.saButton.AutoSize = true;
            this.saButton.Location = new System.Drawing.Point(22, 50);
            this.saButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saButton.Name = "saButton";
            this.saButton.Size = new System.Drawing.Size(182, 24);
            this.saButton.TabIndex = 5;
            this.saButton.Text = "Simulated Annealing";
            this.saButton.UseVisualStyleBackColor = true;
            this.saButton.CheckedChanged += new System.EventHandler(this.saButton_CheckedChanged);
            // 
            // hcButton
            // 
            this.hcButton.AutoSize = true;
            this.hcButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hcButton.Checked = true;
            this.hcButton.Location = new System.Drawing.Point(22, 24);
            this.hcButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hcButton.Name = "hcButton";
            this.hcButton.Size = new System.Drawing.Size(125, 24);
            this.hcButton.TabIndex = 4;
            this.hcButton.TabStop = true;
            this.hcButton.Text = "Hill Climbing";
            this.hcButton.UseVisualStyleBackColor = true;
            this.hcButton.CheckedChanged += new System.EventHandler(this.hcButton_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(155, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(479, 48);
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
            this.SolveButton.Location = new System.Drawing.Point(421, 483);
            this.SolveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(168, 43);
            this.SolveButton.TabIndex = 9;
            this.SolveButton.Text = "Solve";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // FileText
            // 
            this.FileText.AutoSize = true;
            this.FileText.Location = new System.Drawing.Point(190, 464);
            this.FileText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FileText.Name = "FileText";
            this.FileText.Size = new System.Drawing.Size(112, 17);
            this.FileText.TabIndex = 10;
            this.FileText.Text = "No File Choosen";
            this.FileText.Click += new System.EventHandler(this.FileText_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(219, -25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.hcButton);
            this.groupBox1.Controls.Add(this.saButton);
            this.groupBox1.Controls.Add(this.gaButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(272, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 116);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solving Algorithm";
            // 
            // GUIform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FileText);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "GUIform";
            this.Text = "SLS | Your Schedule Planner";
            this.Load += new System.EventHandler(this.GUIform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton hcButton;
        private System.Windows.Forms.RadioButton saButton;
        private System.Windows.Forms.RadioButton gaButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.Label FileText;
        public  string openedTestCasePath;
        public int AlgoChoosed = 1;
        public SolutionForm S;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

