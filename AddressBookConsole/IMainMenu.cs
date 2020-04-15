using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
     interface IMainMenu
    {
        void create();
        void openAddressBook();
        void display();
        void save();
        void saveAs();
        bool close();
    }
}
