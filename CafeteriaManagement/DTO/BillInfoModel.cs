using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DTO
{
    public class BillInfoModel
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int FoodId { get; set; }
        public int Count { get; set; }

        public BillInfoModel(int id, int billId, int foodId, int count)
        {
            Id = id;
            BillId = billId;
            FoodId = foodId;
            Count = count;
        }

        public BillInfoModel(DataRow row)
        {
            Id = (int)row["id"];
            BillId = (int)row["idBill"];
            FoodId = (int)row["idFood"];
            Count = (int)row["Count"];
        }
    }
}
