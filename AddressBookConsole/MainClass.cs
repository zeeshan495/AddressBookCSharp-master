using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main");
            AddressBook book = new AddressBook();
            book.DisplayMainMenu();
            Console.ReadKey();
        }
    }
}
