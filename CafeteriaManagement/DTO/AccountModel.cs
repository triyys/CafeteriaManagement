using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DTO
{
    public class AccountModel
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }

        public AccountModel(string userName, string displayName, int type, string password = null)
        {
            UserName = userName;
            DisplayName = displayName;
            Type = type;
            Password = password;
        }

        public AccountModel(DataRow row)
        {
            UserName = row["UserName"].ToString();
            DisplayName = row["DisplayName"].ToString();
            Type = (int)row["Type"];
            Password = row["PassWord"].ToString();
        }
    }
}
