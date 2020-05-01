using System;
using System.Collections;
using System.Collections.Generic;
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
        public int mobileNumber { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public bool loadPersonByName(string personName)
        {
            return false;
        }
        public bool loadPersonById(int personId)
        {
            return false;
        }
        public ArrayList loadAllPersons()
        {
            return personsList;
        }
        public bool isPersonExist(string person)
        {
            if (personsList.Contains(person))
            {
                return true;
            }
            else
                return false;
        }
    }
}
