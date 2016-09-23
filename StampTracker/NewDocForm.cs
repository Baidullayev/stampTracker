using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (docBox.Text != "" || nameBox.Text != "" || scannedDocBox.Text != "")
            {
                try
                {
                    var newDocName = nameBox.Text;
                    var docFilePath = docBox.Text;
                    var scannedFilePath = scannedDocBox.Text;
                    using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                    {
                        con.Open();
                        FileStream docFileStream = File.OpenRead(docFilePath);
                        byte[] docFileContent = new byte[docFileStream.Length];
                        docFileStream.Read(docFileContent,0,(int)docFileStream.Length);
                        docFileStream.Close();

                        FileStream scannedDocFileStream = File.OpenRead(scannedFilePath);
                        byte[] scannedDocFileContent = new byte[scannedDocFileStream.Length];
                        scannedDocFileStream.Read(scannedDocFileContent, 0, (int)scannedDocFileStream.Length);
                        scannedDocFileStream.Close();

                        using (SqlCommand cmd = new SqlCommand("insert into documents values(@name, @date,@doc, @scannedDoc)",con))
                        {
                            cmd.Parameters.AddWithValue("@name",newDocName);
                            DateTime utcDate = DateTime.UtcNow;
                            cmd.Parameters.AddWithValue("@date", utcDate);
                            cmd.Parameters.AddWithValue("@doc", docFileContent);
                            cmd.Parameters.AddWithValue("@scannedDoc", scannedDocFileContent);
                            cmd.ExecuteNonQuery();                            
                            MessageBox.Show("Новый документ создан успешно!");
                        }
                         
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Вы должный указать найменование документа и прикрепить файлы");
            }

        }
    }
}
