using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Statistics
    {

        public static List<Registr> statisticList = new List<Registr>();

        public void PrintAllStatistic()
        {
            int pieses = 0;
            int money = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("===PrintAllStatistic====");
            if (statisticList.Count != 0)
            {
                for (int i = 0; i < statisticList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {statisticList[i].day}.{statisticList[i].name}--{1} pcs");
                    pieses++;
                    money += statisticList[i].price;
                }
                Console.WriteLine($"pieses- {pieses}");
                Console.WriteLine($"money- {money}");

            }
            Console.WriteLine();
            Console.WriteLine("==========================");
            Console.WriteLine("Key Enter for continue...");
            Console.ResetColor();
            Console.ReadKey();
        }


        public void AskStatisticDay()
        {
            DateTime dtOut;
            DateTime time = DateTime.Now;


            //Console.WriteLine("Choise number of day");
            //for (int i = 0; i < statisticList.Count; i++)
            //{
            //    if (statisticList[i].day == time)
            //    {
            //        Console.WriteLine($"{i + 1}. Day: {statisticList[i].day}");
            //        Console.WriteLine("---");
            //    }

            //    if (statisticList[i].day == time.AddDays(1))
            //    {
            //        Console.WriteLine($"{i + 1}. Day: {statisticList[i].day}");
            //        Console.WriteLine("---");
            //    }
            //}

            while (!DateTime.TryParse(Console.ReadLine(), out dtOut))
            {
                Console.WriteLine("Введите дату в формате: {0:d}", new DateTime(2008, 1, 7));
            }
            PrintStatisticDay(dtOut);
        }

        public void PrintStatisticDay(DateTime dtOut)
        {
            for (int i = 0; i < statisticList.Count; i++)
            {
                if (statisticList[i].day == dtOut)
                {
                    Console.WriteLine($"Day: {statisticList[i].day}-{statisticList[i].name}");
                }
            }
        }
    }
}



