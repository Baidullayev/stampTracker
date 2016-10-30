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
    
    
    public partial class MainForm : Form
    {
        
        public static IniFile myIni = new IniFile(Directory.GetCurrentDirectory() + "\\settings.ini");
        public static string serverName;
        public static string instanceName;
        public static string dbName;
        public static string loginSql;
        public static string passwordSql;

        public static User currentUser ;
        public static string connectionString = null;        
        public static bool authorized = false;
        public static bool check = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
           serverName = myIni.Read("serverName", "SqlServer connection parameters");
            instanceName = myIni.Read("instanceName", "SqlServer connection parameters");
            dbName = myIni.Read("dbName", "SqlServer connection parameters");
            loginSql = myIni.Read("login", "SqlServer connection parameters");
            passwordSql = myIni.Read("password", "SqlServer connection parameters");
            List<String> roleList = new List<String>();
            roleList.Add("admin");
            roleList.Add("user");
            roleList.Add("reader");
            


            if (serverName != "null" || instanceName != "null" || dbName != "null" || loginSql != "null" || passwordSql != "null")
            {
                try
                {
                    String str = "server=" + serverName + "\\" + instanceName + ";database=" + dbName + ";UID=" + loginSql + ";password=" + passwordSql;
                    //String query = "select * from users";
                    SqlConnection con = new SqlConnection(str);
                   // SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    //DataSet ds = new DataSet();
                    ConnectionStripLabel.Text = "Соединение с БД установлено";                //   
                    con.Close();
                    connectionString = str;
                }
                catch (Exception es)
                {
                    ConnectionStripLabel.Text = "Соединение с БД не установлено";
                    MessageBox.Show(es.Message);

                }
            }
            else ConnectionStripLabel.Text = "Требуется настройка сервера БД";


            IsMdiContainer = true;
            
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDocForm newDocForm = new NewDocForm();
            newDocForm.MdiParent = this;            
            newDocForm.BringToFront();
            newDocForm.Show();
            newDocForm.WindowState = FormWindowState.Normal;
            newDocForm.WindowState = FormWindowState.Maximized;
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocForm openForm = new OpenDocForm();
            openForm.MdiParent = this;
            openForm.BringToFront();
            openForm.Show();
            openForm.WindowState = FormWindowState.Normal;
            openForm.WindowState = FormWindowState.Maximized;
        }

        private void параметрыSqlServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void loginMenu_Click(object sender, EventArgs e)
        {
            if (authorized == false)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void добавитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void рекдактироватьПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUsersForm editUsersForm = new EditUsersForm();
            editUsersForm.Show();
            
        }

        private void myMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public static void ss()
        {
            
            
        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
           
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            MenuActivation();
        }

        private void windowNewMenu_Click(object sender, EventArgs e)
        {
            loginMenu.Text = "Войти";
            loginMenu.DropDownItems.Clear();
            authorized = false;
            check = false;
        }
        public void MenuActivation()
        {
            if (authorized)
            {
                if (check == false)
                {
                    ToolStripMenuItem windowNewMenu = new ToolStripMenuItem("Выход", null, new EventHandler(windowNewMenu_Click));
                    loginMenu.Text = currentUser.firstName + " " + currentUser.lastName;
                    loginMenu.DropDownItems.Add(windowNewMenu);
                    check = true;
                    if(currentUser.role.ToLower() == "admin")
                    {
                        createMenu.Enabled = true;
                        openMenu.Enabled = true;
                        addUserMenu.Enabled = true;
                        EditUsersMenu.Enabled = true;
                    }
                    else if (currentUser.role.ToLower() == "user")
                    {
                        createMenu.Enabled = true;
                        openMenu.Enabled = true;
                        addUserMenu.Enabled = false;
                        EditUsersMenu.Enabled = false;
                    }
                    else if(currentUser.role.ToLower() == "reader")
                    {
                        createMenu.Enabled = false;
                        openMenu.Enabled = true;
                        addUserMenu.Enabled = false;
                        EditUsersMenu.Enabled = false;
                    }

                }
            }
        }
    }
}
