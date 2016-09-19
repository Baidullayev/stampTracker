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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
    }
}
