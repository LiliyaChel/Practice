using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace kidstrUser.Functions
{
    public static class TableFunc
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
        {
            DataTable dt = new DataTable();
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();
            object temp;
            DataRow dr;

            for (int i = 0; i < pia.Length; i++)
            {
                if (!(pia[i].PropertyType.IsGenericType && pia[i].PropertyType.IsGenericTypeDefinition))
                {
                    dt.Columns.Add(pia[i].Name, Nullable.GetUnderlyingType(pia[i].PropertyType) ?? pia[i].PropertyType);
                    dt.Columns[i].AllowDBNull = true;
                }
            }
            foreach (T item in collection)
            {
                dr = dt.NewRow();
                dr.BeginEdit();

                for (int i = 0; i < pia.Length; i++)
                {
                    if (!(pia[i].PropertyType.IsGenericType && pia[i].PropertyType.IsGenericTypeDefinition))
                    {
                        temp = pia[i].GetValue(item, null);
                        if (temp == null || (temp.GetType().Name == "Char" && ((char)temp).Equals('\0')))
                        {
                            dr[pia[i].Name] = DBNull.Value;
                        }
                        else
                        {
                            dr[pia[i].Name] = temp;
                        }
                    }

                }

                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public static DataGridView AddHeader(DataGridView table, List<string> names)
        {
            for (int i = 0; i < table.ColumnCount; i++)
            {
                try
                {
                    table.Columns[i].HeaderText = names[i];
                }
                catch
                {
                    table.Columns[i].HeaderText = "";
                }
            }
            return table;
        }
    }
}
