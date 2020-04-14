using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    interface ISubMenu
    {
        void add();
        void edit();
        void delete();
        void display();
        bool goBack();
    }
}
