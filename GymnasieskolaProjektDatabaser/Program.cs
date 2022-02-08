using GymnasieskolaProjektDatabaser.Data;
using GymnasieskolaProjektDatabaser.Models;
using System;
using System.Linq;
using System.Threading;

namespace GymnasieskolaProjektDatabaser
{
    class Program
    {
        static void Main(string[] args)
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();
            bool loggedIn = true;
            while (loggedIn)
            {
                Metoder.ClearWriteLine("1. Elever\n2. Personal\n3. Kurser\n4. Löner\n\nESC för att avsluta programmet\n");
                var keyInfo = Console.ReadKey(intercept: true);
                ConsoleKey menuChoice = keyInfo.Key;
                switch (menuChoice)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Metoder.ClearWriteLine("ELEVER \n\n1. Förnamn via fallande sortering\n2. Förnamn via stigande sortering\n3. Efternamn via fallande sortering\n4. Efternamn via stigande sortering\n\n5. Visa information om alla ELEVER\n6. Uppdatera/korrigera en elevs information\n\n");
                        ConsoleKey studentSwitch = Console.ReadKey(intercept: true).Key;
                        switch (studentSwitch)
                        {
                            case ConsoleKey.NumPad1:
                            case ConsoleKey.D1:
                                Metoder.SortName("firstName", "asc");
                                break;
                            case ConsoleKey.NumPad2:
                            case ConsoleKey.D2:
                                Metoder.SortName("firstName", "desc");
                                break;
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                Metoder.SortName("lastname", "asc");
                                break;
                            case ConsoleKey.NumPad4:
                            case ConsoleKey.D4:
                                Metoder.SortName("lastname", "asc");
                                break;
                            case ConsoleKey.NumPad5:
                            case ConsoleKey.D5:
                                Metoder.DisplayStudentInfo();
                                break;
                            case ConsoleKey.Escape:
                                break;
                            default:
                                break;
                        }
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Metoder.ClearWriteLine("PERSONAL, \n\n1. All Personal som finns i databasen\n2. Hur många lärare jobbar på de olika avdelningarna\n\n");
                        ConsoleKey staffSwitch = Console.ReadKey(intercept: true).Key;
                        switch (staffSwitch)
                        {
                            case ConsoleKey.NumPad1:
                            case ConsoleKey.D1:
                                Metoder.DisplayStaff();
                                break;
                            case ConsoleKey.NumPad2:
                            case ConsoleKey.D2:
                                Metoder.StaffInEachDepartment();                             
                                break;
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                Metoder.ClearWriteLine("Lägg till ny PERSONAL\n\nFörnamn: \nEfternamn: \nBefattning:\n");
                                //Metoder.AddNewStaff();
                                break;
                            case ConsoleKey.NumPad4:
                            case ConsoleKey.D4:

                                break;
                            case ConsoleKey.NumPad5:
                            case ConsoleKey.D5:

                                break;
                            case ConsoleKey.Escape:
                                break;
                            default:
                                break;
                        }
                        Console.ReadLine();
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:                
                        Metoder.ActiveCourses();
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.WriteLine("4");
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Console.WriteLine("5");
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        Console.WriteLine("6");
                        break;
                    case ConsoleKey.Escape:

                        loggedIn = false;
                        break;
                    default:
                        break;
                }
            }


        }

    }
}
