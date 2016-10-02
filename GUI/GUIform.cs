using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.LS;

namespace GUI
{
    public partial class GUIform : Form
    {
        public GUIform()
        {
            InitializeComponent();
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            Stream fileTC = null;
            // Show the dialog and get result.
            DialogResult pathTestCase = openFileDialog1.ShowDialog();
            if (pathTestCase == DialogResult.OK) // Test result.
            {
                try
                {
                    if ((fileTC = openFileDialog1.OpenFile()) != null)
                    {
                        openedTestCasePath = openFileDialog1.FileName;
                        // Insert code to read the stream here.
                        fileTC.Close();
                        FileText.Text = openedTestCasePath;
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            Console.WriteLine(pathTestCase); // <-- For debugging use.
        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void hcButton_CheckedChanged(object sender, EventArgs e)
        {
            AlgoChoosed = 1;
        }

        private void saButton_CheckedChanged(object sender, EventArgs e)
        {
            AlgoChoosed = 2;
        }

        private void gaButton_CheckedChanged(object sender, EventArgs e)
        {
            AlgoChoosed = 3;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            bool FileChoosed = false;
            bool AlgorithmChecked = false;
            if (openedTestCasePath != null )
            {
                FileChoosed = true;
            }
            if (hcButton.Checked == true || gaButton.Checked == true || saButton.Checked == true)
            {
                AlgorithmChecked = true;
            }
            if (FileChoosed)
            {
                if (AlgorithmChecked)
                {
                    
                    this.Visible = false;

                    //Solve Problem
                    Solver sv = new Solver();
                    sv.Solve(openedTestCasePath,AlgoChoosed);
                    string Efektif = sv.jmlO.ToString() + " %";
                    S = new SolutionForm(sv.listMK,sv.listR,sv.jmlK.ToString(),Efektif);

                    // Calculate Conflict and Efektivity
                    //S.jmlConflict.Text = sv.jmlK.ToString();
                    //string Efektif = sv.jmlO.ToString() + " %";
                    //S.jmlEfektif.Text = Efektif;                   
                    S.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please choose algorithm for solve problem!");
                }
            }
            else
            { 
                MessageBox.Show("Please select the file first!");
            }
        }

        private void FileText_Click(object sender, EventArgs e)
        {

        }

    }
}
