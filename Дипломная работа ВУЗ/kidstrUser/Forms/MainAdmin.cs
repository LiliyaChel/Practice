using System;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class MainAdmin : Form
    {
        private Form parent;
        private Form child;
        private bool backcommand;

        public MainAdmin(Form p)
        {
            parent = p;
            InitializeComponent();
        }
        private void MainAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!backcommand)
            {
                Application.Exit();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            backcommand = true;
            Close();
            parent.Show();
        }

        private void menuAdminParamType_Click(object sender, EventArgs e)
        {
            child = new ListType(this);
            Hide();
            child.Show();
        }

        private void menuAdminParamDirect_Click(object sender, EventArgs e)
        {
            child = new ListDirection(this);
            Hide();
            child.Show();
        }

        private void menuAdminUsers_Click(object sender, EventArgs e)
        {
            child = new ListEmployee(this);
            Hide();
            child.Show();
        }

        private void menuAdminReports_Click(object sender, EventArgs e)
        {
            child = new Reports(this);
            Hide();
            child.Show();
        }
    }
}
