using kidstrUser.Functions;
using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class ListAServ : Form
    {
        private Form parent;
        private Form child;
        private bool backcommand;
        private string state;
        private List<AddServ> data;

        public ListAServ(Form p)
        {
            parent = p;
            InitializeComponent();
        }

        private void ListAServ_Load(object sender, EventArgs e)
        {
            Load_data();
            gridAddServ = TableFunc.AddHeader(gridAddServ, new List<string> { "ID", "Название", "Стоимость", "Устарела" });
            gridAddServ.Columns[4].Visible = false;
        }

        private void ListAServ_FormClosed(object sender, FormClosedEventArgs e)
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
            child = new AddChangeAServ();
            child.ShowDialog();
            Load_data();
        }

        private void change_Click(object sender, EventArgs e)
        {
            child = new AddChangeAServ((AddServ)gridAddServ.CurrentRow.DataBoundItem);
            child.ShowDialog();
            Load_data();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удалить", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                state = JsonFunc.Delete("DeleteAServ", ((AddServ)gridAddServ.CurrentRow.DataBoundItem).IdAdd.ToString() + "/" + CurrentUser.current.Login);
                if (state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                Load_data();
            }
        }

        private void Load_data()
        {
            data = JsonConvert.DeserializeObject<List<AddServ>>(JsonFunc.ReturnList("AddServs"));
            gridAddServ.DataSource = new BindingSource(data, null);
            if (gridAddServ.Rows.Count == 0)
            {
                change.Enabled = false;
                delete.Enabled = false;
            }
            else
            {
                change.Enabled = true;
                delete.Enabled = true;
            }
        }
    }
}
