using System;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class AddressBook
    {
        public bool isDataAvailable;
        public int AddressBook_ID { get; set; }
        public string AddressBook_Name { get; set; }
        //SqlDataReader oReader;
        ArrayList bookslist;
        public AddressBook()
        {
            bookslist = new ArrayList();
            loadAllAddressBooks();
        }
        public bool loadAddressBookByName(string pBookName)
        {
                if (bookslist.Contains(pBookName))
                {
                    AddressBook_Name = pBookName;
                    isDataAvailable = true;
                    return isDataAvailable;
                }
                else
                {
                    isDataAvailable = false;
                    return isDataAvailable;
                }
        }

        public bool DisplayAddressBooks()
        {
            if (bookslist.Count>0)
            {
                Console.WriteLine("ID   Book name");
                // ICollection keys = bookslist.Keys;
                ArrayList arrayList = loadAllAddressBooks();
                int i = 1;
                foreach (var element in arrayList)
                {
                    // Console.WriteLine(element.Key + "   "+ element.Value);
                    Console.WriteLine(i++ +"    "+element);
                }
                isDataAvailable = true;
                return isDataAvailable;
            }
            else
            {
                isDataAvailable = false;
                return isDataAvailable;
            }
        }

        public  void addAddressBook(string pBookName)
        {
            try
            {
                isDataAvailable = loadAddressBookByName(pBookName);
                if(isDataAvailable)
                    Console.WriteLine("Already exists. please enter a new address book.");
                else
                {
                    DBConnection.openDbConnection();
                    DBConnection.CMD = new SqlCommand("insert into AddressBooks values('" + pBookName + "')", DBConnection.CONNECTION);
                    DBConnection.CMD.ExecuteNonQuery();
                    Console.WriteLine("New Address book added");
                }
            }
            finally
            {
                if (DBConnection.CONNECTION != null)
                    DBConnection.closeDbConnection();
                DBConnection.CMD.Dispose();
               // loadAllAddressBooks();
            }
        }

        public ArrayList loadAllAddressBooks()
        {
            try
            {
                DBConnection.openDbConnection();
                DBConnection.CMD = new SqlCommand("select * from AddressBooks", DBConnection.CONNECTION);
                SqlDataReader oReader = DBConnection.CMD.ExecuteReader();
                //bookslist.Clear();

                bookslist = new ArrayList();
                while (oReader.Read())
                {
                    bookslist.Add(oReader["name"].ToString());
                }    
                oReader.Close();
                return bookslist;
            }
            finally
            {
                if (DBConnection.CONNECTION != null)
                    DBConnection.closeDbConnection();
                DBConnection.CMD.Dispose();
            }
        }

        private ArrayList loadAllAddressBooks2()
        {
            DBConnection.openDbConnection();
            bookslist = new ArrayList();
            using (SqlCommand cmd = new SqlCommand("select * from AddressBooks", DBConnection.CONNECTION))
            {
                SqlDataReader oReader = cmd.ExecuteReader();
                while (oReader.Read())
                {
                    bookslist.Add(oReader["name"].ToString());
                }
            }
            DBConnection.closeDbConnection();
            return bookslist;
        }
    }
}
