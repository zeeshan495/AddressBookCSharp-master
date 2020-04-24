using System;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class AddressBook
    {
        public bool isDataAvailable;
        public int AddressBook_ID { get; set; }
        public string AddressBook_Name { get; set; }
        SqlDataReader oReader;
        Hashtable bookslist = new Hashtable();
        public AddressBook()
        {
            loadAllAddressBooks();
        }
        public bool loadAddressBookByName(string pBookName)
        {
                if (bookslist.ContainsValue(pBookName))
                {
                    AddressBook_Name = pBookName;
                    isDataAvailable = true;
                    return isDataAvailable;
                }
                else
                {
                    isDataAvailable = false;
                    return isDataAvailable;
                }
        }

        public bool DisplayAddressBooks()
        {
            if (bookslist.Count>0)
            {
                Console.WriteLine("ID   Book name");
                foreach (string i in bookslist)
                {
                    Console.Write(i + " ");
                }
                isDataAvailable = true;
                return isDataAvailable;
            }
            else
            {
                isDataAvailable = false;
                return isDataAvailable;
            }
        }

        public  void addAddressBook(string pBookName)
        {
            try
            {
                isDataAvailable = loadAddressBookByName(pBookName);
                if(isDataAvailable)
                    Console.WriteLine("Already exists. please enter a new address book.");
                else
                {
                    DBConnection.openDbConnection();
                    DBConnection.CMD = new SqlCommand("insert into AddressBooks values('" + pBookName + "')", DBConnection.CONNECTION);
                    DBConnection.CMD.BeginExecuteNonQuery();
                    Console.WriteLine("New Address book added");
                }
            }
            finally
            {
                if (DBConnection.CONNECTION != null)
                    DBConnection.closeDbConnection();
            }
        }

        public void loadAllAddressBooks()
        {
            try
            {
                DBConnection.openDbConnection();
                DBConnection.CMD = new SqlCommand("select * from AddressBooks", DBConnection.CONNECTION);
                SqlDataReader oReader = DBConnection.CMD.ExecuteReader();
                while (oReader.Read())
                {
                    bookslist.Add(oReader["id"].ToString(), oReader["name"].ToString());
                }
            }
            finally
            {
                if (DBConnection.CONNECTION != null)
                    DBConnection.closeDbConnection();
            }
        }
    }
}
