using CafeteriaManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DAO
{
    public static class BillDAO
    {
        /// <summary>
        /// Thành công: idBill
        /// Thất bại: -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetUncheckedBillIdByTableId(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"SELECT * FROM Bill WHERE idTable = { id } AND status = 0");

            if (data.Rows.Count > 0)
            {
                BillModel b = new BillModel(data.Rows[0]);
                return b.Id;
            }

            return -1;
        }

        public static void CheckOut(int id, int discount, float totalPrice)
        {
            string query = $"UPDATE Bill SET DateCheckOut = NOW(), status = 1, discount = { discount }, totalPrice = { totalPrice } WHERE id = { id }";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public static DataTable GetFullBillsByDateTime(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("CALL spBills_GetByDateTime( @checkIn , @checkOut )",
                new object[] { checkIn, checkOut });
        }

        public static void InsertBill(int id)
        {
            string query = "CALL spBill_Insert( @idTable )";

            DataProvider.Instance.ExecuteNonQuery(query, new object[]{ id });
        }

        public static int GetMaxIdBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM Bill;");
            }
            catch
            {
                return 1;
            }
        }
    }
}
