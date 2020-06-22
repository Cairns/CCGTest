using FileHandling.BO;
using FileHandling.IO;
using FileHandling.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileHandlingClient
{
    public class Program
    {
        public static IEnumerable<Contact> contacts = null;
        static void Main(string[] args)
        {
            ShowMainMenu();

            Exit();
        }

        private static void ShowMainMenu()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        public static bool MainMenu()
        {
            Menu.DisplayMainMenu();

            switch (CaptureInput())
            {
                case "1":
                    {
                        //Display Data
                        DisplayContactData(contacts);
                        return true;
                    }
                case "2":
                    {
                        //Read File
                        ShowReadMenu();
                        return true;
                    }
                case "3":
                    {
                        //Write File
                        ShowWriteMenu();
                        return true;
                    }
                case "0":
                    {
                        //Exit
                        return false;
                    }
                default:
                    {
                        //Invalid option entered
                        Console.WriteLine("You entered an Invalid option.  Please try again");
                        Pause(1);
                        return true;
                    }
            }
        }

        private static void ShowReadMenu()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = ReadMenu();
            }
        }

        private static bool ReadMenu()
        {
            Menu.DisplayFileMenu();

            var input = CaptureInput();

            switch(input)
            {
                case "0":
                    {
                        //Exit
                        return false;
                    }
                default:
                    {
                        //FileName specified
                        ReadFile(input);
                        return false;
                    }
            }
        }

        private static void ReadFile(string fileName)
        {
            try
            {
                var fileType = ParseReadFileName(fileName);
                var fileHandler = FileHandlerFactory<Contact>.Create(fileType);
                contacts = fileHandler.Read<Contact>(fileName);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Pause(2);
            }
        }

        private static string ParseReadFileName(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                throw new System.IO.FileNotFoundException("No file name specified");
            }
            else if (!File.Exists(fileName))
            {
                throw new System.IO.FileNotFoundException("Specified file does not exist");
            }
            else
            {
                return Path.GetExtension(fileName).Replace(".", "");
            }
        }

        private static void ShowWriteMenu()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = WriteMenu();
            }
        }

        private static bool WriteMenu()
        {
            Menu.DisplayFileMenu();

            var input = CaptureInput();

            switch (input)
            {
                case "0":
                    {
                        //Exit
                        return false;
                    }
                default:
                    {
                        //FileName specified
                        WriteFile(input);
                        return false;
                    }
            }
        }

        private static void WriteFile(string fileName)
        {
            try
            {
                var fileType = ParseWriteFileName(fileName);
                var fileHandler = FileHandlerFactory<Contact>.Create(fileType);
                fileHandler.Write(contacts, fileName);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Pause(2);
            }
        }

        private static string ParseWriteFileName(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                throw new System.IO.FileNotFoundException("No file name specified");
            }
            else
            {
                return Path.GetExtension(fileName).Replace(".", "");
            }
        }

        private static void DisplayContactData(IEnumerable<Contact> contacts)
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

            CaptureInput();
        }


        private static string CaptureInput()
        {
            return Console.ReadLine();
        }

        private static void Pause(int seconds)
        {
            TimeSpan timeSpan = new TimeSpan(0,0,seconds);
            Thread.Sleep(timeSpan);
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting the program");
            Pause(1);
            Environment.Exit(0);
        }
    }
}
