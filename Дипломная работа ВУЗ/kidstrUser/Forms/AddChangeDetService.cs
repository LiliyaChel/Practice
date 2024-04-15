using kidstrUser.Functions;
using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class AddChangeDetService : Form
    {
        private Form child;
        public Service dataS;
        private List<Direction> dataDi;
        private List<Models.Type> dataT;
        private List<Age> dataA;
        private bool _change;
        private string state;
        public List<Price> addprice = new List<Price>();
        public List<Price> updateprice = new List<Price>();
        public List<Price> deleteprice = new List<Price>();
        private List<int> oldA = new List<int>();
        private List<int> oldD = new List<int>();

        public AddChangeDetService(List<Direction> directions, List<Models.Type> types, List<Age> ages)
        {
            dataS = new Service();
            dataS.Ages = new List<Age>();
            dataS.Prices = new List<Price>();
            dataS.Days = new List<Models.Day>();
            dataDi = directions;
            dataT = types;
            dataA = ages;

            InitializeComponent();

            Text += "Добавить мероприятие";
        }
        public AddChangeDetService(Service service, List<Direction> directions, List<Models.Type> types, List<Age> ages)
        {
            dataS = service;
            dataDi = directions;
            dataT = types;
            dataA = ages;
            _change = true;

            InitializeComponent();

            Text += $"Изменить мероприятие № {dataS.IdServ}";
        }
        public AddChangeDetService(Service service, List<Age> ages)
        {
            dataS = service;
            dataA = ages;
            dataDi = new List<Direction> { new Direction(dataS.IdDir, dataS.Direction) };
            dataT = new List<Models.Type> { new Models.Type(dataS.IdType, dataS.Type) };

            InitializeComponent();

            Text += $"Детали мероприятия № {dataS.IdServ}";
            save.Visible = false;
            add.Visible = false;
            change.Visible = false;
            delete.Visible = false;
            name.ReadOnly = true;
            duration.ReadOnly = true;
            desc.ReadOnly = true;
            condit.ReadOnly = true;
            outdated.AutoCheck = false;
            this.ages.SelectionMode = SelectionMode.None;
            days.SelectionMode = SelectionMode.None;
        }

        private void AddChangeService_Load(object sender, EventArgs e)
        {
            ((ListBox)ages).DataSource = dataA;
            ((ListBox)ages).DisplayMember = "Name";
            ((ListBox)ages).ValueMember = "IdGroup";
            foreach (Age a in dataS.Ages)
            {
                ages.SetItemChecked(dataA.IndexOf(a), true);
                oldA.Add(a.IdGroup);
            }

            foreach (Models.Day d in dataS.Days)
            {
                days.SetItemChecked((d.DayNum - 1), true);
                oldD.Add(d.DayNum - 1);
            }

            gridPrice.DataSource = new BindingSource(dataS.Prices, null);
            gridPrice = TableFunc.AddHeader(gridPrice, new List<string> { "ID", "Минимум человек", "Максимум человек", "Сопровождающих", "Условия", "Стоимость", "Устарела" });

            type.DataSource = dataT;
            type.DisplayMember = "Name";
            type.ValueMember = "IdType";
            direction.DataSource = dataDi;
            direction.DisplayMember = "Name";
            direction.ValueMember = "IdDir";

            if (dataS.IdServ > 0)
            {
                type.SelectedValue = dataS.IdType;
                direction.SelectedValue = dataS.IdDir;
                name.Text = dataS.Name;
                duration.Text = dataS.Duration;
                desc.Text = dataS.Descr;
                condit.Text = dataS.Condit;
                outdated.Checked = dataS.Outdated;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(duration.Text))
            {
                MessageBox.Show("Заполнены не все обязательные поля");
            }
            else
            {
                dataS.Name = name.Text;
                dataS.Duration = duration.Text;
                dataS.Descr = desc.Text;
                dataS.Condit = condit.Text;
                dataS.Outdated = outdated.Checked;
                dataS.IdType = (int)type.SelectedValue;
                dataS.IdDir = (int)direction.SelectedValue;
                dataS.Current = CurrentUser.current.Login;

                if (_change)
                {
                    state = JsonFunc.Request("UpdateService", "PUT", JsonConvert.SerializeObject(dataS));
                }
                else
                {
                    state = JsonFunc.Request("AddService", "POST", JsonConvert.SerializeObject(dataS));
                }
                if (state == "-2" || state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                if (!_change)
                {
                    dataS.IdServ = int.Parse(state);
                }

                int[] checkeddays = days.CheckedIndices.Cast<int>().ToArray();
                for (int i = 0; i < 7; i++)
                {
                    if (checkeddays.Contains(i) && !oldD.Contains(i))
                    {
                        state = JsonFunc.Request("AddDay", "POST", JsonConvert.SerializeObject(new Models.Day(dataS.IdServ, (i + 1))));
                        if (state == "-2")
                        {
                            MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                            break;
                        }
                    }
                    else
                    if (!checkeddays.Contains(i) && oldD.Contains(i))
                    {
                        state = JsonFunc.Delete("DeleteDay", dataS.IdServ + "/" + (i + 1));
                        if (state == "-1")
                        {
                            MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                            break;
                        }
                    }
                }

                var checkedages = ages.CheckedItems;
                foreach (Age a in dataA)
                {
                    if (checkedages.Contains(a) && !oldA.Contains(a.IdGroup))
                    {
                        state = JsonFunc.Request("AddServiceAge", "POST", JsonConvert.SerializeObject(new Models.ServiceAge(dataS.IdServ, a.IdGroup)));
                        if (state == "-2")
                        {
                            MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                            break;
                        }
                    }
                    else
                    if (!checkedages.Contains(a) && oldA.Contains(a.IdGroup))
                    {
                        state = JsonFunc.Delete("DeleteServiceAge", dataS.IdServ + "/" + a.IdGroup);
                        if (state == "-1")
                        {
                            MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                            break;
                        }
                    }
                }

                foreach (Price pr in addprice)
                {
                    pr.IdServ = dataS.IdServ;
                    state = JsonFunc.Request("AddPrice", "POST", JsonConvert.SerializeObject(pr));
                    if (state == "-2")
                    {
                        MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                        break;
                    }
                }
                foreach (Price pr in updateprice)
                {
                    state = JsonFunc.Request("UpdatePrice", "PUT", JsonConvert.SerializeObject(pr));
                    if (state == "-2" || state == "-1")
                    {
                        MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                        break;
                    }
                }
                foreach (Price pr in deleteprice)
                {
                    state = JsonFunc.Delete("DeletePrice", pr.IdPrice.ToString());
                    if (state == "-1")
                    {
                        MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                        break;
                    }
                }
                Close();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            child = new AddChangePrice(this);
            child.ShowDialog();
            RefreshGrid();
        }

        private void change_Click(object sender, EventArgs e)
        {
            child = new AddChangePrice(this, (Price)gridPrice.CurrentRow.DataBoundItem);
            child.ShowDialog();
            RefreshGrid();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удалить", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                addprice.Remove((Price)gridPrice.CurrentRow.DataBoundItem);
                updateprice.Remove((Price)gridPrice.CurrentRow.DataBoundItem);
                dataS.Prices.Remove((Price)gridPrice.CurrentRow.DataBoundItem);
                if (((Price)gridPrice.CurrentRow.DataBoundItem).IdPrice > 0)
                {
                    deleteprice.Add((Price)gridPrice.CurrentRow.DataBoundItem);
                }

                RefreshGrid();
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

        private void RefreshGrid()
        {
            gridPrice.DataSource = new BindingSource(dataS.Prices.Concat(addprice).ToList(), null);
        }
    }
}
