using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class AddChangeType : Form
    {
        private Models.Type data;
        private bool change;
        private string state;

        public AddChangeType()
        {
            data = new Models.Type();

            InitializeComponent();

            Text = "Добавить тип";
        }
        public AddChangeType(Models.Type type)
        {
            data = type;
            change = true;

            InitializeComponent();

            name.Text = data.Name;
            outdated.Checked = data.Outdated;

            Text = $"Изменить тип № {data.IdType}";
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
                    state = JsonFunc.Request("UpdateType", "PUT", JsonConvert.SerializeObject(data));
                }
                else
                {
                    state = JsonFunc.Request("AddType", "POST", JsonConvert.SerializeObject(data));
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
