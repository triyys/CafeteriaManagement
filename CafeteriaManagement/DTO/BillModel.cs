using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DTO
{
    public class BillModel
    {
        public int Id { get; set; }
        public DateTime? DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public int Status { get; set; }
        public int Discount { get; set; }

        public BillModel(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status, int discount = 0)
        {
            Id = id;
            DateCheckIn = dateCheckIn;
            DateCheckOut = dateCheckOut;
            Status = status;
            Discount = discount;
        }

        public BillModel(DataRow row)
        {
            Id = (int)row["id"];
            DateCheckIn = (DateTime?)row["DateCheckIn"];
            if (row["DateCheckOut"].ToString() != "")
            {
                DateCheckOut = (DateTime?)row["DateCheckOut"]; 
            }
            Status = (int)row["status"];
            Discount = (int)row["discount"];
        }
    }
}
