using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    interface IDBConnection
    {
        void open();
        void read();
        void write(string query);
        void loadAddressBookByName(string query);
        void loadByID(string spName, string ID);
        void close();
    }
}
