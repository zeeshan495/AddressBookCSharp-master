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
            MainMenu book = new MainMenu();
            book.DisplayMainMenu();
            Console.ReadKey();
        }
    }
}
