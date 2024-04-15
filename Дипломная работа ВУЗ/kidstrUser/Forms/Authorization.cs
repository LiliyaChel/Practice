using kidstrUser.Forms;
using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace kidstrUser
{
    public partial class Authorization : Form
    {

        public Authorization()
        {
            InitializeComponent();
        }
        private void Authorization_Load(object sender, EventArgs e)
        {
            CurrentUser.current = new User();
        }

        private void go_Click(object sender, EventArgs e)
        {
            CurrentUser.current.Login = "NaN";
            CurrentUser.current.Login = login.Text;
            CurrentUser.current.Password = CurrentUser.HashPassword(password.Text);
            int result = int.Parse(JsonFunc.Request("Authent", "POST", JsonConvert.SerializeObject(CurrentUser.current)));
            if (result ==-1)
                MessageBox.Show("Неверный логин/пароль");
            else
            if (result == 0 && admin.Checked)
                MessageBox.Show("Нет прав доступа к панели администратора");
            else
            if (admin.Checked)
            {
                MainAdmin main = new MainAdmin(this);
                Hide();
                main.Show();
                login.Text = "";
                password.Text = "";
                admin.Checked = false;
            }
            else
            {
                MainManager main = new MainManager(this);
                Hide();
                main.Show();
                login.Text = "";
                password.Text = "";
                admin.Checked = false;
            }
        }

    }
}
