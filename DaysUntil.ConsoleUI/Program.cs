using System;
using System.Linq;
using DaysUntil.Data;

namespace DaysUntil.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("*            Days Until              *");
            Console.WriteLine("*            Written by              *");
            Console.WriteLine("*        Jonathan F. Allen           *");
            Console.WriteLine("**************************************");
            Console.WriteLine();
            using (var db = new DaysUntilContext())
            {
                foreach (var item in db.Events.Where(ev => ev.DueDate > DateTime.Now).OrderBy(ev => ev.DueDate))
                {
                    Console.WriteLine($"{item.Title} in {CalculateDays(item.DueDate)} days");
                }
            }

            Console.WriteLine("\n\n ... Press any key to exit");
            Console.ReadLine();
        }

        private static int CalculateDays(DateTime dueDate)
        {
            TimeSpan ts = dueDate - DateTime.Now;
            return ts.Days;
        }
    }
}
