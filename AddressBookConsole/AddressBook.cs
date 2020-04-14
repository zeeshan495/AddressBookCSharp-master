using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookConsole
{
    class AddressBook
    {
        IMainMenu menu;
        ISubMenu subMenu;
        Person person;
        IDBConnection dbConn;
        public AddressBook()
        {
            menu = new MainMenu();
            subMenu = new SubMenu();
            person = new Person();
            dbConn = new DBConnection();
            dbConn.open();
        }
        public void DisplayMainMenu()
        {
            Console.WriteLine("Display main menu");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Please enter a choice");
                Console.WriteLine("select 1 to add new Address Book");
                Console.WriteLine("select 2 to open Address Books");
                Console.WriteLine("select 3 to display Address Books");
                Console.WriteLine("select 4 to save Address Book");
                Console.WriteLine("select 5 to save as Address Book");
                Console.WriteLine("select 6 to close Application");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        this.menu.create(dbConn);
                        break;
                    case "2":
                        this.menu.open();
                        this.DisplaySubMenu();
                        break;
                    case "3":
                        this.menu.display();
                        break;
                    case "4":
                        this.menu.save();
                        break;
                    case "5":
                        this.menu.saveAs();
                        break;
                    case "6":
                        flag = this.menu.close();
                        break;
                    default: Console.WriteLine("please enter valid option");
                        break;
                }      
            }
            dbConn.close();
        }

        public void DisplaySubMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Please enter a choice");
                Console.WriteLine("select 1 to add new person");
                Console.WriteLine("select 2 to edit person details");
                Console.WriteLine("select 3 to delete persons in Address Book");
                Console.WriteLine("select 4 to display persons in Address Book");
                Console.WriteLine("select 5 to go back menu");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        this.subMenu.add();
                        break;
                    case "2":
                        this.subMenu.edit();
                        break;
                    case "3":
                        this.subMenu.delete();
                        break;
                    case "4":
                        this.subMenu.display();
                        break;
                    case "5":
                        flag = this.subMenu.goBack();
                        break;
                    default:
                        Console.WriteLine("please enter valid option");
                        break;
                }
            }
        }
    }
}
