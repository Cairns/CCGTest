using FileHandling.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling.UI
{
    public class Menu
    {
        public static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Display Data");
            Console.WriteLine("2) Read File");
            Console.WriteLine("3) Write File");
            Console.WriteLine("");
            Console.WriteLine("0) Exit");
            Console.WriteLine("");
            Console.Write("\r\nSelect an option: ");
        }

        public static void DisplayFileMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option");
            Console.WriteLine("");
            Console.WriteLine("0) Back");
            Console.WriteLine("");
            Console.Write("\r\nPlease specify a file name:");
        }

        public static void DisplayContactData(IEnumerable<Contact> contacts)
        {
            if (contacts == null)
            {
                Console.Clear();
                Console.WriteLine("No Contact data to display");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
            }
            else
            {
                Console.Clear();
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine(contact.ToString());
                    Console.WriteLine();
                }
                Console.WriteLine("Press any key to continue");
            }
        }
    }
}
