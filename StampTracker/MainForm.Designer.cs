namespace StampTracker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loginStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConnectionStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.myMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыSqlServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditUsersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loginMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.myMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginStripLabel,
            this.toolStripStatusLabel2,
            this.ConnectionStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(820, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loginStripLabel
            // 
            this.loginStripLabel.Name = "loginStripLabel";
            this.loginStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // ConnectionStripLabel
            // 
            this.ConnectionStripLabel.Name = "ConnectionStripLabel";
            this.ConnectionStripLabel.Size = new System.Drawing.Size(118, 17);
            this.ConnectionStripLabel.Text = "toolStripStatusLabel1";
            // 
            // myMenu
            // 
            this.myMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.loginMenu});
            this.myMenu.Location = new System.Drawing.Point(0, 0);
            this.myMenu.Name = "myMenu";
            this.myMenu.Size = new System.Drawing.Size(820, 24);
            this.myMenu.TabIndex = 1;
            this.myMenu.Text = "menuStrip1";
            this.myMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.myMenu_ItemClicked);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMenu,
            this.openMenu,
            this.saveMenu,
            this.выйтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // createMenu
            // 
            this.createMenu.Name = "createMenu";
            this.createMenu.Size = new System.Drawing.Size(132, 22);
            this.createMenu.Text = "Создать";
            this.createMenu.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(132, 22);
            this.openMenu.Text = "Открыть";
            this.openMenu.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // saveMenu
            // 
            this.saveMenu.Enabled = false;
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.Size = new System.Drawing.Size(132, 22);
            this.saveMenu.Text = "Сохранить";
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыSqlServerToolStripMenuItem,
            this.addUserMenu,
            this.EditUsersMenu});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // параметрыSqlServerToolStripMenuItem
            // 
            this.параметрыSqlServerToolStripMenuItem.Name = "параметрыSqlServerToolStripMenuItem";
            this.параметрыSqlServerToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.параметрыSqlServerToolStripMenuItem.Text = "Параметры";
            this.параметрыSqlServerToolStripMenuItem.Click += new System.EventHandler(this.параметрыSqlServerToolStripMenuItem_Click);
            // 
            // addUserMenu
            // 
            this.addUserMenu.Name = "addUserMenu";
            this.addUserMenu.Size = new System.Drawing.Size(245, 22);
            this.addUserMenu.Text = "Добавить пользователя";
            this.addUserMenu.Click += new System.EventHandler(this.добавитьПользователяToolStripMenuItem_Click);
            // 
            // EditUsersMenu
            // 
            this.EditUsersMenu.Name = "EditUsersMenu";
            this.EditUsersMenu.Size = new System.Drawing.Size(245, 22);
            this.EditUsersMenu.Text = "Рекдактировать пользователей";
            this.EditUsersMenu.Click += new System.EventHandler(this.рекдактироватьПользователейToolStripMenuItem_Click);
            // 
            // loginMenu
            // 
            this.loginMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.loginMenu.Name = "loginMenu";
            this.loginMenu.Size = new System.Drawing.Size(52, 20);
            this.loginMenu.Text = "Войти";
            this.loginMenu.Click += new System.EventHandler(this.loginMenu_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 479);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.myMenu);
            this.MainMenuStrip = this.myMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StampTracker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Enter += new System.EventHandler(this.MainForm_Enter);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.myMenu.ResumeLayout(false);
            this.myMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel loginStripLabel;
        private System.Windows.Forms.MenuStrip myMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenu;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыSqlServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionStripLabel;
        private System.Windows.Forms.ToolStripMenuItem loginMenu;
        private System.Windows.Forms.ToolStripMenuItem addUserMenu;
        private System.Windows.Forms.ToolStripMenuItem EditUsersMenu;
    }
}