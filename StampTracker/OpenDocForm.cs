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
    public partial class OpenDocForm : Form
    {
        public OpenDocForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //    DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        foreach (DataColumn col in dt.Columns)
            //        {
            //            listBox1.Items.Add(col.ColumnName);
            //            //Console.WriteLine("{0,-15}: {1}", col.ColumnName, dr[col]);
            //        }
            //        Console.WriteLine();
            //    }
            //}
        }


        private void OpenDocForm_Load(object sender, EventArgs e)
        {
            listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            fillingListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listView1.SelectedItems.Count > 0)
            {
                nameBox.Text = listView1.SelectedItems[0].SubItems[0].Text;
                dateBox.Text = listView1.SelectedItems[0].SubItems[1].Text;
                hidden_id_label.Text = listView1.SelectedItems[0].SubItems[2].Text;
                docFileExtLabel.Text = "Расширение файла: " + listView1.SelectedItems[0].SubItems[3].Text;
                scannedFileExt.Text = "Расширение файла: " + listView1.SelectedItems[0].SubItems[4].Text;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileForView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Corel Draw files (*.cdr)|*.cdr|" + "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                newDocPathBox.Text = openFileDialog1.FileName;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            saveDocAs();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveDocAs("scannedDocFile");
        }

        private void button7_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Вы действительно хотите удалить документ - " + nameBox.Text + "?", "Удаление", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from documents where docID=@id", con);
                    string id = hidden_id_label.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    nameBox.Text = "";
                    dateBox.Text = "";
                    hidden_id_label.Text = "empty";
                    
                    fillingListView();
                }
            }
        }

        public void fillingListView(string searchingArg = "*", string uniqueSearch = "*")
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Наименование", 100);
            listView1.Columns.Add("Дата создания", 70);
            listView1.Columns.Add("ID", 70);
            listView1.Columns.Add("Тип документа", 70);
            listView1.Columns.Add("Тип отсканированного файла", 70);

            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                
                string command = "select * from documents";
                SqlCommand cmd = new SqlCommand(command, con); ;
                if (searchingArg != "*")
                {
                    command = "select * from documents where name LIKE @searchingArg";
                    cmd.Parameters.AddWithValue("@searchingArg", "%" + searchingArg + "%");
                    cmd.CommandText = command;
                }

                if(uniqueSearch != "*")
                {
                    if(uniqueSearch == "last 10")
                    {
                        command = "select TOP 10 * from documents";                        
                        cmd.CommandText = command;
                    }
                    else if(uniqueSearch == "for day")
                    {
                        command = "select * from documents where DATEDIFF(day, documents.createdDate ,GETDATE()) = 0 ";
                        cmd.CommandText = command;
                    }
                    else if(uniqueSearch == "last week")
                    {
                        command = "select * from documents where DATEDIFF(day, documents.createdDate ,GETDATE()) = 7 ";
                        cmd.CommandText = command;
                    }
                    else if(uniqueSearch == "last month")
                    {
                        command = "select * from documents where DATEDIFF(day, documents.createdDate ,GETDATE()) = 30 ";
                        cmd.CommandText = command;
                    }

                }
                    SqlDataReader reader = cmd.ExecuteReader();
                    string[] arr = new string[5];
                    while (reader.Read())
                    {
                        ListViewItem itm;
                        arr[0] = reader["name"].ToString();
                        arr[1] = reader["createdDate"].ToString();
                        arr[2] = reader["docID"].ToString();
                        arr[3] = reader["docFileExt"].ToString();
                        arr[4] = reader["scannedFileExt"].ToString();
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text=="")
            {
                fillingListView();
            }
            else
            {
                fillingListView(textBox3.Text);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileForView("scannedDocFIle");
        }

        private void saveDocAs(string docType = "docFile")
        {
            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                SqlCommand cmd;
                SaveFileDialog savefile = new SaveFileDialog();
                if (docType == "scannedDocFile")
                {
                    cmd = new SqlCommand("select scannedDocFile, scannedFileExt from documents where docID=@id", con);
                    
                }
                else cmd = new SqlCommand("select DocFile, docFileExt from documents where docID=@id", con);
                string id = hidden_id_label.Text;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    reader.Read();
                    var blob = new Byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                    string extension;
                    if (docType == "scannedDocFile")
                    {
                        extension = reader["scannedFIleExt"].ToString();
                        savefile.FileName = nameBox.Text + " - отсканированный" + extension;
                    }
                    else
                    {
                        extension = reader["docFIleExt"].ToString();
                        savefile.FileName = nameBox.Text + extension;
                    }

                    reader.GetBytes(0, 0, blob, 0, blob.Length);
                    
                    savefile.Filter = "Files as  " + extension + " |*" + extension;
                    
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        using (var fs = new FileStream(savefile.FileName, FileMode.Create, FileAccess.Write))
                            fs.Write(blob, 0, blob.Length);
                    }
                }

            }
        }
        private void openFileForView(string docType = "docFIle")
        {
            if (hidden_id_label.Text != "empty")
            {
                using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    con.Open();
                    SqlCommand cmd;
                    

                    if(docType == "scannedDocFile")
                    {
                        cmd = new SqlCommand("select scannedDocFile, scannedDocFileExt from documents where docID=@id", con);
                    }else cmd = new SqlCommand("select docFile, docFileExt from documents where docID=@id", con);

                    string id = hidden_id_label.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\temp\\");
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        reader.Read();
                        var blob = new Byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                        string extension;

                        if (docType=="scannedDocFile")
                        {
                            extension = reader["scannedDocFIleExt"].ToString();
                        }else extension = reader["docFIleExt"].ToString();

                        
                        var time = DateTime.Now.ToString("hmmss fff");
                        string newFile = Directory.GetCurrentDirectory() + "\\temp\\" + "tempfile" + time + extension;
                        reader.GetBytes(0, 0, blob, 0, blob.Length);
                        //using (var fs = new MemoryStream(memoryStream, FileMode.Create, FileAccess.Write)) {
                        using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
                            fs.Write(blob, 0, blob.Length);
                        System.Diagnostics.Process.Start(newFile);


                    }

                }
            }
        }

        private void saveChangedDoc()
        {
            var result = MessageBox.Show("Вы действительно хотите сохранить?", "Сохранение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select docID from documents where name = @docName");
                    cmd.Parameters.AddWithValue("@docName",nameBox.Text);
                    cmd.Connection = con;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        if(false) //if (reader.HasRows)
                        {
                            //MessageBox.Show("Документ с таким именем уже существует");
                            //reader.Close();
                        }
                        else
                        {
                            reader.Close();
                            CalculatorMD5 calculatorMD5 = new CalculatorMD5();
                            if (newDocPathBox.Text != "" && newScannedDocPathBox.Text != "")
                            {
                                //cmd.CommandText = "update documents set name='@name', docFile=@docFile, scannedDocFile = @scannedDocFile, checkSumDocFIle=@checkSumDocFIle, checksumScannedFile=@checksumScannedFile, docFileExt=@docFileExt, scannedFileExt=@scannedFileExt where docID=@id";


                                FileStream docFileStream = File.OpenRead(newDocPathBox.Text);
                                BinaryReader binrdr = new BinaryReader(docFileStream);
                                byte[] docFileContent = binrdr.ReadBytes((int)docFileStream.Length);
                                string docFileCheckSum = calculatorMD5.getFileHash(docFileStream);
                                string docFileExtension = Path.GetExtension(newDocPathBox.Text);
                                docFileStream.Read(docFileContent, 0, (int)docFileStream.Length);

                                FileStream scannedDocFileStream = File.OpenRead(newScannedDocPathBox.Text);
                                BinaryReader rdr2 = new BinaryReader(scannedDocFileStream);
                                byte[] scannedDocFileContent = rdr2.ReadBytes((int)scannedDocFileStream.Length);
                                string scannedFileCheckSum = calculatorMD5.getFileHash(scannedDocFileStream);
                                string scannedFileExtension = Path.GetExtension(newScannedDocPathBox.Text);
                                scannedDocFileStream.Read(scannedDocFileContent, 0, (int)scannedDocFileStream.Length);

                                using (cmd = new SqlCommand("update documents set name = @name, docFile = @docFile, scannedDocFile = @scannedDocFile, checkSumDocFIle = @checkSumDocFIle, checksumScannedFile = @checksumScannedFile, docFileExt = @docFileExt, scannedFileExt = @scannedFileExt where docID = @id", con))
                                {
                                    cmd.Parameters.AddWithValue("@id", hidden_id_label.Text);
                                    cmd.Parameters.AddWithValue("@name", nameBox.Text);
                                    cmd.Parameters.Add("@docFile", SqlDbType.Binary, docFileContent.Length).Value = docFileContent;
                                    cmd.Parameters.AddWithValue("@scannedDocFile", scannedDocFileContent);
                                    cmd.Parameters.AddWithValue("@checkSumDocFIle", docFileCheckSum);
                                    cmd.Parameters.AddWithValue("@checksumScannedFile", scannedFileCheckSum);
                                    cmd.Parameters.AddWithValue("@docFileExt", docFileExtension);
                                    cmd.Parameters.AddWithValue("@scannedFileExt", scannedFileExtension);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Документ успешно сохранен!");
                                }


                            }
                            else if (newDocPathBox.Text != "" && newScannedDocPathBox.Text == "")
                            {
                                //cmd.CommandText = "update documents set name=@name, docFile=@docFile, checkSumDocFIle=@checkSumDocFIle, docFileExt=@docFileExt where docID=@id";
                                reader.Close();

                                FileStream docFileStream = File.OpenRead(newDocPathBox.Text);
                                BinaryReader binrdr = new BinaryReader(docFileStream);
                                byte[] docFileContent = binrdr.ReadBytes((int)docFileStream.Length);
                                string docFileCheckSum = calculatorMD5.getFileHash(docFileStream);
                                string docFileExtension = Path.GetExtension(newDocPathBox.Text);
                                docFileStream.Read(docFileContent, 0, (int)docFileStream.Length);

                                using (cmd = new SqlCommand("update documents set name=@name, docFile=@docFile, checkSumDocFIle=@checkSumDocFIle, docFileExt=@docFileExt where docID=@id", con))
                                {
                                    cmd.Parameters.AddWithValue("@id", hidden_id_label.Text);
                                    cmd.Parameters.AddWithValue("@name", nameBox.Text);
                                    cmd.Parameters.Add("@docFile", SqlDbType.Binary, docFileContent.Length).Value = docFileContent;
                                    cmd.Parameters.AddWithValue("@checkSumDocFIle", docFileCheckSum);
                                    cmd.Parameters.AddWithValue("@docFileExt", docFileExtension);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Документ успешно сохранен!");
                                }
                            }
                            else if (newDocPathBox.Text == "" && newScannedDocPathBox.Text != "")
                            {
                                //cmd.CommandText = "update documents set name=@name, scannedDocFile = @scannedDocFile,  checksumScannedFile=@checksumScannedFile,  scannedFileExt=@scannedFileExt where docID=@id";
                                FileStream scannedDocFileStream = File.OpenRead(newScannedDocPathBox.Text);
                                BinaryReader rdr2 = new BinaryReader(scannedDocFileStream);
                                byte[] scannedDocFileContent = rdr2.ReadBytes((int)scannedDocFileStream.Length);
                                string scannedFileCheckSum = calculatorMD5.getFileHash(scannedDocFileStream);
                                string scannedFileExtension = Path.GetExtension(newScannedDocPathBox.Text);
                                scannedDocFileStream.Read(scannedDocFileContent, 0, (int)scannedDocFileStream.Length);

                                using (cmd = new SqlCommand("update documents set name=@name, scannedDocFile = @scannedDocFile,  checksumScannedFile=@checksumScannedFile,  scannedFileExt=@scannedFileExt where docID=@id", con))
                                {
                                    cmd.Parameters.AddWithValue("@id", hidden_id_label.Text);
                                    cmd.Parameters.AddWithValue("@name", nameBox.Text);
                                    cmd.Parameters.AddWithValue("@scannedDocFile", scannedDocFileContent);
                                    cmd.Parameters.AddWithValue("@checksumScannedFile", scannedFileCheckSum);
                                    cmd.Parameters.AddWithValue("@scannedFileExt", scannedFileExtension);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Документ успешно сохранен!");
                                }
                            }
                            else
                            {
                                cmd.CommandText = "update documents set name=@name where docID=@id";
                                string id = hidden_id_label.Text;
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@name", nameBox.Text);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Документ успешно сохранен!");
                            }


                            fillingListView();
                            nameBox.Text = "";
                            dateBox.Text = "";
                            hidden_id_label.Text = "empty";
                            newDocPathBox.Text = "";
                            newScannedDocPathBox.Text = "";
                            docFileExtLabel.Text = "Расширение файла:";
                            scannedFileExt.Text = "Расширение файла:";
                            fillingListView();


                        }
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image Files(*.bmp, *.jpg, *.png, *.tif) | *.bmp; *.jpg; *.tif; *.png |" + "All files (*.*) | *.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                newScannedDocPathBox.Text = openFileDialog1.FileName;                
            }
        }

        private void newDocPathBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void newScannedDocPathBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void newScannedDocPathBox_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(newScannedDocPathBox.Text);
        }

        private void newDocPathBox_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(newDocPathBox.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saveChangedDoc();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selIndex = comboBox1.SelectedIndex;
            if(selIndex == 0)
            {
                fillingListView(uniqueSearch: "last 10");
            }
            else if(selIndex == 1)
            {
                fillingListView(uniqueSearch: "for day");
            }
            else if (selIndex == 2)
            {
                fillingListView(uniqueSearch: "last week");
            }
            else if (selIndex == 3)
            {
                fillingListView(uniqueSearch: "last month");
            }
            else if (selIndex == 4)
            {
                fillingListView(uniqueSearch: "all");
            }
        }
    }

}