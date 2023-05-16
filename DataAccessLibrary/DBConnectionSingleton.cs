using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DataAccessLibrary
{
    public class DBConnectionSingleton
    {
        private static DBConnectionSingleton instance = new DBConnectionSingleton();
        private static MySqlConnection? conn = null;
        private DBConnectionSingleton()
        {
        }
        public static MySqlConnection GetInstance()
        {
            try
            {
                if (conn == null)
                {
                    SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                    consStringBuilder.UserID = ReadSetting("Name");
                    consStringBuilder.Password = ReadSetting("Password");
                    consStringBuilder.InitialCatalog = ReadSetting("Database");
                    consStringBuilder.DataSource = ReadSetting("DataSource");
                    consStringBuilder.ConnectTimeout = 10;
                    conn = new MySqlConnection(consStringBuilder.ConnectionString);
                    conn.Open();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Wasn`t able to connect to database, try again later or call an administrator ERR: {0}", e.Message);
            }
            return conn;
        }
        private static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            Console.WriteLine(result);
            return result;
        }
    }

}

