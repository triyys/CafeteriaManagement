using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DTO
{
    public class MenuModel
    {
        public string FoodName { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }

        public MenuModel(string foodName, int count, float price, float totalPrice = 0)
        {
            FoodName = foodName;
            Count = count;
            Price = price;
            TotalPrice = totalPrice;
        }

        public MenuModel(DataRow row)
        {
            FoodName = row["name"].ToString();
            Count = (int)row["Count"];
            Price = (float)Convert.ToDouble(row["price"].ToString());
            TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
    }
}
