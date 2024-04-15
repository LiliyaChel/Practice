using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class AddChangeAServ : Form
    {
        private AddServ data;
        private bool change;
        private string state;

        public AddChangeAServ()
        {
            data = new AddServ();

            InitializeComponent();

            Text = "Добавить доп. услугу";
        }
        public AddChangeAServ(AddServ current)
        {
            data = current;
            change = true;
            InitializeComponent();

            Text = $"Изменить доп. услугу № {data.IdAdd}";
            name.Text = data.Name;
            cost.Text = data.Cost.ToString();
            outdated.Checked = data.Outdated;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(cost.Text))
            {
                MessageBox.Show("Заполнены не все обязательные поля");
            }
            else
            {
                data.Name = name.Text;
                data.Cost = Math.Round(float.Parse(cost.Text), 2);
                data.Outdated = outdated.Checked;
                data.Current = CurrentUser.current.Login;

                if (change)
                {
                    state = JsonFunc.Request("UpdateAServ", "PUT", JsonConvert.SerializeObject(data));
                }
                else
                {
                    state = JsonFunc.Request("AddAServ", "POST", JsonConvert.SerializeObject(data));
                }
                if (state == "-2" || state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                Close();
            }
        }

        private void money(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 46 && (number != ',' || (number == ',' && ((TextBox)sender).Text.Contains(","))) || number == '.')
            {
                e.Handled = true;
            }
        }

        private void text(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsWhiteSpace(number) && !char.IsLetterOrDigit(number) && !char.IsPunctuation(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }
    }
}
