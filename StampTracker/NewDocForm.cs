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



            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Corel Draw files (*.cdr)|*.cdr|" + "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                docBox.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image Files(*.bmp, *.jpg, *.png, *.tif) | *.bmp; *.jpg; *.tif; *.png |" + "All files (*.*) | *.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                scannedDocBox.Text = openFileDialog1.FileName;
                viewScanImgButton.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(scannedDocBox.Text != "")
            {
                Image scannedImage = Image.FromFile(scannedDocBox.Text);
                pictureBox1.Image = scannedImage;
            }
             
            
        }

        private void viewDocButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@docBox.Text);
        }
    }
}
