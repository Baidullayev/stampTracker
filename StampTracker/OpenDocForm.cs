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
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hidden_id_label.Text != "empty")
            {
                using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select docFile, docFileExt from documents where docID=@id", con);
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
                        string extension = reader["docFIleExt"].ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTime.Now.ToString("hmmss fff"));
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select docFile, docFileExt from documents where docID=@id", con);
                string id = hidden_id_label.Text;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    reader.Read();
                    var blob = new Byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                    string extension = reader["docFIleExt"].ToString();
                    reader.GetBytes(0, 0, blob, 0, blob.Length);
                    SaveFileDialog savefile = new SaveFileDialog();
                    savefile.Filter = "Files as |*" + extension;
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        using (var fs = new FileStream(savefile.FileName, FileMode.Create, FileAccess.Write))
                            fs.Write(blob, 0, blob.Length);
                    }
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select scannedDocFile, scannedFileExt from documents where docID=@id", con);
                string id = hidden_id_label.Text;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    reader.Read();
                    var blob = new Byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                    string extension = reader["scannedFIleExt"].ToString();
                    reader.GetBytes(0, 0, blob, 0, blob.Length);
                    SaveFileDialog savefile = new SaveFileDialog();
                    savefile.Filter = "Files as |*" + extension;
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        using (var fs = new FileStream(savefile.FileName, FileMode.Create, FileAccess.Write))
                            fs.Write(blob, 0, blob.Length);
                    }
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Вы действительно хотите удалить данный документ?", "Удаление", MessageBoxButtons.YesNo);
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

        public void fillingListView(string searchingArg = "*")
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Наименование", 100);
            listView1.Columns.Add("Дата создания", 70);
            listView1.Columns.Add("ID", 70);


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
                
                    SqlDataReader reader = cmd.ExecuteReader();
                    string[] arr = new string[3];
                    while (reader.Read())
                    {
                        ListViewItem itm;
                        arr[0] = reader["name"].ToString();
                        arr[1] = reader["createdDate"].ToString();
                        arr[2] = reader["docID"].ToString();

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
    }

}