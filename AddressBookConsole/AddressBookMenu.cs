using System;
using System.Collections.Generic;
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
        public bool editAddressBook()
        {
            bool isAddressBookAvailable = false;
            Console.WriteLine("Please enter a name of Address Book");
            nameOfAddressBook = Console.ReadLine();
            isAddressBookAvailable = addressBook.loadAddressBookByName(nameOfAddressBook);
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
