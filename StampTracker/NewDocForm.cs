﻿using System;
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
        public static List<String> recentDocs = new List<string>();
        public NewDocForm()
        {
            InitializeComponent();
        }

        private void NewDocForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            getRecentDocs();
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)// кнопка очистки
        {
            scannedDocBox.Text = "";
            docBox.Text = "";
            nameBox.Text = "";

        }

        private void button2_Click(object sender, EventArgs e) // кнопка прикрепления документа
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Corel Draw files (*.cdr)|*.cdr|" + "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                docBox.Text = openFileDialog1.FileName;
                viewDocButton.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//кнопка прикрепления отсканированного документа
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

        private void button5_Click(object sender, EventArgs e)//кнопка просмотра прикрепленного отсканированниого документа
        {
            if (scannedDocBox.Text != "")
            {
                if (docBox.Text.Contains("<clone>"))
                {
                    openForView("scannedDocFile");                    
                }
                else 
                {
                    try
                    {
                        System.Diagnostics.Process.Start(scannedDocBox.Text);
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.Message);
                    }
                    
                }                

            }
             
            
        }

        private void viewDocButton_Click(object sender, EventArgs e)//кнопка просмотра документа
        {
            if (docBox.Text.Contains("<clone>")) // проверяется является ли прикрепленный документ клоном другого документа из базы данных
            {
                openForView("docFile");
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(docBox.Text);
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.Message);
                }
                
               
            }
        }

        private void openForView( string docType) //функция просмотра документа из базы даных
        {            
            try
            {
                string docname = null;
                if (docType == "docFile")
                {
                    docname = docBox.Text.Remove(0, 10);
                }
                else if (docType == "scannedDocFile")
                {
                    docname = scannedDocBox.Text.Remove(0, 10);
                }

                using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    con.Open();
                    SqlCommand cmd;


                    if (docType == "scannedDocFile")
                    {
                        cmd = new SqlCommand("select scannedDocFile, scannedFileExt from documents where name=@docname", con);
                    }
                    else cmd = new SqlCommand("select docFile, docFileExt from documents where name=@docname", con);


                    cmd.Parameters.AddWithValue("@docname", docname);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\temp\\");
                        foreach (FileInfo file in di.GetFiles())
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch (Exception e)
                            {

                            }

                        }
                        reader.Read();
                        var blob = new Byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                        string extension;

                        if (docType == "scannedDocFile")
                        {
                            extension = reader["scannedFileExt"].ToString();
                        }
                        else extension = reader["docFileExt"].ToString();


                        var time = DateTime.Now.ToString("hmmss fff");
                        string newFile = Directory.GetCurrentDirectory() + "\\temp\\" + "tempfile" + time + extension;
                        reader.GetBytes(0, 0, blob, 0, blob.Length);
                        //using (var fs = new MemoryStream(memoryStream, FileMode.Create, FileAccess.Write)) {
                        using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
                            fs.Write(blob, 0, blob.Length);
                        System.Diagnostics.Process.Start(newFile);


                    }

                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public void saveNewDoc() //функция сохранения нового документа
        {
            try
            {
                if (docBox.Text != "" && nameBox.Text != "")
                {
                    string newDocName = nameBox.Text;
                    string docFileCheckSum = null;
                    string docFileExtension = null;
                    string scannedFileCheckSum = null;
                    string scannedFileExtension = null;
                    byte[] docFileContent = null;
                    byte[] scannedDocFileContent = null;



                    string docFilePath = docBox.Text;
                    string scannedFilePath = scannedDocBox.Text;


                    if (!nameCheck(newDocName))
                    {
                        if (docFilePath.Contains("<clone>"))
                        {
                            string donorDocName = docFilePath.Remove(0, 10);
                            docFileContent = getByteFromRecord(donorDocName, "docFile");
                            docFileExtension = getExtensionFromRecord(donorDocName, "docFile");
                            docFileCheckSum = getSummFromRecord(donorDocName, "checksumDocFIle");
                        }
                        else if (!docFilePath.Contains("<clone>"))
                        {
                            docFileContent = getByteOfFile(docFilePath);
                            docFileExtension = Path.GetExtension(docFilePath);
                            docFileCheckSum = getSumm(docFilePath);
                        }

                        if (scannedFilePath.Contains("<clone>"))
                        {
                            string donorDocName = scannedFilePath.Remove(0, 10);
                            scannedDocFileContent = getByteFromRecord(donorDocName, "scannedDocFile");
                            scannedFileExtension = getExtensionFromRecord(donorDocName, "scannedDocFile");
                            scannedFileCheckSum = getSummFromRecord(donorDocName, "checksumScannedFile");
                        }
                        else if (!scannedFilePath.Contains("<clone>"))
                        {
                            scannedDocFileContent = getByteOfFile(scannedFilePath);
                            scannedFileCheckSum = getSumm(scannedFilePath);
                            scannedFileExtension = Path.GetExtension(scannedFilePath);
                        }

                        List<string> checkSumList = searchingCheckSum(docFileCheckSum, scannedFileExtension);
                        if (checkSumList.Count() == 0)
                        {
                            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                            {
                                con.Open();
                                using (SqlCommand cmd = new SqlCommand("insert into documents values(@name, @date,@doc, @scannedDoc, @checkSumOriginal, @checkSumScanned, @docFileExt, @scannedFileExt)", con))
                                {
                                    cmd.Parameters.AddWithValue("@name", newDocName);
                                    DateTime utcDate = DateTime.UtcNow;
                                    cmd.Parameters.AddWithValue("@date", utcDate);
                                    cmd.Parameters.Add("@doc", SqlDbType.Binary, docFileContent.Length).Value = docFileContent;
                                    cmd.Parameters.Add("@scannedDoc", SqlDbType.Binary, scannedDocFileContent.Length).Value = scannedDocFileContent;
                                    cmd.Parameters.AddWithValue("@checkSumOriginal", docFileCheckSum);
                                    cmd.Parameters.AddWithValue("@checkSumScanned", scannedFileCheckSum);
                                    cmd.Parameters.AddWithValue("@docFIleExt", docFileExtension);
                                    cmd.Parameters.AddWithValue("@scannedFileExt", scannedFileExtension);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Новый документ создан успешно!");
                                    getRecentDocs();
                                }
                            }
                        }
                        else
                        {
                            string foundDocs = "";
                            for (int i = 0; i < checkSumList.Count; i++)
                            {
                                if (i == 0)
                                {
                                    foundDocs += checkSumList[i].ToString();
                                }
                                else
                                    foundDocs += ", " + checkSumList[i].ToString();
                            }
                            var result = MessageBox.Show("Минимум один из прикрепленных файлов уже имееться в следующих записах: " + foundDocs + "сохранить все равно?", "информация", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                                {
                                    con.Open();
                                    using (SqlCommand cmd = new SqlCommand("insert into documents values(@name, @date,@doc, @scannedDoc, @checkSumOriginal, @checkSumScanned, @docFileExt, @scannedFileExt)", con))
                                    {
                                        cmd.Parameters.AddWithValue("@name", newDocName);
                                        DateTime utcDate = DateTime.UtcNow;
                                        cmd.Parameters.AddWithValue("@date", utcDate);
                                        cmd.Parameters.Add("@doc", SqlDbType.Binary, docFileContent.Length).Value = docFileContent;
                                        cmd.Parameters.Add("@scannedDoc", SqlDbType.Binary, scannedDocFileContent.Length).Value = scannedDocFileContent;
                                        cmd.Parameters.AddWithValue("@checkSumOriginal", docFileCheckSum);
                                        cmd.Parameters.AddWithValue("@checkSumScanned", scannedFileCheckSum);
                                        cmd.Parameters.AddWithValue("@docFIleExt", docFileExtension);
                                        cmd.Parameters.AddWithValue("@scannedFileExt", scannedFileExtension);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Новый документ создан успешно!");
                                        getRecentDocs();
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Документ с таким именем уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("Вы должный указать найменование документа и прикрепить файлы");
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        
        private void saveButton_Click(object sender, EventArgs e)//кнопка сохранения документа, вызывает фукнцию сохранения нового документа 
        {
            saveNewDoc();  

        }

        private void button3_Click_1(object sender, EventArgs e)
        {            

        }
        private void getRecentDocs(int count = 10)
        {
            List<String> recentDocs = new List<String>();

            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("select TOP 10 * from documents order by docID desc", con))
                {
                    //command.Parameters.AddWithValue("@count", count);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        recentDocs.Add(reader["name"].ToString());
                    }

                }
            }
            recentDocList.Items.Clear();
            for (int i = 0; i < recentDocs.Count(); i++)
            {
                recentDocList.Items.Add(recentDocs[i]);
            }
            
        }

        private void cloneButton_Click(object sender, EventArgs e) // кнопка клонирования документа 
        {
            if(recentDocList.SelectedIndex != -1)
            {
                clone(recentDocList.SelectedItem.ToString());
                
            }
            
        }

        private void openDocButton_Click(object sender, EventArgs e) // кнопка открытия выбранного документа из списка недавно созданных документов
        {
            if (recentDocList.SelectedIndex != -1)
            {
                OpenDocForm openForm = new OpenDocForm();
                openForm.MdiParent = MainForm.ActiveForm;
                openForm.BringToFront();
                openForm.Show();
                openForm.WindowState = FormWindowState.Normal;
                openForm.WindowState = FormWindowState.Maximized;

                openForm.fillingListView(recentDocList.SelectedItem.ToString());                
             
                openForm.selectFirst();
            }
        }

        private string getSumm(string fileName) //функция получения контрольной суммы файла (MD5)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            file.Close();
            return sb.ToString();

        }
        public void clone(string docname)
        {
            viewDocButton.Enabled = true;
            viewScanImgButton.Enabled = true;
            nameBox.Text = docname;
            docBox.Text = "<clone> - " + docname;
            scannedDocBox.Text = "<clone> - " + docname;
        }
        public bool nameCheck(string newDocName) // функция проверки найменования создаваемого документа на наличие в базе данных
        {
            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select docID from documents where name=@docName", con);
                cmd2.Parameters.AddWithValue("@docName", newDocName);
                using (SqlDataReader reader = cmd2.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return true;
                    }

                        return false;
                    
                }
            }
        }
        public byte[] getByteOfFile(string filePath) //функция ковертация файла в байты, документы хранятся в виде байтов
        {
            byte[] fileByte = null;
            try
            {
                using (FileStream docFileStream = File.OpenRead(filePath))
                {
                    using (BinaryReader rdr = new BinaryReader(docFileStream))
                    {
                        fileByte = rdr.ReadBytes((int)docFileStream.Length);
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return fileByte;
        }

        private string getSummFromRecord(string docname, string summType) // функция получения контроьной суммы файла который храниться в базе данных 
        {
            // это функция возращает контрольной суммы для сохранения в новой записи
            string Summ = null;
            string commandString = "select checkSumDocFIle, checksumScannedFile from documents where name=@docname";
            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(commandString, con);
                cmd.Parameters.AddWithValue("@summType", summType);
                cmd.Parameters.AddWithValue("@docname", docname);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    reader.Read();
                    Summ = reader[summType].ToString();
                }
            }
            return Summ;
        }

        private string getExtensionFromRecord(string docname, string docType)// функция возвращает расширение файла клонироваемого документа 
        {
            // функция нужна для просмотра клонироваемого документа
            string fileExtension = null;
            string summType = null;
            if (docType == "scannedDocFile")
            {
                summType = "scannedFileExt";
            }
            else  summType = "docFileExt"; 

            string commandString = "select " + summType + " from documents where name=@docname";
            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(commandString, con);
                cmd.Parameters.AddWithValue("summType", summType);
                cmd.Parameters.AddWithValue("@docname", docname);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    reader.Read();
                    fileExtension = reader.GetString(0);
                }
            }

            return fileExtension;

        }

        private byte[] getByteFromRecord(string docname, string docType) // возвращает байты клонироваемого документа для открытия либо для сохранения
        {
            // 
            byte[] blob = null;
            string commandString = "select " + docType + " from documents where name=@docname";
            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(commandString, con);
                
                cmd.Parameters.AddWithValue("@docType", docType);
                cmd.Parameters.AddWithValue("@docname", docname);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null)
                {

                    reader.Read();
                    blob = new Byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                    
                    reader.GetBytes(0, 0, blob, 0, blob.Length);
                }
            }

            return blob;
        }

        private List<string> searchingCheckSum(string docFileCheckSum = null, string scannedFileCheckSum = null) // эта функция возвращает список документов в которых уже хранится прикрепленны(е) документ.
        {
            List<string> matchDocList = new List<string>();
            string commandString = "select name from documents where checkSumDocFIle=@checkSumDocFile or checksumScannedFile=@checksumScannedFile";
            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                SqlCommand cmd3 = new SqlCommand(commandString, con);
                cmd3.Parameters.AddWithValue("@checkSumDocFile", docFileCheckSum);
                cmd3.Parameters.AddWithValue("@checksumScannedFile", scannedFileCheckSum);
                using (SqlDataReader reader2 = cmd3.ExecuteReader())
                {
                    List<String> tempList = new List<String>();

                    if (reader2.HasRows)
                    {
                        while (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                matchDocList.Add(reader2.GetString(0));
                            }
                            reader2.NextResult();
                        }
                    }
                }
            }

            return matchDocList;
        }
    }

}
