using CafeteriaManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DAO
{
    public static class TableDAO
    {
        public static int TableWidth = 90;
        public static int TableHeight = 90;

        public static void SwitchTable(int from, int to)
        {
            string query = "CALL spSwitchTable( @idTable1 , @idTable2 )";
            DataProvider.Instance.ExecuteQuery(query, new object[] { from, to });
        }

        public static List<TableModel> GetTableList()
        {
            List<TableModel> output = new List<TableModel>();

            string query = "CALL spTable_GetAll()";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                TableModel t = new TableModel(row);

                output.Add(t);
            }

            return output;
        }

        public static bool InsertTable(string name)
        {
            string query = "CALL spTable_Insert( @name )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name });

            return result > 0;
        }

        public static bool UpdateTable(string name, string status, int id)
        {
            string query = $"UPDATE TableFood SET name = '{ name }', status = '{ status }' WHERE id = { id }";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public static bool DeleteTable(int id)
        {
            string query = $"DELETE FROM TableFood WHERE id = { id }";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
