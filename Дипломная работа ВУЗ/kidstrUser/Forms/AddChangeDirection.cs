using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class AddChangeDirection : Form
    {
        private Direction data;
        private bool change;
        private string state;

        public AddChangeDirection()
        {
            data = new Direction();

            InitializeComponent();

            Text = "Добавить направление";
        }

        public AddChangeDirection(Direction direction)
        {
            data = direction;
            change = true;

            InitializeComponent();

            name.Text = data.Name;
            outdated.Checked = data.Outdated;

            Text = $"Изменить направление № {data.IdDir}";
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                MessageBox.Show("Заполнены не все обязательные поля");
            }
            else
            {
                data.Name = name.Text;
                data.Outdated = outdated.Checked;
                data.Current = CurrentUser.current.Login;

                if (change)
                {
                    state = JsonFunc.Request("UpdateDirection", "PUT", JsonConvert.SerializeObject(data));
                }
                else
                {
                    state = JsonFunc.Request("AddDirection", "POST", JsonConvert.SerializeObject(data));
                }
                if (state == "-2" || state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                Close();
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
