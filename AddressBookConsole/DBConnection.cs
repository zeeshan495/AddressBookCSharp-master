using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AddressBookConsole
{
    class DBConnection : IDBConnection
    {
        SqlConnection conn;
        SqlCommand cmd;
        public DBConnection()
        {
            conn = new SqlConnection(@"Server=S828404-W10; Initial Catalog = test; integrated security=SSPI; 
                                        persist security info=False; Trusted_Connection=Yes");
        }
        public void open()
        {
            conn.Open();
            Console.WriteLine("DB open");
        }
        public void read()
        {
            Console.WriteLine("DB read");
        }
        public void write(string query)
        {
            cmd = new SqlCommand("insert into AddressBooks values('" + query +"')", conn);
            cmd.BeginExecuteNonQuery();
            Console.WriteLine("DB write");
        }
        public void loadAddressBookByName(string query)
        {
            cmd = new SqlCommand("select * from AddressBooks where name =('" + query + "')", conn);
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Console.WriteLine(oReader["name"].ToString());
                }
            }
        }
        public void loadByID(string spName, string ID)
        {
            Console.WriteLine("Load By Id");
        }
        public SqlDataReader NewQuery(string lQuery)
        {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd = new SqlCommand("", conn);
            //       cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
            //       cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;

            cmd.ExecuteNonQuery();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            return sqlDataReader;


        }
        public void close()
        {
            conn.Close();
            Console.WriteLine("DB closed");
        }
    }
}
