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
        public static bool connectionState = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void MainForm_Load(object sender, EventArgs e) // загрузка основной окна
        {
            MenuDeactivation();
            
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
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    connectionState = true;
                    con.Close();
                    connectionString = str;

                }
                catch (Exception es)
                {
                    connectionState = false;
                    UpdateMenuStatus("Соединение с БД не установлено");
                    //ConnectionStripLabel.Text = "Соединение с БД не установлено";
                    MessageBox.Show(es.Message);

                }
            }


            //else UpdateMenuStatus("Требуется настройка сервера БД"); //ConnectionStripLabel.Text = "Требуется настройка сервера БД";


            IsMdiContainer = true;
            
        }

        public void UpdateMenuStatus(string mess) // меняет текст ConnectionStripLabel
        {
            ConnectionStripLabel.Text = mess;
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

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e) // меню выход программы
        {
            System.Windows.Forms.Application.Exit();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) // открывает окно просмотра документов, тут ошибка при наименовании меню
        {
            OpenDocForm openForm = new OpenDocForm();
            openForm.MdiParent = this;
            openForm.BringToFront();
            openForm.Show();
            openForm.WindowState = FormWindowState.Normal;
            openForm.WindowState = FormWindowState.Maximized;
        }

        private void параметрыSqlServerToolStripMenuItem_Click(object sender, EventArgs e) // открывает окно настроек
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
            
        }



        private void loginMenu_Click(object sender, EventArgs e) // открывает окно авторизаций
        {
            if (authorized == false)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void добавитьПользователяToolStripMenuItem_Click(object sender, EventArgs e) // открывает окно добавления нового пользователя
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

        private void рекдактироватьПользователейToolStripMenuItem_Click(object sender, EventArgs e) // открывает окно редактирования пользователей
        {
            EditUsersForm editUsersForm = new EditUsersForm();
            editUsersForm.Show();
            
        }





        private void MainForm_Activated(object sender, EventArgs e) //активация главного окна
        {
            MenuActivation();
         
            if (MainForm.connectionState)
            {
                this.UpdateMenuStatus("Соединение с БД установлено успешно");
            }
            else { this.UpdateMenuStatus("Соединение с БД не установлено!"); }
        }

        private void windowNewMenu_Click(object sender, EventArgs e) //это функция вызывается при деавторизаций, она меняет тект меню 
        {
            foreach (Form frm in this.MdiChildren)
            frm.Close();

            loginMenu.Text = "Войти";
            loginMenu.DropDownItems.Clear();
            authorized = false;
            check = false;
            currentUser = null;
            MenuDeactivation();
        }
        public void MenuDeactivation() //функция отключения основного меню
        {
            createMenu.Enabled = false;
            openMenu.Enabled = false;
            saveMenu.Enabled = false;
            addUserMenu.Enabled = false;
            EditUsersMenu.Enabled = false;
            currentUserStripLabel.Text = "";
            ConnectionStripLabel.Text = "Вам необходимо войти в систему!";
        }
        public void MenuActivation() // Активация главного меню
        {
            if (authorized) //тут проверяется пользователь авторизован или нет
            {
                if (check == false)
                {
                    ToolStripMenuItem windowNewMenu = new ToolStripMenuItem("Выход", null, new EventHandler(windowNewMenu_Click));
                    loginMenu.Text = currentUser.firstName + " " + currentUser.lastName;
                    loginMenu.DropDownItems.Add(windowNewMenu);
                    check = true;
                    currentUserStripLabel.Text = "Ваш статус: " + currentUser.role.ToLower();
                    if (currentUser.role.ToLower() == "admin")
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
