using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AddressBookConsole
{
    class DBConnection : IDBConnection
    {
        SqlConnection conn;
        SqlCommand cmd;
        public DBConnection()
        {
            conn = new SqlConnection(@"Data Source=localhost;Initial Catalog = test; User ID = CORPORATE\s828704; Password = zeesh@n9741");
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
            cmd = new SqlCommand("insert into AddressBook values('" + query +"')", conn);
            cmd.BeginExecuteNonQuery();
            Console.WriteLine("DB write");
        }
        public void close()
        {
            conn.Close();
            Console.WriteLine("DB close");
        }
    }
}
