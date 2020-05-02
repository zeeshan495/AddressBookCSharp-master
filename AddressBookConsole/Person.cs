using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class Person
    {
        ArrayList personsList;
        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Int64 mobileNumber { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int AddressBookID { get; set; }
        public Person()
        {
            personsList = new ArrayList();
        }
        public bool loadPersonByName(string personName)
        {
            return false;
        }
        public bool loadPersonById(int personId)
        {
            return false;
        }
        public ArrayList loadAllPersons(int lAddressBookID)
        {
            DBConnection.openDbConnection();
            DBConnection.CMD = new SqlCommand("select * from persons where AddressBook_ID = '"+ lAddressBookID + "'", DBConnection.CONNECTION);
            SqlDataReader oReader = DBConnection.CMD.ExecuteReader();
            personsList.Clear();
            while (oReader.Read())
            {
                Person lPerson = new Person();
                lPerson.personId        =   Convert.ToInt32(oReader["Persons_ID"]);
                lPerson.firstName       =   oReader["FirstName"].ToString().ToLower();
                lPerson.lastName        =   oReader["LastName"].ToString().ToLower();
                lPerson.mobileNumber    =   Convert.ToInt64(oReader["mobile"]);
                personsList.Add(lPerson);
            }
            oReader.Close();
            DBConnection.closeDbConnection();
            return personsList;
        }
        public bool isPersonExist()
        {
            foreach (Person lperson in personsList)
            {
                if ((lperson.firstName + lperson.lastName).Equals(firstName + lastName))
                    return true;
            }
            return false;
        }
        public void savePerson()
        {
            DBConnection.openDbConnection();
            DBConnection.CMD = new SqlCommand("insert into persons values('"+firstName+"', '"+lastName+"', "+mobileNumber+","+AddressBookID+")", DBConnection.CONNECTION);
            DBConnection.CMD.ExecuteNonQuery();
            DBConnection.closeDbConnection();
            personsList = loadAllPersons(AddressBookID);
        }
    }
}
