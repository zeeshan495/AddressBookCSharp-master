using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class AddressBookMenu
    {
        string nameOfAddressBook;
        AddressBook addressBook;
        ArrayList bookList;
        
        public AddressBookMenu()
        {
            addressBook = new AddressBook();
        }
        public  void createAddressBook()
        {
            Console.WriteLine("Please enter a name of Address Book");
            nameOfAddressBook = Console.ReadLine();
            addressBook.saveAddressBook(nameOfAddressBook);
        }
        public int selectAddressBook()
        {
            Console.WriteLine("Please enter a name of Address Book");
            nameOfAddressBook = Console.ReadLine();
            bool isAddressBookAvailable = false;
            isAddressBookAvailable = addressBook.loadAddressBookByName(nameOfAddressBook.ToLower());
            if(isAddressBookAvailable)
            {
                Console.WriteLine("AddressBook is available. Go for further operations");
                return addressBook.AddressBook_ID;
            }
            else
            {
                Console.WriteLine("AddressBook is not available");
                return addressBook.AddressBook_ID;
            }       
        }
        public bool DisplayAddressBooks()
        {
            bookList = addressBook.loadAllAddressBooks();
            if (bookList.Count > 0)
            {
                Console.WriteLine("S.No   Book name");
                
                int i = 1;
                foreach (var element in bookList)
                {
                    Console.WriteLine(i++ + "    " + element);
                }
                return true;
            }
            else
                return false;
        }
        public void renameAddressbook()
        {
            Console.WriteLine("Please enter a new name of Address book");
            string newBookName = Console.ReadLine();
            if (addressBook.isAddressBookAvailable(newBookName.ToLower()))
                Console.WriteLine("Name already exists");
            else
            {
                DBConnection.openDbConnection();
                DBConnection.CMD = new SqlCommand("update AddressBooks set name = '" + newBookName +"' where id = "+addressBook.AddressBook_ID, DBConnection.CONNECTION);
                DBConnection.CMD.ExecuteNonQuery();
                Console.WriteLine("Successfully name changed");
                DBConnection.closeDbConnection();
                bookList = addressBook.loadAllAddressBooks();
            }
        }
        public bool deleteAddressBook()
        {
            DBConnection.openDbConnection();
            DBConnection.CMD = new SqlCommand("delete AddressBooks where name = '" + addressBook.AddressBook_Name + "'", DBConnection.CONNECTION);
            DBConnection.CMD.ExecuteNonQuery();
            Console.WriteLine("Successfully deleted");
            DBConnection.closeDbConnection();
            bookList = addressBook.loadAllAddressBooks();
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
