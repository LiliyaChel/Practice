using kidstrUser.Functions;
using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class AddChangeDetEmployee : Form
    {
        private Employee dataE;
        private List<Service> dataS;
        private Dictionary<int, bool> oldS = new Dictionary<int, bool>();
        private bool change;
        private string state;

        public AddChangeDetEmployee(List<Service> services)
        {
            InitializeComponent();

            dataE = new Employee();
            dataS = services;

            Text += "Добавить сотрудника";
        }
        public AddChangeDetEmployee(Employee employee, List<Service> services)
        {
            InitializeComponent();

            dataE = employee;
            dataS = services;
            change = true;

            Text += $"Изменить данные сотрудника № {dataE.IdEmp}";

            id.Text = dataE.IdEmp;
            name.Text = dataE.Name;
            phone.Text = dataE.Phone;

            foreach (Service s in dataS)
            {
                if (dataE.Guide.Any(x => x.IdServ == s.IdServ))
                {
                    s.Checked = true;
                }
            }

        }
        public AddChangeDetEmployee(Employee employee)
        {
            InitializeComponent();

            dataE = employee;
            dataS = dataE.Guide;

            Text += $"Детальные данные сотрудника № {dataE.IdEmp}";

            id.Text = dataE.IdEmp;
            name.Text = dataE.Name;
            phone.Text = dataE.Phone;

            gridGuide.ReadOnly = true;
            save.Visible = false;
        }

        private void AddChangeEmployee_Load(object sender, EventArgs e)
        {
            gridGuide.DataSource = new BindingSource(dataS, null);

            gridGuide = TableFunc.AddHeader(gridGuide, new List<string> { "ID", "Название", "Продолжительность", "Описание", "Ограничения", "", "", "Устарела", "Тип", "Направление", "Выбрано" });
            gridGuide.Columns[5].Visible = false;
            gridGuide.Columns[6].Visible = false;
            gridGuide.Columns[10].Visible = save.Visible;
            for (int i = 0; i < 9; i++)
            {
                gridGuide.Columns[i].ReadOnly = true;
            }

            foreach (Service s in dataS)
            {
                oldS[s.IdServ] = s.Checked;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id.Text) || string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(phone.Text))
            {
                MessageBox.Show("Заполнены не все обязательные поля");
            }
            else
            {
                dataE.IdEmp = id.Text;
                dataE.Name = name.Text;
                dataE.Phone = phone.Text;
                dataE.Current = CurrentUser.current.Login;

                if (change)
                {
                    state = JsonFunc.Request("UpdateEmployee", "PUT", JsonConvert.SerializeObject(dataE));
                }
                else
                {
                    state = JsonFunc.Request("AddEmployee", "POST", JsonConvert.SerializeObject(dataE));
                }
                if (state == "-2" || state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                foreach (Service s in dataS)
                {
                    if (s.Checked && !oldS[s.IdServ])
                    {
                        state = JsonFunc.Request("AddGuide", "POST", JsonConvert.SerializeObject(new Guide(dataE.IdEmp, s.IdServ)));
                    }
                    if (!s.Checked && oldS[s.IdServ])
                    {
                        state = JsonFunc.Delete("DeleteGuide", dataE.IdEmp + "/" + s.IdServ);
                    }
                    if (state == "-2" || state == "-1")
                    {
                        MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                    }
                    break;
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
