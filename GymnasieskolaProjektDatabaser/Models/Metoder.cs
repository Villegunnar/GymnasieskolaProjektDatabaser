using GymnasieskolaProjektDatabaser.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace GymnasieskolaProjektDatabaser.Models
{
    class Metoder
    {
        public static void DisplayStaff()
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            var dispAllStaff = from TblPersonal in Context.TblPersonalen
                               select TblPersonal;

            foreach (var item in dispAllStaff)
            {
                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
            }
            Done();

        }
        public static void GetAllUniqueClasses()
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            var allClasses = (from TblElev in Context.TblElever
                              select TblElev.Klass).Distinct();

            foreach (var item in allClasses)
            {

                Console.WriteLine($"Klassnamn: {item}");
            }
        }
        public static void SortName(string firstOrLastName, string ascOrDesc)
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();
            if (firstOrLastName.ToUpper() == "FIRSTNAME")
            {
                if (ascOrDesc.ToUpper() == "ASC")
                {
                    TitleAndPercentage("Sorterar FÖRNAMN via FALLANDE\n", 25);

                    var sortByFnameAsc = from TblElev in Context.TblElever
                                         orderby TblElev.Förnamn
                                         select TblElev;

                    foreach (var item in sortByFnameAsc)
                    {
                        Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                    }
                    Done();

                }
                if (ascOrDesc.ToUpper() == "DESC")
                {
                    TitleAndPercentage("Sorterar FÖRNAMN via STIGANDE\n", 25);
                    var sortByFnameDesc = from TblElev in Context.TblElever
                                          orderby TblElev.Förnamn descending
                                          select TblElev;

                    foreach (var item in sortByFnameDesc)
                    {
                        Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                    }
                    Done();
                }
            }
            if (firstOrLastName.ToUpper() == "LASTNAME")
            {
                if (ascOrDesc.ToUpper() == "ASC")
                {
                    TitleAndPercentage("Sorterar EFTERNAMN via FALLANDE\n", 25);
                    var sortByLnameAsc = from TblElev in Context.TblElever
                                         orderby TblElev.Efternamn
                                         select TblElev;

                    foreach (var item in sortByLnameAsc)
                    {
                        Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                    }
                    Done();
                }
                if (ascOrDesc.ToUpper() == "DESC")
                {
                    TitleAndPercentage("Sorterar EFTERNAMN via STIGANDE\n", 25);
                    var sortByLnameDesc = from TblElev in Context.TblElever
                                          orderby TblElev.Efternamn descending
                                          select TblElev;

                    foreach (var item in sortByLnameDesc)
                    {
                        Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                    }
                    Done();
                }
            }



        }
        public static void DisplayStudentInfo()
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();
            TitleAndPercentage("Visa information om alla ELEVER\n", 25);
            var displayStudentInfo = (from p in Context.TblElever
                                      join e in Context.TblKlasser
                                      on p.KlassId equals e.KlassId                                  
                                      select new
                                      {
                                          ID = p.ElevId,
                                          FirstName = p.Förnamn, 
                                          LastName = p.Efternamn,
                                          PersonalNumber = p.Personnummer,
                                          ClassName = e.KlassNamn
                                      }).ToList();
            foreach (var p in displayStudentInfo)
            {
                Console.WriteLine($"ID: {p.ID} Namn: {p.FirstName} {p.LastName} Personnummer: {p.PersonalNumber} Klass: {p.ClassName}\n-----------------------------------------------------------------------");
            }
            Done();
        }
        public static void Done()
        {
            Console.WriteLine("\nKlart! Tyck enter för att gå tillbaka till huvudmenyn.");
            Console.ReadLine();
        }
        public static void ActiveCourses()
        {

            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();
            TitleAndPercentage("Alla kurser\n", 25);
            var activeCourses = from TblKurs in Context.TblKurser
                                select TblKurs;

            foreach (var item in activeCourses)
            {

                Console.WriteLine($"{item.KursNamn}");
            }

            DateTime today = DateTime.Now.Date;

            var activeCourse = from TblKurs in Context.TblKurser
                               orderby TblKurs.KursId
                               where TblKurs.StartDatum < today && TblKurs.SlutDatum > today
                               select TblKurs;

            foreach (var item in activeCourse)
            {
                Console.WriteLine($"Kursnamn: {item.KursNamn} Kursen startar: {item.StartDatum} och kurs slutar: {item.SlutDatum}");
            }



            Done();
        }
        public static void ClearWriteLine(string text = "")
        {
            Console.Clear();
            Console.WriteLine(text);
        }
        public static void TitleAndPercentage(string tempText = "", int tempSleepTime = 10)
        {
            Console.Clear();
            TextTyper(tempText, 20);

            //for (int i = 0; i <= 99; i++)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.Write($"\rProgress: {i}%   ");
            //    Thread.Sleep(tempSleepTime);

            //}
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("\rProgress: 100%   ");
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine();

        }
        public static void TextTyper(string tempText = "", int temptextSpeed = 0)
        {

            string text = tempText;
            int textSpeed = temptextSpeed;

            for (int i = 0; i < text.Length; i++)
            {
                Random randomColor = new Random();

                Thread.Sleep(textSpeed);
                Console.Write(text[i]);
            }
        }
        public static void StaffInEachDepartment()
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();
            TitleAndPercentage("Hur många jobbar på de olika avdelningarna\n", 25);

            var displayStudentInfo = (from p in Context.TblPersonalen
                                      join e in Context.TblBefattningar
                                      on p.BefattningId equals e.BefattningId
                                      select new
                                      {
                                          ID = p.PersonalId,
                                          FirstName = p.Förnamn,
                                          LastName = p.Efternamn,
                                          Position = e.Befattning,
                                          Section = e.Avdelning


                                      }).ToList();

            foreach (var p in displayStudentInfo)
            {
                Console.WriteLine($"ID: {p.ID} Namn: {p.FirstName} {p.LastName} Befattning: {p.Position} Avdelning: {p.Section}\n                                                               ");
            }
            

            var department1 = Context.TblPersonalen.Where(dep1 => dep1.BefattningId == 1).Count();

            var department2 = Context.TblPersonalen.Where(dep2 => dep2.BefattningId == 2).Count();

            var department3 = Context.TblPersonalen.Where(dep3 => dep3.BefattningId == 3).Count();

            var department4 = Context.TblPersonalen.Where(dep4 => dep4.BefattningId == 4).Count();

            var department5 = Context.TblPersonalen.Where(dep5 => dep5.BefattningId == 5).Count();

            var department6 = Context.TblPersonalen.Where(dep6 => dep6.BefattningId == 6).Count();


            Console.WriteLine($"Antal anställda som lärare: {department1}\nAntal anställda som vaktmästare: {department2}\nAntal anställda inom IT: {department3}\nAntal Chefer: {department4}\nAntal anställda inom Administraion: {department5}\nAntal Utbildningsledare: {department6}");






            //var totalWorkersInDepartment = from TblBefattning in Context.TblBefattningar
            //                               select TblBefattning;


            //foreach (var item in totalWorkersInDepartment)
            //{

            //    Console.WriteLine($"{item.Avdelning}");
            //}




            //var displayStudentInfo = (from p in Context.TblPersonalen
            //                          join e in Context.TblBefattningar
            //                          on p.BefattningId equals e.BefattningId
            //                          select new
            //                          {
            //                              ID = p.PersonalId,
            //                              FirstName = p.Förnamn,
            //                              LastName = p.Efternamn,
            //                              Posistion = e.Befattning
            //                          }).ToList();
            //foreach (var p in displayStudentInfo)
            //{
            //    Console.WriteLine($"ID: {p.ID} Namn: {p.FirstName} {p.LastName} Beffatning: {p.Posistion}\n-----------------------------------------------------------------------");
            //}
            Done();
        }

    }
}
