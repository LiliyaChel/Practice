using kidstrUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Ex = Microsoft.Office.Interop.Excel;

namespace kidstrUser.Forms
{
    public partial class Reports : Form
    {
        private Form parent;
        private bool backcommand;
        private DateTime bgn = new DateTime(0001, 1, 1);
        private DateTime nd = new DateTime(9999, 12, 31);
        private List<Age> ages;
        private List<Ordr> ordrs;
        private List<AgeList> a;
        private List<OrdrList> o;

        private class AgeList
        {
            public string Ages { get; set; }
            public int Count { get; set; }
        }

        private class OrdrList
        {
            public string Date { get; set; }
            public int Count { get; set; }
        }

        public Reports(Form p)
        {
            parent = p;
            backcommand = false;
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void Reports_FormClosed(object sender, FormClosedEventArgs e)
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

        private void excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "xlsx";
            dialog.Filter = "Книга Excel (*.xlsx) | *.xlsx";
            dialog.AddExtension = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Ex.Application excelobj = new Ex.Application();
                excelobj.DisplayAlerts = false;
                excelobj.SheetsInNewWorkbook = 2;
                Ex.Workbook book = excelobj.Workbooks.Add();

                Ex.Worksheet exAges = (Ex.Worksheet)book.Worksheets.get_Item(1);
                exAges.Name = "KidStr - Возраста";
                exAges.Cells[1, 1] = "Возрастные категории";
                exAges.Cells[1, 2] = "Количество";

                exAges.Cells[1, 5] = "Начало:";
                exAges.Cells[1, 6] = begin.MaskCompleted ? begin.Text : "-";
                exAges.Cells[1, 7] = "Конец:";
                exAges.Cells[1, 8] = end.MaskCompleted ? end.Text : "-";

                for (int i = 0; i < a.Count; i++)
                {
                    exAges.Cells[i + 2, 1] = a[i].Ages;
                    exAges.Cells[i + 2, 2] = a[i].Count;
                }

                int k = a.Count + 1;
                Ex.Range excelcells = exAges.get_Range("A1", "B" + k);
                excelcells.Borders.LineStyle = Ex.XlLineStyle.xlContinuous;
                exAges.Columns.AutoFit();
                Ex.ChartObjects xlCharts = (Ex.ChartObjects)exAges.ChartObjects();
                Ex.ChartObject myChart = xlCharts.Add(200, 50, 300, 250);
                Ex.Chart chartPage = myChart.Chart;
                chartPage.SetSourceData(excelcells);
                chartPage.ChartType = Ex.XlChartType.xlPie;
                chartPage.HasTitle = false;


                Ex.Worksheet exOrdrs = (Ex.Worksheet)book.Worksheets.get_Item(2);
                exOrdrs.Name = "KidStr - Заказы";
                exOrdrs.Cells[1, 1] = "Месяца";
                exOrdrs.Cells[1, 2] = "Количество";

                exOrdrs.Cells[1, 5] = "Начало:";
                exOrdrs.Cells[1, 6] = begin.MaskCompleted ? begin.Text : "-";
                exOrdrs.Cells[1, 7] = "Конец:";
                exOrdrs.Cells[1, 8] = end.MaskCompleted ? end.Text : "-";

                for (int i = 0; i < o.Count; i++)
                {
                    exOrdrs.Cells[i + 2, 1] = o[i].Date;
                    exOrdrs.Cells[i + 2, 2] = o[i].Count;
                }
                k = o.Count + 1;
                excelcells = exOrdrs.get_Range("A1", "B" + k);
                excelcells.Borders.LineStyle = Ex.XlLineStyle.xlContinuous;
                exOrdrs.Columns.AutoFit();
                xlCharts = (Ex.ChartObjects)exOrdrs.ChartObjects();
                myChart = xlCharts.Add(200, 50, 300, 250);
                chartPage = myChart.Chart;
                chartPage.SetSourceData(excelcells);
                chartPage.ChartType = Ex.XlChartType.xlColumnStacked;
                chartPage.HasTitle = false;
                chartPage.HasLegend = false;


                book.SaveAs(dialog.FileName);
                book.Close();
                excelobj.Quit();
            }
        }

        private void report_Click(object sender, EventArgs e)
        {
            if (begin.MaskCompleted)
            {
                bgn = DateTime.ParseExact(begin.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                bgn = ordrs.Select(x => x.DateTime).Min();
            }
            if (end.MaskCompleted)
            {
                nd = DateTime.ParseExact(end.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                nd = ordrs.Select(x => x.DateTime).Max();
            }
            Load_data();
        }
        private void Load_data()
        {
            ages = JsonConvert.DeserializeObject<List<Age>>(JsonFunc.ReturnList("Ages"));
            ordrs = JsonConvert.DeserializeObject<List<Ordr>>(JsonFunc.ReturnList("Ordrs"));
            if (ordrs.Count == 0)
            {
                MessageBox.Show("Данные для отчетов отсутствуют.");
                Close();
            }
            foreach (Ordr ordr in ordrs)
            {
                ordr.Age = ages.First(x => x.IdGroup == ordr.IdGroup);
            }

            if (bgn > nd)
            {
                MessageBox.Show("Недопустимый временной промежуток.");
                return;
            }

            a = ordrs.Where(x => x.DateTime >= bgn && x.DateTime <= nd).OrderBy(x => x.IdGroup).GroupBy(x => x.AgeName).Select(y => new AgeList { Ages = y.Key, Count = y.Count() }).ToList();
            o = ordrs.Where(x => x.DateTime >= bgn && x.DateTime <= nd).OrderBy(x => x.DateTime).GroupBy(x => x.DateTime.ToString("MMM yyyy")).Select(y => new OrdrList { Date = y.Key, Count = y.Count() }).ToList();

            diagAges.DataSource = new BindingSource(a, null);
            diagAges.Series[0].XValueMember = "Ages";
            diagAges.Series[0].YValueMembers = "Count";
            diagAges.DataBind();

            diagOrdrs.DataSource = new BindingSource(o, null);
            diagOrdrs.Series[0].XValueMember = "Date";
            diagOrdrs.Series[0].YValueMembers = "Count";
            diagOrdrs.Series[0].IsVisibleInLegend = false;
            diagOrdrs.DataBind();
        }
    }
}
