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
        public Int32 personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Int64 mobileNumber { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public static int ADDRESSBOOKID { get; set; }
        public Person()
        {
            personsList = new ArrayList();
        }
        public bool loadPersonByName(string personName)
        {
            return false;
        }
        public void loadPersonById(Int32 lpersonId)
        {
            DBConnection.openDbConnection();
            DBConnection.CMD = new SqlCommand("select * from persons where AddressBook_ID = '" + ADDRESSBOOKID + "' and Persons_ID = '" + lpersonId + "'", DBConnection.CONNECTION);
            SqlDataReader oReader = DBConnection.CMD.ExecuteReader();
            while (oReader.Read())
            {
                personId = Convert.ToInt32(oReader["Persons_ID"]);
                firstName = oReader["FirstName"].ToString().ToLower();
                lastName = oReader["LastName"].ToString().ToLower();
                mobileNumber = Convert.ToInt64(oReader["mobile"]);
                ADDRESSBOOKID = Convert.ToInt32(oReader["AddressBook_ID"]);
            }
            oReader.Close();
            DBConnection.closeDbConnection();
        }
        public ArrayList loadAllPersons()
        {
            DBConnection.openDbConnection();
            DBConnection.CMD = new SqlCommand("select * from persons where AddressBook_ID = '"+ ADDRESSBOOKID + "'", DBConnection.CONNECTION);
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
        public bool isPersonExistByID(Int32 pPersonId)
        {
            DBConnection.openDbConnection();
            DBConnection.CMD = new SqlCommand("select * from persons where AddressBook_ID = '" + ADDRESSBOOKID + "' and Persons_ID = '" + pPersonId + "'", DBConnection.CONNECTION);
            SqlDataReader oReader = DBConnection.CMD.ExecuteReader();
            if (oReader.HasRows)
            {
                oReader.Close();
                DBConnection.closeDbConnection();
                return true;
            }
            else
            {
                oReader.Close();
                DBConnection.closeDbConnection();
                return false;
            }
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
            DBConnection.CMD = new SqlCommand("insert into persons values('"+firstName+"', '"+lastName+"', "+mobileNumber+","+ ADDRESSBOOKID + ")", DBConnection.CONNECTION);
            DBConnection.CMD.ExecuteNonQuery();
            DBConnection.closeDbConnection();
            personsList = loadAllPersons();
        }
        public void deletePerson(Int32 lpersonId)
        {
            DBConnection.openDbConnection();
            DBConnection.CMD = new SqlCommand("delete persons where AddressBook_ID = '" + ADDRESSBOOKID + "' and Persons_ID = '" + lpersonId + "'", DBConnection.CONNECTION);
            DBConnection.CMD.ExecuteNonQuery();
            DBConnection.closeDbConnection();
            personsList = loadAllPersons();
        }
    }
}
