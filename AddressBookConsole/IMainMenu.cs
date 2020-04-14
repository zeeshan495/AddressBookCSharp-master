using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
     interface IMainMenu
    {
        void create(IDBConnection dbConn);
        void open();
        void display();
        void save();
        void saveAs();
        bool close();
    }
}
