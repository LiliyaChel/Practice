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
    public partial class ListOrder : Form
    {
        private Form parent;
        private Form child;
        private bool backcommand;
        private string state;
        private List<Ordr> data;
        private List<Service> services;
        private List<Models.Type> types;
        private List<Direction> directions;
        private List<Age> ages;
        private List<Price> prices;
        private List<ServiceAge> servage;
        private List<Models.Day> days;
        private List<AddServ> aservs;
        private List<AddServ> aservs_clone;
        private List<AddServOrdr> aservordrs;
        private List<Models.Status> statuses;
        private List<Employee> employees;
        private List<Guide> guides;

        public ListOrder(Form p)
        {
            parent = p;
            backcommand = false;
            InitializeComponent();
        }

        private void ListOrder_Load(object sender, EventArgs e)
        {
            Load_data();
            gridOrder = TableFunc.AddHeader(gridOrder, new List<string> { "ID", "Организация", "Возраст", "Участников", "Сопрово-\nждающих", "Контакт", "Дата и время", "Точка встречи", "Стоимость", "Предоплата", "Услуга", "Статус" });
        }

        private void ListOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!backcommand)
            {
                Application.Exit();
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Load_data();
        }

        private void back_Click(object sender, EventArgs e)
        {
            backcommand = true;
            Close();
            parent.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            child = new AddChangeDetOrdr(aservs, employees, ages, services);
            child.ShowDialog();
            Load_data();
        }

        private void change_Click(object sender, EventArgs e)
        {
            child = new AddChangeDetOrdr((Ordr)gridOrder.CurrentRow.DataBoundItem, aservs, employees, ages, services);
            child.ShowDialog();
            Load_data();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удалить", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                state = JsonFunc.Delete("DeleteOrdr", ((Ordr)gridOrder.CurrentRow.DataBoundItem).IdOrdr.ToString() + "/" + CurrentUser.current.Login);
                if (state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                Load_data();
            }
        }

        private void status_Click(object sender, EventArgs e)
        {
            child = new Status((Ordr)gridOrder.CurrentRow.DataBoundItem, statuses);
            child.ShowDialog();
            Load_data();
        }

        private void details_Click(object sender, EventArgs e)
        {
            child = new AddChangeDetOrdr((Ordr)gridOrder.CurrentRow.DataBoundItem);
            child.ShowDialog();
        }
        private void Load_data()
        {
            data = JsonConvert.DeserializeObject<List<Ordr>>(JsonFunc.ReturnList("Ordrs"));

            // Data of services.
            services = JsonConvert.DeserializeObject<List<Service>>(JsonFunc.ReturnList("Services"));
            types = JsonConvert.DeserializeObject<List<Models.Type>>(JsonFunc.ReturnList("Types"));
            directions = JsonConvert.DeserializeObject<List<Direction>>(JsonFunc.ReturnList("Directions"));
            ages = JsonConvert.DeserializeObject<List<Age>>(JsonFunc.ReturnList("Ages"));
            prices = JsonConvert.DeserializeObject<List<Price>>(JsonFunc.ReturnList("Prices"));
            servage = JsonConvert.DeserializeObject<List<ServiceAge>>(JsonFunc.ReturnList("ServiceAges"));
            days = JsonConvert.DeserializeObject<List<Models.Day>>(JsonFunc.ReturnList("Days"));
            foreach (Service s in services)
            {
                s.Type = types.First(x => x.IdType == s.IdType).Name;
                s.Direction = directions.First(x => x.IdDir == s.IdDir).Name;
                s.Prices = prices.FindAll(x => x.IdServ == s.IdServ);
                s.Days = days.FindAll(x => x.IdServ == s.IdServ);
                s.Ages = (from sa in servage
                          join a in ages on sa.IdGroup equals a.IdGroup
                          where sa.IdServ == s.IdServ
                          select a).ToList();
            }

            //Data of employees.
            employees = JsonConvert.DeserializeObject<List<Employee>>(JsonFunc.ReturnList("Employees"));
            guides = JsonConvert.DeserializeObject<List<Guide>>(JsonFunc.ReturnList("Guides"));
            foreach (var emp in employees)
            {
                emp.Guide = (from s in services
                             join g in guides on s.IdServ equals g.IdServ
                             where g.IdEmp == emp.IdEmp
                             select s).ToList();
                emp.Orders = data.FindAll(x => x.IdEmp == emp.IdEmp);
            }

            var asr = JsonFunc.ReturnList("AddServs");
            aservs = JsonConvert.DeserializeObject<List<AddServ>>(asr);
            aservordrs = JsonConvert.DeserializeObject<List<AddServOrdr>>(JsonFunc.ReturnList("AddServOrdrs"));

            statuses = JsonConvert.DeserializeObject<List<Models.Status>>(JsonFunc.ReturnList("Statuses"));

            // Join all data.
            foreach (Ordr o in data)
            {
                aservs_clone = JsonConvert.DeserializeObject<List<AddServ>>(asr);
                o.AddServs = aservs_clone.Join(aservordrs, aId => aId.IdAdd, aoId => aoId.IdAdd, (aId, aoId) => new { aservs_clone = aId, aservordrs = aoId })
                   .Where(ao => ao.aservordrs.IdOrdr == o.IdOrdr).Select(a => { a.aservs_clone.Count = a.aservordrs.AddCount; return a.aservs_clone; }).ToList();
                o.Employee = employees.First(x => x.IdEmp == o.IdEmp);
                o.Service = services.First(x => x.Prices.Exists(y => y.IdPrice == o.IdPrice));
                o.Price = prices.First(x => x.IdPrice == o.IdPrice);
                o.Status = statuses.First(x => x.IdStat == o.IdStat).Name;
                o.Age = ages.First(x => x.IdGroup == o.IdGroup);
            }

            gridOrder.DataSource = new BindingSource(data, null);
            if (gridOrder.Rows.Count == 0)
            {
                change.Enabled = false;
                delete.Enabled = false;
                details.Enabled = false;
                status.Enabled = false;
            }
            else
            {
                change.Enabled = true;
                delete.Enabled = true;
                details.Enabled = true;
                status.Enabled = true;
            }
        }
    }
}
