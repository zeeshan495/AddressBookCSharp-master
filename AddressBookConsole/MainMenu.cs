using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class MainMenu
    {
        AddressBookMenu addressBookMenu;
        PersonMenu personMenu;
        AddressBook addressBook;
        Person person;
        public MainMenu()
        {
            personMenu = new PersonMenu();
            person = new Person();
            addressBookMenu = new AddressBookMenu();
            addressBook = new AddressBook();
        }
        public void DisplayMainMenu()
        {
            Console.WriteLine("Display main menu");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Please enter a choice");
                Console.WriteLine("select 1 to add new Address Book");
                Console.WriteLine("select 2 to select Address Book");
                Console.WriteLine("select 3 to display Address Books");
                Console.WriteLine("select 4 to close Application");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        addressBookMenu.createAddressBook();
                        break;
                    case "2":
                        if (!addressBook.DisplayAddressBooks())
                            Console.WriteLine("Address books are not available. Please add Address books.");
                        else
                        {
                            if (addressBookMenu.selectAddressBook())
                                DisplaySubMenu();
                        }
                        break;
                    case "3":
                        if(!addressBook.DisplayAddressBooks())
                            Console.WriteLine("Address books are not available. Please add Address books.");
                        break;
                    case "4":
                        flag = false;
                        Console.WriteLine("Thank You!");
                        break;
                    default: Console.WriteLine("please enter valid option");
                        break;
                }      
            }
        }
        //Menu for persons operations
        public void DisplaySubMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Please enter a choice");
                Console.WriteLine("select 1 to rename an Address book");
                Console.WriteLine("select 2 to delete an Address book");
                Console.WriteLine("select 3 to add new person");
                Console.WriteLine("select 4 to edit person details");
                Console.WriteLine("select 5 to display persons from Address Book");
                Console.WriteLine("select 6 to delete persons from Address Book");
                Console.WriteLine("select 7 to go back menu");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        addressBookMenu.renameAddressbook();
                        break;
                    case "2":
                        flag = addressBookMenu.deleteAddressBook();
                        break;
                    case "3":
                        personMenu.edit();
                        break;
                    case "4":
                        personMenu.display();
                        break;
                    case "5":
                        personMenu.delete();
                        break;
                    case "7":
                        flag = personMenu.goBack();
                        break;
                    default:
                        Console.WriteLine("please enter valid option");
                        break;
                }
            }
        }
    }
}
