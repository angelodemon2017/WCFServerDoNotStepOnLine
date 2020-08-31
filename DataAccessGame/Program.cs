using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessGame.Models;
using System.Linq;

namespace DataAccessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DBGContext db = new DBGContext())
            {
                Boot newBoot = new Boot() { BootName = "testBoot", Price = 100, PremiumPrice = 0, ActualDate = DateTime.Now, BurnDate = DateTime.Now };
                db.Boots.Add(newBoot);
                db.SaveChanges();
            //    Console.WriteLine("Объект успешно сохранен");

                // получаем объекты из бд и выводим на консоль
                var users = db.Players;
                Console.WriteLine("Список объектов:");
                foreach (var u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Name, u.DateRegistration, u.Ip);
                }
            }
            Console.Read();
        }
    }
}
