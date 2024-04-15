using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kidstrUser.Forms
{
    public partial class Status : Form
    {
        private Ordr dataO;
        private string state;
        private List<Models.Status> dataSt;

        public Status(Ordr ordr, List<Models.Status> statuses)
        {
            InitializeComponent();
            dataO = ordr;
            dataSt = statuses;
            Text += ordr.IdOrdr;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            dataO.IdStat = (int)stat.SelectedValue;
            state = JsonFunc.Request("UpdateOrdr", "PUT", JsonConvert.SerializeObject(dataO));
            if (state == "-2" || state == "-1")
            {
                MessageBox.Show("Ошибка доступа к данным. Пожалуйста, обратитесь к администратору.");
            }
            Close();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            stat.DataSource = dataSt;
            stat.DisplayMember = "Name";
            stat.ValueMember = "IdStat";
        }
    }
}
