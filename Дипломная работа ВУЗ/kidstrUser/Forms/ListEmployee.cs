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
    public partial class ListEmployee : Form
    {
        private Form parent;
        private Form child;
        private bool backcommand;
        private string state;
        private List<Employee> data;
        private List<Guide> guides;
        private List<Service> services;
        private List<Models.Type> types;
        private List<Direction> directions;
        public ListEmployee(Form p)
        {
            parent = p;
            backcommand = false;
            InitializeComponent();
        }

        private void ListEmployee_Load(object sender, EventArgs e)
        {
            load_data();
            gridUser = TableFunc.AddHeader(gridUser, new List<string> { "Паспорт", "ФИО", "Телефон" });
        }

        private void ListEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!backcommand)
            {
                Application.Exit();
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void back_Click(object sender, EventArgs e)
        {
            backcommand = true;
            Close();
            parent.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            child = new AddChangeDetEmployee(services);
            child.ShowDialog();
            load_data();
        }

        private void change_Click(object sender, EventArgs e)
        {
            child = new AddChangeDetEmployee((Employee)gridUser.CurrentRow.DataBoundItem, services);
            child.ShowDialog();
            load_data();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удалить", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                state = JsonFunc.Delete("DeleteEmployee", ((Employee)gridUser.CurrentRow.DataBoundItem).IdEmp.ToString() + "/" + CurrentUser.current.Login);
                if (state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                load_data();
            }
        }

        private void details_Click(object sender, EventArgs e)
        {
            child = new AddChangeDetEmployee((Employee)gridUser.CurrentRow.DataBoundItem);
            child.ShowDialog();

        }
        private void load_data()
        {
            data = JsonConvert.DeserializeObject<List<Employee>>(JsonFunc.ReturnList("Employees"));
            guides = JsonConvert.DeserializeObject<List<Guide>>(JsonFunc.ReturnList("Guides"));
            services = JsonConvert.DeserializeObject<List<Service>>(JsonFunc.ReturnList("Services"));
            types = JsonConvert.DeserializeObject<List<Models.Type>>(JsonFunc.ReturnList("Types"));
            directions = JsonConvert.DeserializeObject<List<Direction>>(JsonFunc.ReturnList("Directions"));
            foreach (Service s in services)
            {
                s.Type = types.First(x => x.IdType == s.IdType).Name;
                s.Direction = directions.First(x => x.IdDir == s.IdDir).Name;
            }
            foreach (var emp in data)
            {
                emp.Guide = (from s in services
                             join g in guides on s.IdServ equals g.IdServ
                             where g.IdEmp == emp.IdEmp
                             select s).ToList();
            }
            gridUser.DataSource = new BindingSource(data, null);
        }
    }
}
