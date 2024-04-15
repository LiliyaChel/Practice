using System;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class MainManager : Form
    {
        private Form parent;
        private Form child;
        private bool backcommand;

        public MainManager(Form p)
        {
            parent = p;
            InitializeComponent();
        }

        private void MainManager_FormClosed(object sender, FormClosedEventArgs e)
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

        private void menuAdminServ_Click(object sender, EventArgs e)
        {
            child = new ListService(this);
            Hide();
            child.Show();
        }

        private void menuAdminAddServ_Click(object sender, EventArgs e)
        {
            child = new ListAServ(this);
            Hide();
            child.Show();
        }

        private void menuAdminOrders_Click(object sender, EventArgs e)
        {
            child = new ListOrder(this);
            Hide();
            child.Show();
        }
    }
}
