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
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            
            listView1.Columns.Add("Наименование", 100);
            listView1.Columns.Add("Дата создания", 70);
            listView1.Columns.Add("ID", 70);
            //int count;

            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from documents", con);
                SqlDataReader reader = cmd.ExecuteReader();
                
                //DataTable dt = new DataTable();
                //dt.Load(reader);
                //count = dt.Rows.Count;
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




            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

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

        }
    }
}
