using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StampTracker
{
    public partial class EditUsersForm : Form
    {
        List<User> userList = new List<User>();
        public EditUsersForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool notExist = true;

            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "NewUserForm")
                {
                    notExist = false;
                    Application.OpenForms[i].TopMost = true;
                }

            }
            if (notExist)
            {
                NewUserForm newUserForm = new NewUserForm();
                newUserForm.Show();
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = -1;
            if (listView1.SelectedItems.Count > 0)
            {
                index = listView1.Items.IndexOf(listView1.SelectedItems[0]);
                nameBox.Text = userList[index].firstName;
                lastnameBox.Text = userList[index].lastName;
                fatherNameBox.Text = userList[index].fatherName;
                usernameBox.Text = userList[index].userName;
                hiddenId.Text = userList[index].userID.ToString();
                passwordBox.Text = userList[index].password;
                if (userList[index].role != null)
                {
                    string role = userList[index].role.ToLower();
                    if (role == "admin")
                    {
                        roleBox.SelectedIndex = 0;
                    }
                    else if (role == "user")
                    {
                        roleBox.SelectedIndex = 1;
                    }
                    else if (role == "reader")
                    {
                        roleBox.SelectedIndex = 2;
                    }
                }

            }



        }
        private void fillUserList(string lastName = null)
        {
            try
            {
                listView1.Clear();
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("Имя", 100);
                listView1.Columns.Add("Фамилия", 100);
                listView1.Columns.Add("Отчество", 100);
                userList.Clear();
                string command = "Select * from users";



                using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                {
                    con.Open();



                    if (lastName != null)
                    {
                        command = "select * from users where lastName LIKE @lastName";

                    }
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Parameters.AddWithValue("@lastName", "%" + lastName + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    string[] arr = new string[5];
                    while (reader.Read())
                    {
                        User tempUser = new User();
                        tempUser.userID = (Int32)reader["userID"];
                        tempUser.firstName = reader["firstName"].ToString();
                        tempUser.lastName = reader["lastName"].ToString();
                        tempUser.fatherName = reader["fatherName"].ToString();
                        tempUser.userName = reader["userName"].ToString();
                        tempUser.role = reader["role"].ToString();
                        tempUser.password = reader["password"].ToString();

                        userList.Add(tempUser);

                        arr[0] = reader["firstName"].ToString();
                        arr[1] = reader["lastName"].ToString();
                        arr[2] = reader["fatherName"].ToString();
                        ListViewItem itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void EditUsersForm_Load(object sender, EventArgs e)
        {
            fillUserList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fillUserList(textBox1.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите сохранить изменения? ", "Изменение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                editUser();
            }
        }
        private void editUser()
        {
            try
            {
                if (nameBox.Text != "" && lastnameBox.Text != "" && usernameBox.Text != "" && passwordBox.Text != "")
                {
                    using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                    {
                        con.Open();
                        string command = "update users set firstName=@firstName, lastName=@lastName, fatherName=@fatherName, userName=@userName, password=@password, role=@role where userID=@id";
                        SqlCommand cmd = new SqlCommand(command, con);
                        cmd.Parameters.AddWithValue("@id", hiddenId.Text);
                        cmd.Parameters.AddWithValue("@lastName", lastnameBox.Text);
                        cmd.Parameters.AddWithValue("@firstName", nameBox.Text);
                        cmd.Parameters.AddWithValue("@fatherName", fatherNameBox.Text);
                        cmd.Parameters.AddWithValue("@userName", usernameBox.Text);
                        cmd.Parameters.AddWithValue("@password", passwordBox.Text);
                        cmd.Parameters.AddWithValue("@role", roleBox.SelectedText);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Успешно!");

                        ////////////////////////////////////////////////
                    }
                }
                else { MessageBox.Show("Пожалуйста заполните необходимые поля"); }


            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
         }
    }
    }

