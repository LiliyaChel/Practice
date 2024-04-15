using kidstrUser.Functions;
using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class AddChangeDetOrdr : Form
    {
        private Ordr dataO;
        private bool change;
        private string state;
        private double? currentCost;
        private Dictionary<int, int> oldAS = new Dictionary<int, int>();
        private List<AddServ> dataAS;
        private List<Employee> dataE;
        private List<Age> dataA;
        private List<Service> dataS;
        private List<Price> AvailableP = new List<Price>();
        private List<Service> AvailableS = new List<Service>();
        private List<Employee> AvailableE = new List<Employee>();

        public AddChangeDetOrdr(List<AddServ> addServs, List<Employee> employees, List<Age> ages, List<Service> services)
        {
            dataO = new Ordr();
            dataAS = addServs;
            dataE = employees;
            dataA = ages;
            dataS = services;
            dataO.AddServs = new List<AddServ>();

            InitializeComponent();
            Text += "Добавить заказ";
        }
        public AddChangeDetOrdr(Ordr ordr, List<AddServ> addServs, List<Employee> employees, List<Age> ages, List<Service> services)
        {
            dataO = ordr;
            dataAS = addServs;
            dataE = employees;
            dataA = ages;
            dataS = services;

            change = true;

            InitializeComponent();

            Text += $"Изменить заказ № {dataO.IdOrdr}";
        }
        public AddChangeDetOrdr(Ordr ordr)
        {
            dataO = ordr;
            dataA = new List<Age> { dataO.Age };
            dataAS = dataO.AddServs;
            dataE = new List<Employee> { dataO.Employee };
            dataS = new List<Service> { dataO.Service };

            InitializeComponent();

            Text += $"Детали заказа № {dataO.IdOrdr}";
            save.Visible = false;
            gridAServ.ReadOnly = true;
            school.ReadOnly = true;
            contact.ReadOnly = true;
            datetime.ReadOnly = true;
            meetpoint.ReadOnly = true;
            party.ReadOnly = true;
            accom.ReadOnly = true;
            party.Increment = 0;
            accom.Increment = 0;
        }

        private void AddChangeOrdr_Load(object sender, EventArgs e)
        {
            age.DataSource = dataA;
            age.DisplayMember = "Name";
            age.ValueMember = "IdGroup";
            if (dataO.IdOrdr > 0)
            {
                school.Text = dataO.School;
                contact.Text = dataO.Contact;
                datetime.Text = dataO.DateTime.ToString("dd.MM.yyyy HH:mm");
                meetpoint.Text = dataO.MeetPoint;
                party.Value = dataO.PartyCount;
                accom.Value = dataO.AccomCount;
                currentCost = dataO.Cost;
                cost.Text = currentCost.ToString();
                prepay.Text = dataO.Prepay.ToString();
                status.Text = dataO.Status;
                find_service();
                find_price();
                find_emp();
                age.SelectedValue = dataO.IdGroup;
                serv.DataSource = new BindingSource(new List<Service> { dataO.Service }.Union(AvailableS), null);
                price.DataSource = new BindingSource(new List<Price> { dataO.Price }.Union(AvailableP), null);
                guide.DataSource = new BindingSource(new List<Employee> { dataO.Employee }.Union(AvailableE), null);
                serv.SelectedItem = dataO.Service;
                price.SelectedItem = dataO.Price;
                guide.SelectedItem = dataO.Employee;
            }

            foreach (AddServ a in dataO.AddServs)
            {
                oldAS[a.IdAdd] = a.Count;
                dataAS[dataAS.FindIndex(x => x.IdAdd == a.IdAdd)].Count = a.Count;
            }

            gridAServ.DataSource = new BindingSource(dataAS, null);
            gridAServ = TableFunc.AddHeader(gridAServ, new List<string> { "ID", "Название", "Стоимость", "Устарела", "Количество" });
            for (int i = 0; i < 4; i++)
            {
                gridAServ.Columns[i].ReadOnly = true;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(school.Text) || string.IsNullOrWhiteSpace(contact.Text) || !datetime.MaskFull || string.IsNullOrWhiteSpace(meetpoint.Text) || serv.Items.Count == 0 || price.Items.Count == 0 || guide.Items.Count == 0)
            {
                MessageBox.Show("Заполнены не все обязательные поля");
            }
            else
            {
                dataO.School = school.Text;
                dataO.Contact = contact.Text;
                dataO.DateTime = DateTime.ParseExact(datetime.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                dataO.MeetPoint = meetpoint.Text;
                dataO.PartyCount = (int)party.Value;
                dataO.AccomCount = (int)accom.Value;
                dataO.IdGroup = (int)age.SelectedValue;
                dataO.IdEmp = ((Employee)guide.SelectedItem).IdEmp;
                dataO.IdPrice = ((Price)price.SelectedItem).IdPrice;
                dataO.Cost = float.Parse(cost.Text);
                dataO.Prepay = float.Parse(prepay.Text);

                if (dataO.IdStat == 0)
                {
                    dataO.IdStat = 1;
                }

                dataO.Current = CurrentUser.current.Login;

                if (change)
                {
                    state = JsonFunc.Request("UpdateOrdr", "PUT", JsonConvert.SerializeObject(dataO));
                }
                else
                {
                    state = JsonFunc.Request("AddOrdr", "POST", JsonConvert.SerializeObject(dataO));
                }
                if (state == "-2" || state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                if (!change)
                {
                    dataO.IdOrdr = int.Parse(state);
                }

                foreach (DataGridViewRow row in gridAServ.Rows)
                {
                    if ((int)row.Cells[4].Value > 0 && !oldAS.ContainsKey((int)row.Cells[0].Value))
                    {
                        state = JsonFunc.Request("AddAServOrdr", "POST", JsonConvert.SerializeObject(new AddServOrdr((int)row.Cells[0].Value, dataO.IdOrdr, (int)row.Cells[4].Value)));
                    }
                    else if ((int)row.Cells[4].Value == 0 && oldAS.ContainsKey((int)row.Cells[0].Value))
                    {
                        state = JsonFunc.Delete("DeleteAServOrdr", (int)row.Cells[0].Value + "/" + dataO.IdOrdr);
                    }
                    else if ((int)row.Cells[4].Value > 0 && oldAS[(int)row.Cells[0].Value] != (int)row.Cells[4].Value)
                    {
                        state = JsonFunc.Request("UpdateAServOrdr", "PUT", JsonConvert.SerializeObject(new AddServOrdr((int)row.Cells[0].Value, dataO.IdOrdr, (int)row.Cells[4].Value)));
                    }
                    if (state == "-2" || state == "-1")
                    {
                        MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                        break;
                    }
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
        private void ComboBox_DropDown(object sender, System.EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (object s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s.ToString(), font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void find_service()
        {
            Service old = new Service();
            if (serv.Items.Count > 0)
            {
                old = (Service)serv.SelectedItem;
            }

            AvailableS = dataS.FindAll(x => x.Ages.Contains(age.SelectedItem) && !x.Outdated
                && x.Days.Exists(y => y.DayNum == (int)DateTime.ParseExact(datetime.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture).DayOfWeek));
            serv.DataSource = new BindingSource(AvailableS, null);

            if (serv.Items.Count > 0 && AvailableS.Contains(old))
            {
                old = (Service)serv.SelectedItem;
            }

            find_price();
            find_emp();
        }
        private void find_price()
        {
            Price old = new Price();
            if (price.Items.Count > 0)
            {
                old = (Price)price.SelectedItem;
            }

            if (serv.Items.Count > 0)
            {
                AvailableP = ((Service)serv.SelectedItem).Prices.FindAll(x => !x.Outdated && x.MemberMin <= party.Value
                    && x.MemberMax >= party.Value && x.AccomCount == accom.Value);
            }
            else
            {
                AvailableP = new List<Price>();
            }
            price.DataSource = new BindingSource(AvailableP, null);
            cost_changed();

            if (price.Items.Count > 0 && AvailableP.Contains(old))
            {
                old = (Price)price.SelectedItem;
            }
        }
        private void find_emp()
        {
            Employee old = new Employee();
            if (guide.Items.Count > 0)
            {
                old = (Employee)guide.SelectedItem;
            }

            if (serv.Items.Count > 0)
            {
                AvailableE = dataE.FindAll(x => x.Guide.Contains((Service)serv.SelectedItem) && !x.Orders.Exists(y => y.DateTime.Date == DateTime.ParseExact(datetime.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture).Date && y.IdOrdr != dataO.IdOrdr));
            }
            guide.DataSource = new BindingSource(AvailableE, null);

            if (guide.Items.Count > 0 && AvailableE.Contains(old))
            {
                old = (Employee)guide.SelectedItem;
            }
        }

        private void memb_ValueChanged(object sender, EventArgs e)
        {
            find_price();
        }

        private void age_SelectedValueChanged(object sender, EventArgs e)
        {
            DateTime now;
            if (DateTime.TryParseExact(datetime.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out now))
            {
                find_service();
            }
        }

        private void datetime_Validated(object sender, EventArgs e)
        {
            find_service();
            find_emp();
        }

        private void price_SelectedIndexChanged(object sender, EventArgs e)
        {
            cost_changed();
        }

        private void cost_changed()
        {
            if (price.Items.Count > 0)
            {
                currentCost = ((Price)price.SelectedItem).Cost;
            }
            else
            {
                currentCost = 0;
            }

            foreach (DataGridViewRow row in gridAServ.Rows)
            {
                if ((int)row.Cells["Count"].Value > 0)
                {
                    currentCost += (double)row.Cells["Cost"].Value * (int)row.Cells["Count"].Value;
                }
            }
            cost.Text = currentCost.ToString();
            prepay.Text = (currentCost * 0.33).ToString();
        }

        private void gridAServ_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cost_changed();
        }
    }
}
