using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class AddressBookMenu
    {
       // IDBConnection dbConn;
        string nameOfAddressBook;
        AddressBook addressBook;
        public AddressBookMenu()
        {
            //this.dbConn = dbConn;
            addressBook = new AddressBook();
        }
        public  void createAddressBook()
        {
            Console.WriteLine("Please enter a name of Address Book");
            nameOfAddressBook = Console.ReadLine();
            addressBook.addAddressBook(nameOfAddressBook);
        }
        public bool selectAddressBook()
        {
            bool isAddressBookAvailable = false;
            Console.WriteLine("Please enter a name of Address Book");
            nameOfAddressBook = Console.ReadLine();
            isAddressBookAvailable = addressBook.loadAddressBookByName(nameOfAddressBook.ToLower());
            if(isAddressBookAvailable)
            {
                Console.WriteLine("AddressBook is available. Go for further operations");
                return isAddressBookAvailable;
            }
            else
            {
                Console.WriteLine("AddressBook is not available");
                return isAddressBookAvailable;
            }       
        }
        public void renameAddressbook()
        {
            Console.WriteLine("Please enter a new name of Address book");
            string newBookName = Console.ReadLine();
            if (addressBook.isAddressBookAvailable(newBookName.ToLower()))
                Console.WriteLine("Name already exists");
            else
            {
                try
                {
                    DBConnection.openDbConnection();
                    DBConnection.CMD = new SqlCommand("update AddressBooks set name = '" + newBookName +"' where id = "+addressBook.AddressBook_ID, DBConnection.CONNECTION);
                    DBConnection.CMD.ExecuteNonQuery();
                    Console.WriteLine("Successfully name changed");
                }
                finally
                {
                    if (DBConnection.CONNECTION != null)
                        DBConnection.closeDbConnection();
                    DBConnection.CMD.Dispose();
                }
            }
        }
        public bool deleteAddressBook()
        {
            DBConnection.openDbConnection();
            DBConnection.CMD = new SqlCommand("delete AddressBooks where name = '" + addressBook.AddressBook_Name + "'", DBConnection.CONNECTION);
            DBConnection.CMD.ExecuteNonQuery();
            Console.WriteLine("Successfully deleted");
            DBConnection.closeDbConnection();
            return false;
        }
        public void display()
        {
            Console.WriteLine("display");
        }
        public bool closeAddressBook()
        {
            Console.WriteLine("close Address book");
            return false;
        }  
    }
}
