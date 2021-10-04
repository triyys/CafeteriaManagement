using CafeteriaManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DAO
{
    public static class MenuDAO
    {
        public static List<MenuModel> GetMenusByTableId(int id)
        {
            List<MenuModel> output = new List<MenuModel>();

            string query = $"SELECT f.name, fullBill.Count, f.price, f.price * fullBill.Count totalPrice FROM(SELECT bi.idFood, bi.Count, b.idTable TableID, b.status FROM BillInfo bi INNER JOIN Bill b ON bi.idBill = b.id) fullBill INNER JOIN Food f ON fullBill.idFood = f.id WHERE fullBill.TableID = { id } AND fullBill.status = 0";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                MenuModel m = new MenuModel(row);

                output.Add(m);
            }

            return output;
        }
    }
}
