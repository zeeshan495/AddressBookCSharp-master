using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class MainMenu : IMainMenu
    {
        IDBConnection dbConn;
        string nameOfAddressBook;
        public MainMenu(IDBConnection dbConn)
        {
            this.dbConn = dbConn;
        }
        public  void create()
        {
            Console.WriteLine("Please enter a name of Address Book");
            nameOfAddressBook = Console.ReadLine();
            dbConn.write(nameOfAddressBook);
            Console.WriteLine("created");
        }
        public void openAddressBook()
        {
            Console.WriteLine("Please enter a name of Address Book");
            nameOfAddressBook = Console.ReadLine();
            dbConn.loadAddressBookByName(nameOfAddressBook);
            Console.WriteLine("open");
        }
        public void display()
        {
            Console.WriteLine("display");
        }
        public void save()
        {
            Console.WriteLine("save");
        }
        public void saveAs()
        {
            Console.WriteLine("saveAs");
        }
        public bool close()
        {
            Console.WriteLine("Thank You!");
            return false;
        }  
    }
}
