using kidstrUser.Models;
using System;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class AddChangePrice : Form
    {
        private AddChangeDetService parent;
        private Price oldP;
        private Price data;
        private bool change;

        public AddChangePrice(AddChangeDetService p)
        {
            parent = p;
            data = new Price();

            InitializeComponent();
            Text = "Добавить цену";
        }
        public AddChangePrice(AddChangeDetService p, Price price)
        {
            parent = p;
            oldP = price;
            data = price;
            change = true;

            InitializeComponent();
            Text = "Изменить цену";

            min.Text = data.MemberMin.ToString();
            max.Text = data.MemberMax.ToString();
            accomp.Text = data.AccomCount.ToString();
            cost.Text = data.Cost.ToString();
            condit.Text = data.Condit;
            outdated.Checked = data.Outdated;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(min.Text) || string.IsNullOrWhiteSpace(accomp.Text) || string.IsNullOrWhiteSpace(cost.Text))
            {
                MessageBox.Show("Заполнены не все обязательные поля");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(max.Text))
                {
                    data.MemberMax = null;
                }
                else
                {
                    data.MemberMax = int.Parse(max.Text);
                }

                data.MemberMin = int.Parse(min.Text);
                data.AccomCount = int.Parse(accomp.Text);
                data.Cost = float.Parse(cost.Text);
                data.Condit = condit.Text;
                data.Outdated = outdated.Checked;

                if (change)
                {
                    if (parent.addprice.Remove(oldP))
                    {
                        parent.addprice.Add(data);
                    }

                    if (parent.updateprice.Remove(oldP) || parent.dataS.Prices.Remove(oldP))
                    {
                        parent.updateprice.Add(data);
                        parent.dataS.Prices.Add(data);
                    }
                }
                else
                {
                    parent.addprice.Add(data);
                }
                Close();
            }
        }

        private void count(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
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
