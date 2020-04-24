using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AddressBookConsole
{
    static class DBConnection
    {
        public static SqlConnection CONNECTION;
        public static SqlCommand CMD;
        static DBConnection()
        {
            
        }
        public static void openDbConnection()
        {
            CONNECTION = new SqlConnection(@"Server=S828404-W10; Initial Catalog = test; integrated security=SSPI; 
                                        persist security info=False; Trusted_Connection=Yes");
            CONNECTION.Open();
        }

        public static void loadByID(string spName, string ID)
        {
            Console.WriteLine("Load By Id");
        }
        public static SqlDataReader NewQuery(string lQuery)
        {
            CMD.CommandType = CommandType.StoredProcedure;
            CMD = new SqlCommand("", CONNECTION);

            CMD.ExecuteNonQuery();
            SqlDataReader sqlDataReader = CMD.ExecuteReader();
            return sqlDataReader;

        }
        public static void closeDbConnection()
        {
            CONNECTION.Close();
            //Console.WriteLine("DB closed");
        }
    }
}
