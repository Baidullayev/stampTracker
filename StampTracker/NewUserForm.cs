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
    public partial class NewUserForm : Form
    {
        public NewUserForm()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            nameBox.Text = "";
            lastNameBox.Text = "";
            fatherNameBox.Text = "";
            loginBox.Text = "";
            passwordBox.Text = "";
            rePasswordBox.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string firstName = nameBox.Text;
                string lastName = lastNameBox.Text;
                string fatherName = fatherNameBox.Text;
                string username = loginBox.Text;
                string password = passwordBox.Text;
                string role = roleComboBox.SelectedItem.ToString();
                string rePassword = rePasswordBox.Text;

                if (firstName != "" && lastName != "" && username != "" && password != "" && rePassword != "" && role != "" && roleComboBox.SelectedIndex != -1)
                {
                    if (password == rePassword)
                    {


                        using (SqlConnection con = new SqlConnection(MainForm.connectionString))
                        {
                            con.Open();
                            SqlCommand checkByNameCMD = new SqlCommand("SELECT userID FROM users where firstName=@firstName and lastName=@lastName", con);
                            checkByNameCMD.Parameters.AddWithValue("@firstname", firstName);
                            checkByNameCMD.Parameters.AddWithValue("@lastName", lastName);
                            using (SqlDataReader reader = checkByNameCMD.ExecuteReader())
                            {

                                if (reader.HasRows)
                                {
                                    MessageBox.Show("Пользователь с таким именем и фамилией уже существует!");
                                    reader.Close();
                                    con.Close();
                                }
                                else
                                {
                                    reader.Close();
                                    SqlCommand checkByUsernameCMD = new SqlCommand("SELECT userID FROM users where username=@username", con);
                                    checkByUsernameCMD.Parameters.AddWithValue("@username", username.ToLower());
                                    using (SqlDataReader reader2 = checkByUsernameCMD.ExecuteReader())
                                    {
                                        if (reader2.HasRows)
                                        {
                                            MessageBox.Show("Придумайте другой логин!");
                                            reader2.Close();
                                            con.Close();
                                        }
                                        else
                                        {
                                            reader2.Close();
                                            SqlCommand addNewUserCMD = new SqlCommand("insert into users values (@firstName, @lastName, @fatherName, @username, @password, @role)", con);
                                            addNewUserCMD.Parameters.AddWithValue("@firstName", firstName);
                                            addNewUserCMD.Parameters.AddWithValue("@lastName", lastName);
                                            addNewUserCMD.Parameters.AddWithValue("@fatherName", fatherName);
                                            addNewUserCMD.Parameters.AddWithValue("@username", username);
                                            addNewUserCMD.Parameters.AddWithValue("@password", password);
                                            addNewUserCMD.Parameters.AddWithValue("@role", role);
                                            try
                                            {
                                                addNewUserCMD.ExecuteNonQuery();
                                                MessageBox.Show("Пользователь успешно добавлен!");
                                                con.Close();
                                            }
                                            catch (Exception es)
                                            {
                                                MessageBox.Show(es.Message);
                                                con.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else { MessageBox.Show("Пароли не совпадают!"); }
                }
                else { MessageBox.Show("Заполните все поле (отчество не обязательно)."); }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewUserForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
