using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DTO
{
    public class FoodModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public float Price { get; set; }

        public FoodModel(int id, string name, int categoryId, float price)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Price = price;
        }

        public FoodModel(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            CategoryId = (int)row["idCategory"];
            Price = (float)Convert.ToDouble(row["price"].ToString());
        }
    }
}
