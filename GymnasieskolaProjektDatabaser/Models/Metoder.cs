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
            TextTyper("Alla Anställda\n\n", 25);

            var dispAllStaff = (from p in Context.TblPersonalen
                                join e in Context.TblBefattningar
                                      on p.BefattningId equals e.BefattningId
                                      select new
                                      {
                                          ID = p.PersonalId,
                                          FirstName = p.Förnamn,
                                          LastName = p.Efternamn,
                                          DateOfEmployment = p.AnställningsDatum,
                                          Post = e.Befattning
                                      }).ToList();


            foreach (var item in dispAllStaff)
            {

                Console.WriteLine($"ID: {item.ID}\nNamn: {item.FirstName} {item.LastName}\nBefattning: {item.Post}\nAnställningsdatum: {item.DateOfEmployment}\n");
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
            Done();
        }
        public static void SortName(string firstOrLastName, string ascOrDesc)
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();
            if (firstOrLastName.ToUpper() == "FIRSTNAME")
            {
                if (ascOrDesc.ToUpper() == "ASC")
                {
                    TextTyper("Sorterar FÖRNAMN via FALLANDE\n\n", 25);

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
                    TextTyper("Sorterar FÖRNAMN via STIGANDE\n\n", 25);
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
                    TextTyper("Sorterar EFTERNAMN via FALLANDE\n\n", 25);
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
                    TextTyper("Sorterar EFTERNAMN via STIGANDE\n\n", 25);
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
            TextTyper("Visa information om alla elever\n\n", 25);
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
            foreach (var item in displayStudentInfo)
            {
                Console.WriteLine($"ID: {item.ID}\nNamn: {item.FirstName} {item.LastName}\nPersonnummer: {item.PersonalNumber}\nKlass: {item.ClassName}\n");
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
            
            DateTime today = DateTime.Now.Date;
            TextTyper("Alla aktiva kurser\n\n", 25);
            var activeCourse = from TblKurs in Context.TblKurser
                               orderby TblKurs.KursId
                               where TblKurs.StartDatum < today && TblKurs.SlutDatum > today
                               select TblKurs;

            foreach (var item in activeCourse)
            {
                Console.WriteLine($"Kursnamn: {item.KursNamn}\nKursstart: {item.StartDatum}\nKursslut: {item.SlutDatum}\n\n");
            }
            Done();
        }
        public static void ClearWriteLine(string text = "")
        {
            Console.Clear();
            Console.WriteLine(text);
        }
        //public static void ClearAndText(string tempText = "", int tempSleepTime = 10)
        //{
        //    Console.Clear();
        //    TextTyper(tempText, 20);
        //}
        public static void TextTyper(string tempText = "", int temptextSpeed = 0)
        {
            Console.Clear();
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

            int countId1 = Context.TblPersonalen.Where(x => x.BefattningId == 1).Count();

            int countId2 = Context.TblPersonalen.Where(x => x.BefattningId == 2).Count();

            int countId3 = Context.TblPersonalen.Where(x => x.BefattningId == 3).Count();

            int countId4 = Context.TblPersonalen.Where(x => x.BefattningId == 4).Count();

            int countId5 = Context.TblPersonalen.Where(x => x.BefattningId == 5).Count();

            int countId6 = Context.TblPersonalen.Where(x => x.BefattningId == 6).Count();


            TextTyper("Hur många jobbar på de olika avdelningarna\n\n", 25);
            Console.WriteLine($"Antal anställda som lärare: {countId1}\nAntal anställda som vaktmästare: {countId2}\nAntal anställda inom IT: {countId3}\nAntal Chefer: {countId4}\nAntal anställda inom Administraion: {countId5}\nAntal Utbildningsledare: {countId6}");
            Done();
        }
        public static void AllCourses()
        {
            TextTyper("Alla kurser\n\n", 25);
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            var activeCourses = from TblKurs in Context.TblKurser
                                select TblKurs;

            foreach (var item in activeCourses)
            {

                Console.WriteLine($"{item.KursNamn}");
            }
            Done();
        }
    }
}
