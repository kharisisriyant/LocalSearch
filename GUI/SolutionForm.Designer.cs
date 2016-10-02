using GUI.LS;
namespace GUI
{
    partial class SolutionForm
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
            this.components = new System.ComponentModel.Container();
            this.optionRuang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.jmlConflict = new System.Windows.Forms.Label();
            this.jmlEfektif = new System.Windows.Forms.Label();
            this.tabel = new System.Windows.Forms.DataGridView();
            this.pilMatkul = new System.Windows.Forms.ComboBox();
            this.pilRuangan = new System.Windows.Forms.ComboBox();
            this.pilHari = new System.Windows.Forms.ComboBox();
            this.pilJam = new System.Windows.Forms.ComboBox();
            this.submitPindah = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.solverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solverBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // optionRuang
            // 
            this.optionRuang.FormattingEnabled = true;
            this.optionRuang.Location = new System.Drawing.Point(54, 25);
            this.optionRuang.Margin = new System.Windows.Forms.Padding(2);
            this.optionRuang.Name = "optionRuang";
            this.optionRuang.Size = new System.Drawing.Size(118, 21);
            this.optionRuang.TabIndex = 0;
            this.optionRuang.SelectedIndexChanged += new System.EventHandler(this.optionRuang_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conflict:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Effectivity: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // jmlConflict
            // 
            this.jmlConflict.AutoSize = true;
            this.jmlConflict.Location = new System.Drawing.Point(325, 25);
            this.jmlConflict.Name = "jmlConflict";
            this.jmlConflict.Size = new System.Drawing.Size(35, 13);
            this.jmlConflict.TabIndex = 7;
            this.jmlConflict.Text = "label3";
            this.jmlConflict.Click += new System.EventHandler(this.jmlConflict_Click);
            // 
            // jmlEfektif
            // 
            this.jmlEfektif.AutoSize = true;
            this.jmlEfektif.Location = new System.Drawing.Point(477, 25);
            this.jmlEfektif.Name = "jmlEfektif";
            this.jmlEfektif.Size = new System.Drawing.Size(35, 13);
            this.jmlEfektif.TabIndex = 8;
            this.jmlEfektif.Text = "label3";
            this.jmlEfektif.Click += new System.EventHandler(this.jmlEfektif_Click);
            // 
            // tabel
            // 
            this.tabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabel.Location = new System.Drawing.Point(24, 78);
            this.tabel.Name = "tabel";
            this.tabel.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.tabel.Size = new System.Drawing.Size(583, 266);
            this.tabel.TabIndex = 9;
            this.tabel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabel_CellContentClick);
            // 
            // pilMatkul
            // 
            this.pilMatkul.FormattingEnabled = true;
            this.pilMatkul.Location = new System.Drawing.Point(24, 383);
            this.pilMatkul.Name = "pilMatkul";
            this.pilMatkul.Size = new System.Drawing.Size(121, 21);
            this.pilMatkul.TabIndex = 10;
            this.pilMatkul.SelectedIndexChanged += new System.EventHandler(this.pilMatkul_SelectedIndexChanged);
            // 
            // pilRuangan
            // 
            this.pilRuangan.FormattingEnabled = true;
            this.pilRuangan.Location = new System.Drawing.Point(181, 383);
            this.pilRuangan.Name = "pilRuangan";
            this.pilRuangan.Size = new System.Drawing.Size(121, 21);
            this.pilRuangan.TabIndex = 11;
            this.pilRuangan.SelectedIndexChanged += new System.EventHandler(this.pilRuangan_SelectedIndexChanged);
            // 
            // pilHari
            // 
            this.pilHari.FormattingEnabled = true;
            this.pilHari.Location = new System.Drawing.Point(337, 383);
            this.pilHari.Name = "pilHari";
            this.pilHari.Size = new System.Drawing.Size(121, 21);
            this.pilHari.TabIndex = 12;
            this.pilHari.SelectedIndexChanged += new System.EventHandler(this.pilHari_SelectedIndexChanged);
            // 
            // pilJam
            // 
            this.pilJam.FormattingEnabled = true;
            this.pilJam.Location = new System.Drawing.Point(486, 383);
            this.pilJam.Name = "pilJam";
            this.pilJam.Size = new System.Drawing.Size(121, 21);
            this.pilJam.TabIndex = 13;
            this.pilJam.SelectedIndexChanged += new System.EventHandler(this.pilJam_SelectedIndexChanged);
            // 
            // submitPindah
            // 
            this.submitPindah.Location = new System.Drawing.Point(532, 410);
            this.submitPindah.Name = "submitPindah";
            this.submitPindah.Size = new System.Drawing.Size(75, 23);
            this.submitPindah.TabIndex = 14;
            this.submitPindah.Text = "Change";
            this.submitPindah.UseVisualStyleBackColor = true;
            this.submitPindah.Click += new System.EventHandler(this.submitPindah_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Course Option";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Room Option";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Day Option";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(483, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Start Hour Option";
            // 
            // solverBindingSource
            // 
            this.solverBindingSource.DataSource = typeof(GUI.LS.Solver);
            // 
            // SolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 443);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.submitPindah);
            this.Controls.Add(this.pilJam);
            this.Controls.Add(this.pilHari);
            this.Controls.Add(this.pilRuangan);
            this.Controls.Add(this.pilMatkul);
            this.Controls.Add(this.tabel);
            this.Controls.Add(this.jmlEfektif);
            this.Controls.Add(this.jmlConflict);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optionRuang);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SolutionForm";
            this.Text = "SolutionForm";
            ((System.ComponentModel.ISupportInitialize)(this.tabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solverBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox optionRuang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label jmlConflict;
        public System.Windows.Forms.Label jmlEfektif;
        private System.Windows.Forms.BindingSource solverBindingSource;
        public System.Windows.Forms.DataGridView tabel;
        private System.Windows.Forms.ComboBox pilMatkul;
        private System.Windows.Forms.ComboBox pilRuangan;
        private System.Windows.Forms.ComboBox pilHari;
        private System.Windows.Forms.ComboBox pilJam;
        private System.Windows.Forms.Button submitPindah;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}