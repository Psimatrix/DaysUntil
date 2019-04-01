using System;
using System.Linq;
using DaysUntil.Data;
using Microsoft.EntityFrameworkCore.Internal;

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
                //TODO refactor into a separate service class to provide this quote

                //TODO change this code so that the quote is in parenthsis and italic display

                //TODO Add functionality so that can add new quotes to system

                var quoteCount = db.Quotes.Count();
                Random random = new Random();
                var quoteId = random.Next(1, quoteCount);
                var quote = db.Quotes.FirstOrDefault(q => q.Id == quoteId);
                Console.WriteLine($"{quote?.Description}");
                Console.WriteLine($" \t-- {quote?.Author}");
                Console.WriteLine();
                Console.WriteLine();

                System.Threading.Thread.Sleep(3000);

                // TODO refactor into a separate service class to provide this data.

                // TODO add an emphasis field to display a sense of importance

                // TODO add funcitonality to Add new events to system

                // TODO add functionality to show past events if desired.
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
