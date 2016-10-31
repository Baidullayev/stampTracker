using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
                        using (SqlCommand cmd2 = new SqlCommand("select docID from documents where name=@docName", con))
                        {
                            cmd2.Parameters.AddWithValue("@docName", newDocName);
                            using (SqlDataReader reader = cmd2.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    MessageBox.Show("Документ с таким именем уже существует");
                                    reader.Close();
                                   
                                }
                                else
                                {
                                    reader.Close();
                                    CalculatorMD5 calculatorMD5 = new CalculatorMD5();

                                    FileStream docFileStream = File.OpenRead(docFilePath);
                                    BinaryReader rdr = new BinaryReader(docFileStream);
                                    byte[] docFileContent = rdr.ReadBytes((int)docFileStream.Length);
                                    string docFileCheckSum = calculatorMD5.getFileHash(docFileStream);
                                    string docFileExtension = Path.GetExtension(docFilePath);
                                    docFileStream.Read(docFileContent, 0, (int)docFileStream.Length);
                                    

                                    FileStream scannedDocFileStream = File.OpenRead(scannedFilePath);
                                    BinaryReader rdr2 = new BinaryReader(scannedDocFileStream);
                                    byte[] scannedDocFileContent = rdr2.ReadBytes((int)scannedDocFileStream.Length);
                                    string scannedFileCheckSum = calculatorMD5.getFileHash(scannedDocFileStream);
                                    string scannedFileExtension = Path.GetExtension(scannedFilePath);


                                    using (SqlCommand cmd3 = new SqlCommand("select docID, name from documents where checksumDocFIle=@checksumDocFIle or checksumScannedFile=@checksumScannedFile ", con))
                                    {
                                        cmd3.Parameters.AddWithValue("@checkSumDocFile", docFileCheckSum);
                                        cmd3.Parameters.AddWithValue("@checksumScannedFile", scannedFileCheckSum);
                                        using (SqlDataReader reader2 = cmd3.ExecuteReader())
                                        {
                                            List<String> tempList = new List<String>();

                                            if(reader2.HasRows)
                                            {
                                                while (reader2.HasRows)
                                                {
                                                    while (reader2.Read())
                                                    {
                                                        tempList.Add(reader2.GetString(1));
                                                    }
                                                    reader2.NextResult();
                                                }
                                                string tempString="";
                                                foreach(string ss in tempList)
                                                {
                                                    tempString += ss + ", "; 
                                                }
                                                var result = MessageBox.Show("Минимум один из прикрепленных файлов уже имееться в следующих записах: " + tempString + "сохранить все равно?","информация", MessageBoxButtons.YesNo);
                                                if(result == DialogResult.Yes)
                                                {
                                                    reader2.Close();
                                                    scannedDocFileStream.Read(scannedDocFileContent, 0, (int)scannedDocFileStream.Length);
                                                    scannedDocFileStream.Close();

                                                    using (SqlCommand cmd = new SqlCommand("insert into documents values(@name, @date,@doc, @scannedDoc, @checkSumOriginal, @checkSumScanned, @docFileExt, @scannedFileExt)", con))
                                                    {
                                                        cmd.Parameters.AddWithValue("@name", newDocName);
                                                        DateTime utcDate = DateTime.UtcNow;
                                                        cmd.Parameters.AddWithValue("@date", utcDate);                                                        
                                                        cmd.Parameters.Add("@doc", SqlDbType.Binary, docFileContent.Length).Value = docFileContent;
                                                        cmd.Parameters.AddWithValue("@scannedDoc", scannedDocFileContent);
                                                        cmd.Parameters.AddWithValue("@checkSumOriginal", docFileCheckSum);
                                                        cmd.Parameters.AddWithValue("@checkSumScanned", scannedFileCheckSum);
                                                        cmd.Parameters.AddWithValue("@docFIleExt", docFileExtension);
                                                        cmd.Parameters.AddWithValue("@scannedFileExt", scannedFileExtension);
                                                        cmd.ExecuteNonQuery();
                                                        MessageBox.Show("Новый документ создан успешно!");
                                                    }
                                                }
                                                //I stopped here
                                            }                                 


                                            else
                                            {                                       
                                               reader2.Close();
                                                scannedDocFileStream.Read(scannedDocFileContent, 0, (int)scannedDocFileStream.Length);
                                                scannedDocFileStream.Close();

                                                using (SqlCommand cmd = new SqlCommand("insert into documents values(@name, @date,@doc, @scannedDoc, @checkSumOriginal, @checkSumScanned, @docFileExt, @scannedFileExt)", con))
                                                {
                                                    cmd.Parameters.AddWithValue("@name", newDocName);
                                                    DateTime utcDate = DateTime.UtcNow;
                                                    cmd.Parameters.AddWithValue("@date", utcDate);
                                                    cmd.Parameters.AddWithValue("@doc", docFileContent);
                                                    cmd.Parameters.AddWithValue("@scannedDoc", scannedDocFileContent);
                                                    cmd.Parameters.AddWithValue("@checkSumOriginal", docFileCheckSum);
                                                    cmd.Parameters.AddWithValue("@checkSumScanned", scannedFileCheckSum);
                                                    cmd.Parameters.AddWithValue("@docFIleExt", docFileExtension);
                                                    cmd.Parameters.AddWithValue("@scannedFileExt", scannedFileExtension);
                                                    cmd.ExecuteNonQuery();
                                                    MessageBox.Show("Новый документ создан успешно!");
                                                }
                                            }
                                        }
                                    }
                                    rdr.Close();
                                    docFileStream.Close();
                                    rdr2.Close();
                                    scannedDocFileStream.Close();              

                                }

                            }
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

        private void button3_Click_1(object sender, EventArgs e)
        {            
            var docFilePath = Path.GetExtension(docBox.Text);
            MessageBox.Show(docFilePath);
        }
    }
}
