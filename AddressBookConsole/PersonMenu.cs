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
            Console.WriteLine("Please enter a Mobile Number");
            person.mobileNumber = Convert.ToInt64(Console.ReadLine());
            person.AddressBookID = laddressBookId;
            isPersonExist   =   person.isPersonExist();
            if (isPersonExist)
                Console.WriteLine("Person Already exist");
            else
            {
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
        public void displayPersons(int pAddressBookId)
        {
            ArrayList personList = person.loadAllPersons(pAddressBookId);
            if (personList.Count > 0)
            {
                int i = 1;
                Console.WriteLine("S.No     FirstName       LastName        Mobile");
                foreach (Person lperson in personList)
                {
                    Console.WriteLine(" " + i++ + "         " + lperson.firstName + "       " + lperson.lastName + "        " + lperson.mobileNumber);
                }
            }
            else
                Console.WriteLine("Address Book is empty");
        }
        public bool goBack()
        {
            Console.WriteLine("Back to menu");
            return false;
        }
    }
}
