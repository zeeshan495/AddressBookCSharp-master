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
        ArrayList bookslist;
        public int AddressBook_ID { get; set; }
        public string AddressBook_Name { get; set; }
        public AddressBook()
        {
            bookslist = new ArrayList();
            loadAllAddressBooks();
        }
        public bool loadAddressBookByName(string pBookName)
        {          
            if (isAddressBookAvailable(pBookName))
            {
                AddressBook_Name = pBookName;               
                DBConnection.openDbConnection();
                DBConnection.CMD = new SqlCommand("select * from AddressBooks where name = '"+ pBookName+"'", DBConnection.CONNECTION);
                SqlDataReader oReader = DBConnection.CMD.ExecuteReader();
                while (oReader.Read())
                {
                    AddressBook_Name = oReader["name"].ToString();
                    AddressBook_ID = Convert.ToInt32(oReader["id"]);
                }
                 DBConnection.closeDbConnection();
                 return true;   
            } 
            else
                return false;
        }

        public  void saveAddressBook(string pBookName)
        {
            bool isDataAvailable;
            isDataAvailable = loadAddressBookByName(pBookName);
            if(isDataAvailable)
                Console.WriteLine("Already exists. please enter a new address book.");
            else
            {
                DBConnection.openDbConnection();
                DBConnection.CMD = new SqlCommand("insert into AddressBooks values('" + pBookName + "')", DBConnection.CONNECTION);
                DBConnection.CMD.ExecuteNonQuery();
                DBConnection.closeDbConnection();
                Console.WriteLine("New Address book added");
            }
        }

        public ArrayList loadAllAddressBooks()
        {
            DBConnection.openDbConnection();
            DBConnection.CMD = new SqlCommand("select * from AddressBooks", DBConnection.CONNECTION);
            SqlDataReader oReader = DBConnection.CMD.ExecuteReader();
            bookslist = new ArrayList();
            while (oReader.Read())
            {
                bookslist.Add(oReader["name"].ToString().ToLower());
            }    
            oReader.Close();
            DBConnection.closeDbConnection();
            return bookslist;
        }

        public bool isAddressBookAvailable(string pBookName)
        {
            if (bookslist.Contains(pBookName))
            {
                return true;
            }
            else
                return false;
        }

    }
}
