using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DTO
{
    public class FoodCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FoodCategoryModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public FoodCategoryModel(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
        }
    }
}
