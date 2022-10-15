using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Ekisa.Api.BotFetal.Services.Common
{
    public class DataTableBase
    {

        #region Convertir DataTable a List usando un método genérico

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }



        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            string nombreColumna = "";
            try
            {

                foreach (DataColumn column in dr.Table.Columns)
                {
                    nombreColumna = column.ColumnName;

                    foreach (PropertyInfo pro in temp.GetProperties())
                    {


                        object value = dr[column.ColumnName];
                        if (value == DBNull.Value) value = null;

                        if (pro.Name == column.ColumnName)
                            pro.SetValue(obj, value, null);
                        else
                            continue;
                    }
                }
                return obj;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en la columna {nombreColumna} {e}");
                return obj;
            }

        }

        #endregion


    }
}
