using CafeteriaManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DAO
{
    public static class FoodDAO
    {
        public static List<FoodModel> GetFoodsByFoodCategoryId(int id)
        {
            List<FoodModel> output = new List<FoodModel>();

            string query = "CALL spFoods_GetByFoodCategory( @id )";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });

            foreach (DataRow row in data.Rows)
            {
                FoodModel fc = new FoodModel(row);

                output.Add(fc);
            }

            return output;
        }

        public static List<FoodModel> GetFoodList()
        {
            List<FoodModel> output = new List<FoodModel>();

            string query = "CALL spFood_GetAll()";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                FoodModel fc = new FoodModel(row);

                output.Add(fc);
            }

            return output;
        }

        public static List<FoodModel> SearchFoodsByName(string name)
        {
            List<FoodModel> output = new List<FoodModel>();

            string query = $"SELECT * FROM Food WHERE name LIKE '%{ name }%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                FoodModel fc = new FoodModel(row);

                output.Add(fc);
            }

            return output;
        }

        public static bool InsertFood(string name, int categoryId, float price)
        {
            string query = "CALL spFood_Insert( @name , @idCategory , @price )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, categoryId, price });

            return result > 0;
        }

        public static bool UpdateFood(string name, int categoryId, float price, int id)
        {
            string query = $"UPDATE Food SET name = '{ name }', idCategory = { categoryId }, price = { price } WHERE id = { id }";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public static bool DeleteFood(int id)
        {
            string query = $"DELETE FROM Food WHERE id = { id }";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
