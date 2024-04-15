using kidstrUser.Functions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class ListType : Form
    {
        private Form parent;
        private Form child;
        private bool backcommand;
        private string state;
        private List<Models.Type> data;
        public ListType(Form p)
        {
            parent = p;
            backcommand = false;
            InitializeComponent();
        }

        private void Types_Load(object sender, EventArgs e)
        {
            Load_data();
            gridType = TableFunc.AddHeader(gridType, new List<string> { "ID", "Название", "Устарел" });
        }

        private void Types_FormClosed(object sender, FormClosedEventArgs e)
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
            child = new AddChangeType();
            child.ShowDialog();
            Load_data();
        }

        private void change_Click(object sender, EventArgs e)
        {
            child = new AddChangeType((Models.Type)gridType.CurrentRow.DataBoundItem);
            child.ShowDialog();
            Load_data();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удалить", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                state = JsonFunc.Delete("DeleteType", ((Models.Type)gridType.CurrentRow.DataBoundItem).IdType.ToString() + "/" + CurrentUser.current.Login);
                if (state == "-1")
                {
                    MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
                }

                Load_data();
            }
        }
        private void Load_data()
        {
            data = JsonConvert.DeserializeObject<List<Models.Type>>(JsonFunc.ReturnList("Types"));
            gridType.DataSource = new BindingSource(data, null);
            if (gridType.Rows.Count == 0)
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
