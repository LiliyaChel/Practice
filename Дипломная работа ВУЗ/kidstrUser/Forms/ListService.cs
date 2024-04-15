using kidstrUser.Functions;
using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class ListService : Form
    {
        private Form parent;
        private Form child;
        private bool backcommand;
        private string state;
        private List<Service> data;
        private List<Models.Type> types;
        private List<Direction> directions;
        private List<Age> ages;
        private List<Price> prices;
        private List<ServiceAge> servage;
        private List<Models.Day> days;

        public ListService(Form p)
        {
            parent = p;
            InitializeComponent();
        }

        private void ListServ_Load(object sender, EventArgs e)
        {
            Load_data();
            gridServ = TableFunc.AddHeader(gridServ, new List<string> { "ID", "Название", "Продолжительность", "Описание", "Ограничения", "", "", "Устарела", "Тип", "Направление", "Выбрана" });
            gridServ.Columns[5].Visible = false;
            gridServ.Columns[6].Visible = false;
            gridServ.Columns[10].Visible = false;
        }

        private void ListServ_FormClosed(object sender, FormClosedEventArgs e)
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
            child = new AddChangeDetService(directions, types, ages);
            child.ShowDialog();
            Load_data();
        }

        private void change_Click(object sender, EventArgs e)
        {
            child = new AddChangeDetService((Service)gridServ.CurrentRow.DataBoundItem, directions, types, ages);
            child.ShowDialog();
            Load_data();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удалить", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                state = JsonFunc.Delete("DeleteService", ((Service)gridServ.CurrentRow.DataBoundItem).IdServ.ToString() + "/" + CurrentUser.current.Login);
                if (state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                Load_data();
            }
        }

        private void details_Click(object sender, EventArgs e)
        {
            child = new AddChangeDetService((Service)gridServ.CurrentRow.DataBoundItem, ages);
            child.ShowDialog();
        }
        private void Load_data()
        {
            data = JsonConvert.DeserializeObject<List<Service>>(JsonFunc.ReturnList("Services"));

            types = JsonConvert.DeserializeObject<List<Models.Type>>(JsonFunc.ReturnList("Types"));
            directions = JsonConvert.DeserializeObject<List<Direction>>(JsonFunc.ReturnList("Directions"));
            ages = JsonConvert.DeserializeObject<List<Age>>(JsonFunc.ReturnList("Ages"));

            prices = JsonConvert.DeserializeObject<List<Price>>(JsonFunc.ReturnList("Prices"));

            servage = JsonConvert.DeserializeObject<List<ServiceAge>>(JsonFunc.ReturnList("ServiceAges"));
            days = JsonConvert.DeserializeObject<List<Models.Day>>(JsonFunc.ReturnList("Days"));

            foreach (Service s in data)
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

            gridServ.DataSource = new BindingSource(data, null);

            if (gridServ.Rows.Count == 0)
            {
                change.Enabled = false;
                delete.Enabled = false;
                details.Enabled = false;
            }
            else
            {
                change.Enabled = true;
                delete.Enabled = true;
                details.Enabled = true;
            }
        }
    }
}
