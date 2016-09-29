using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Show the dialog and get result.
            DialogResult pathTestCase = openFileDialog1.ShowDialog();
            if (pathTestCase == DialogResult.OK) // Test result.
            {
                try
                {
                    if ((myStream = .OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
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
    }
}
