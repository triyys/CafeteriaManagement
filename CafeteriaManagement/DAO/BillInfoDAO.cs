using CafeteriaManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DAO
{
    public static class BillInfoDAO
    {
        public static List<BillInfoModel> GetBillInfosByBillId(int id)
        {
            List<BillInfoModel> output = new List<BillInfoModel>();

            DataTable data = DataProvider.Instance.ExecuteQuery($"SELECT * FROM BillInfo WHERE idBill = { id }");

            foreach (DataRow row in data.Rows)
            {
                BillInfoModel bi = new BillInfoModel(row);
                output.Add(bi);
            }

            return output;
        }

        public static void InsertBillInfo(int billId, int foodId, int count)
        {
            string query = "CALL spBillInfo_Insert( @idBill , @idFood , @count )";

            DataProvider.Instance.ExecuteNonQuery(query, new object[] { billId, foodId, count });
        }
    }
}
