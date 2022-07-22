using CafeteriaManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DAO
{
    public static class AccountDAO
    {
        public static bool AuthenticationLogin(string userName, string password)
        {
            string query = "CALL spLogin_Authentication( @userName , @passWord )";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, password });

            return result.Rows.Count > 0;
        }

        public static bool AuthenticationUpdateAccountInfo(string userName,
            string displayName,
            string password,
            string newPassword)
        {
            string query = "CALL spAccount_Update( @userName , @displayName , @password , @newPassword )";
            int output = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName, displayName, password, newPassword });

            return output > 0;
        }

        public static AccountModel GetAccountByUserName(string userName)
        {
            string query = $"CALL spAccount_GetByUserName( @userName )";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });

            foreach (DataRow row in data.Rows)
            {
                return new AccountModel(row);
            }

            return null;
        }

        public static DataTable GetAccountList()
        {
            string query = "CALL spAccount_GetAll()";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
