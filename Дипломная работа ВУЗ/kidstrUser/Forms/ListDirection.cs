using kidstrUser.Functions;
using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class ListDirection : Form
    {
        private Form parent;
        private Form child;
        private bool backcommand;
        private string state;
        private List<Direction> data;
        public ListDirection(Form p)
        {
            parent = p;
            backcommand = false;
            InitializeComponent();
        }

        private void ListDirection_Load(object sender, EventArgs e)
        {
            Load_data();
            gridDirection = TableFunc.AddHeader(gridDirection, new List<string> { "ID", "Название", "Устарело" });
        }

        private void ListDirection_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!backcommand)
            {
                Application.Exit();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            backcommand = true;
            Close();
            parent.Show();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Load_data();
        }

        private void add_Click(object sender, EventArgs e)
        {
            child = new AddChangeDirection();
            child.ShowDialog();
            Load_data();
        }

        private void change_Click(object sender, EventArgs e)
        {
            child = new AddChangeDirection((Direction)gridDirection.CurrentRow.DataBoundItem);
            child.ShowDialog();
            Load_data();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удалить", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                state = JsonFunc.Delete("DeleteDirection", ((Direction)gridDirection.CurrentRow.DataBoundItem).IdDir.ToString() + "/" + CurrentUser.current.Login);
                if (state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                Load_data();
            }
        }
        private void Load_data()
        {
            data = JsonConvert.DeserializeObject<List<Direction>>(JsonFunc.ReturnList("Directions"));
            gridDirection.DataSource = new BindingSource(data, null);
            if (gridDirection.Rows.Count == 0)
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
