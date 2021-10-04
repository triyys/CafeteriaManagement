using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DTO
{
    public class TableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public TableModel(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public TableModel(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Status = row["status"].ToString();
        }
    }
}
