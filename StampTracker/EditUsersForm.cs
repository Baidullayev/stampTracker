using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StampTracker
{
    public partial class EditUsersForm : Form
    {
        public EditUsersForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool notExist = true;

            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if(Application.OpenForms[i].Name == "NewUserForm")
                {
                    notExist = false; 
                    Application.OpenForms[i].TopMost = true;
                }
               
            }
            if(notExist)
            {
                NewUserForm newUserForm = new NewUserForm();
                newUserForm.Show();
            }

        }
    }
}
