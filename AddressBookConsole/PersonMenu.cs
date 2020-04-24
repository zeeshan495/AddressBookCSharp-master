using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class PersonMenu 
    {
       public void add()
        {
            Console.WriteLine("add");
        }
        public void edit()
        {
            Console.WriteLine("edit");
        }
        public void delete()
        {
            Console.WriteLine("delete");
        }
        public void display()
        {
            Console.WriteLine("display");
        }
        public bool goBack()
        {
            Console.WriteLine("Back to menu");
            return false;
        }
    }
}
