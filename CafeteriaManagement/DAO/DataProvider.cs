using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaManagement.DAO
{
    public class DataProvider
    {
        private const string serverName = "localhost";
        private const string userName = "root";
        private const string databaseName = "cafeteria_management";
        private const string passWord = "b2stb2utybiasyys2811";
        private static string cnnString;

        private string CnnString
        {
            get
            {
                cnnString = $"server={ serverName };user id={ userName };database={ databaseName };password={ passWord }";
                return cnnString;
            }
        }

        /// <summary>
        /// Singleton Design Pattern
        /// </summary>
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }

                return instance;
            }
            private set => instance = value;
        }

        public DataTable ExecuteQuery(string query, object[] input = null)
        {
            DataTable data = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(CnnString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (input != null)
                    {
                        string[] ps = query.Split(' ');
                        int i = 0;
                        foreach (string p in ps)
                        {
                            if (p.Contains("@"))
                            {
                                command.Parameters.AddWithValue(p, input[i]);
                                ++i;
                            }
                        }
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(data);  
                    }
                }

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] input = null)
        {
            int data = 0;

            using (MySqlConnection connection = new MySqlConnection(CnnString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (input != null)
                    {
                        string[] ps = query.Split(' ');
                        int i = 0;
                        foreach (string p in ps)
                        {
                            if (p.Contains("@"))
                            {
                                command.Parameters.AddWithValue(p, input[i]);
                                ++i;
                            }
                        }
                    }

                    data = command.ExecuteNonQuery();
                }

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] input = null)
        {
            object data = 0;

            using (MySqlConnection connection = new MySqlConnection(CnnString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (input != null)
                    {
                        string[] ps = query.Split(' ');
                        int i = 0;
                        foreach (string p in ps)
                        {
                            if (p.Contains("@"))
                            {
                                command.Parameters.AddWithValue(p, input[i]);
                                ++i;
                            }
                        }
                    }

                    data = command.ExecuteScalar();
                }

                connection.Close();
            }

            return data;
        }
    }
}
