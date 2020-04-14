using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class MainMenu : IMainMenu
    {
        string nameOfAddressBook;
        public  void create(IDBConnection dbConn)
        {
            Console.WriteLine("Please enter a name of Address Book");
            nameOfAddressBook = Console.ReadLine();
            dbConn.write(nameOfAddressBook);
            Console.WriteLine("created");
        }
        public void open()
        {
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
