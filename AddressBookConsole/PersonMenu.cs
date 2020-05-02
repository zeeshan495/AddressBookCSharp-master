using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class PersonMenu 
    {
        Person person;
        public PersonMenu()
        {
            person = new Person();
        }
       public void addPerson(int laddressBookId)
        {
            bool isPersonExist;
            Console.WriteLine("Please enter a First name");
            person.firstName = Console.ReadLine();
            Console.WriteLine("Please enter a Last name");
            person.lastName = Console.ReadLine();       
            isPersonExist   =   person.isPersonExist();
            if (isPersonExist)
                Console.WriteLine("Person Already exist");
            else
            {
                Console.WriteLine("Please enter a Mobile Number");
                person.mobileNumber = Convert.ToInt64(Console.ReadLine());
                person.savePerson();
                Console.WriteLine("Successfully added a new person");
            }
        }
        public void edit()
        {
            Console.WriteLine("working in progress");
        }
        public void editPerson()
        {
            Console.WriteLine("working in progress");
        }
        public void displayPersons()
        {
            ArrayList personList = person.loadAllPersons();
            if (personList.Count > 0)
            {
                Console.WriteLine("Id     FirstName       LastName        Mobile");
                foreach (Person lperson in personList)
                {
                    Console.WriteLine(" " + lperson.personId++ + "         " + lperson.firstName + "       " + lperson.lastName + "        " + lperson.mobileNumber);
                }
            }
            else
                Console.WriteLine("Address Book is empty");
        }
        public void removePerson()
        {
            Int32 lPersonID;
            bool lPersonExist;
            Console.WriteLine("Please enter a ID of person");
            lPersonID = Convert.ToInt32(Console.ReadLine());
            lPersonExist = person.isPersonExistByID(lPersonID);
            if (!lPersonExist)
                Console.WriteLine("Person is not available");
            else
                person.deletePerson(lPersonID);
        }
        public bool goBack()
        {
            Console.WriteLine("Back to menu");
            return false;
        }
    }
}
