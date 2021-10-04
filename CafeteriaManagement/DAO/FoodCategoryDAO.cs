using CafeteriaManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DAO
{
    public static class FoodCategoryDAO
    {
        public static List<FoodCategoryModel> GetCategoryList()
        {
            List<FoodCategoryModel> output = new List<FoodCategoryModel>();

            string query = "CALL spFoodCategory_GetAll()";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                FoodCategoryModel fc = new FoodCategoryModel(row);

                output.Add(fc);
            }

            return output;
        }

        public static FoodCategoryModel GetCategoryById(int id)
        {
            FoodCategoryModel output = null;

            string query = $"SELECT * FROM FoodCategory WHERE id = { id }";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                output = new FoodCategoryModel(row);
                break;
            }

            return output;
        }

        public static bool InsertFoodCategory(string name)
        {
            string query = "CALL spFoodCategory_Insert( @name )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name });

            return result > 0;
        }

        public static bool UpdateFoodCategory(string name, int id)
        {
            string query = $"UPDATE FoodCategory SET name = '{ name }' WHERE id = { id }";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public static bool DeleteFoodCategory(int id)
        {
            string query = $"DELETE FROM FoodCategory WHERE id = { id }";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
