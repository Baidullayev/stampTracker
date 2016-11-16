namespace StampTracker
{
    partial class EditUsersForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hiddenId = new System.Windows.Forms.Label();
            this.createUserButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.roleBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fatherNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lastnameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(421, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hiddenId);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.roleBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.passwordBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.usernameBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fatherNameBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lastnameBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.NameLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 250);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Детальная информация";
            // 
            // hiddenId
            // 
            this.hiddenId.AutoSize = true;
            this.hiddenId.Location = new System.Drawing.Point(10, 230);
            this.hiddenId.Name = "hiddenId";
            this.hiddenId.Size = new System.Drawing.Size(29, 13);
            this.hiddenId.TabIndex = 11;
            this.hiddenId.Text = "emty";
            this.hiddenId.Visible = false;
            // 
            // createUserButton
            // 
            this.createUserButton.Location = new System.Drawing.Point(67, 334);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(195, 31);
            this.createUserButton.TabIndex = 8;
            this.createUserButton.Text = "Добавить нового пользователя";
            this.createUserButton.UseVisualStyleBackColor = true;
            this.createUserButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(203, 218);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(19, 189);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(259, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Сохранить изменения";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // roleBox
            // 
            this.roleBox.FormattingEnabled = true;
            this.roleBox.Items.AddRange(new object[] {
            "admin",
            "user",
            "reader"});
            this.roleBox.Location = new System.Drawing.Point(114, 162);
            this.roleBox.Name = "roleBox";
            this.roleBox.Size = new System.Drawing.Size(164, 21);
            this.roleBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Роль";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(82, 132);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(196, 20);
            this.passwordBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Пароль";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(82, 103);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(196, 20);
            this.usernameBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Логин";
            // 
            // fatherNameBox
            // 
            this.fatherNameBox.Location = new System.Drawing.Point(82, 74);
            this.fatherNameBox.Name = "fatherNameBox";
            this.fatherNameBox.Size = new System.Drawing.Size(196, 20);
            this.fatherNameBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Отчество";
            // 
            // lastnameBox
            // 
            this.lastnameBox.Location = new System.Drawing.Point(82, 46);
            this.lastnameBox.Name = "lastnameBox";
            this.lastnameBox.Size = new System.Drawing.Size(196, 20);
            this.lastnameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Фамилия";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(82, 19);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(196, 20);
            this.nameBox.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(16, 22);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Имя";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Поиск по фамильно";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(309, 37);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(318, 364);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // EditUsersForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 413);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.createUserButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "EditUsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.EditUsersForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createUserButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox roleBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fatherNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lastnameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label hiddenId;
    }
}