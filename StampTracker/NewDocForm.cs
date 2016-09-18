using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StampTracker
{
    public partial class NewDocForm : Form
    {
        public NewDocForm()
        {
            InitializeComponent();
        }

        private void NewDocForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            scannedDocBox.Text = "";
            docBox.Text = "";
            nameBox.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.Stream myStream = null;
            OpenFileDialog attacheDocFile = new OpenFileDialog();

            attacheDocFile.InitialDirectory = "c:\\";
            attacheDocFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            attacheDocFile.FilterIndex = 2;
            attacheDocFile.RestoreDirectory = true;

            if (attacheDocFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = attacheDocFile.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            MessageBox.Show(myStream.Read().ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
