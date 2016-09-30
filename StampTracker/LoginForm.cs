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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = loginBox.Text;
            string password = passwordBox.Text;
            using (SqlConnection con = new SqlConnection(MainForm.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from users where username=@username and password=@password", con))
                {                    
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                            reader.Read();
                            MainForm.currentUser = new User();
                            MainForm.currentUser.userID = reader.GetInt32(0);
                            MainForm.currentUser.firstName = reader.GetString(1);
                            MainForm.currentUser.lastName = reader.GetString(2);
                            MainForm.currentUser.fatherName = reader.GetString(3);
                            MainForm.currentUser.userName = reader.GetString(4);
                            MainForm.currentUser.password = reader.GetString(5);
                            MainForm.currentUser.role = reader.GetString(6);                                            
                           
                            MainForm.authorized = true;
                                                        

                        this.Hide();
                    }
                    else
                    {
                        errorLabel.Text = "Неправильный логин или пароль";                        
                    }
                }

            }
                    
        }


    }
}
