using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Statistics
    {
        public List<Registr> statisticList = new List<Registr>();
        public Dictionary<DateTime, List<Registr>> statisticDictionary = new Dictionary<DateTime, List<Registr>>();
       
        
        public void PrintStatisticDictionary()
        {
            for (int i = 0; i < statisticDictionary.Count; i++)
            {
               
            }
        }

        public void PrintAllStatistic()
        {
            int pieses = 0;
            int money = 0;


            Console.WriteLine("===PrintAllStatistic====\n");
            if (statisticList.Count != 0)
            {

                for (int i = 0; i < statisticList.Count; i++)
                {

                    Console.WriteLine($"{i + 1} {statisticList[i].day.ToShortDateString()}.{statisticList[i].name}--{statisticList[i].quantity}");
                    pieses++;
                    money += statisticList[i].price;

                }               
            }
            Console.WriteLine("==========================");
        }
        //public void AskStatisticDay()
        //{
        //    int choiseNumber;
        //    DateTime time = DateTime.Now;
        //    int index = 0;
        //    if (statisticList.Count != 0)
        //    {

        //        Console.WriteLine("Choise number of day");
        //        for (int i = 0; i < statisticList.Count; i++)
        //        {
        //            //for (int j = 0; j < statisticList.Count; j++)
        //            //{
        //            if (statisticList[i].day == time)
        //            {
        //                Console.WriteLine($"{i + 1}. Day: {statisticList[i].day}");
        //                Console.WriteLine("---");
        //            }

        //            if (statisticList[i].day == time.AddDays(1))
        //            {
        //                Console.WriteLine($"{i + 1}. Day: {statisticList[i].day}");
        //                Console.WriteLine("---");
        //            }
        //            //}

        //        }
        //        for (; ; )
        //        {
        //            if (int.TryParse(Console.ReadLine(), out choiseNumber) == true)
        //            {
        //                if (choiseNumber > 0 && choiseNumber <= statisticList.Count)
        //                {
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Incorrrect input");
        //            }
        //        }

        //        PrintStatisticDay(choiseNumber);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"We dont have statistic");
        //    }
        //}

        //public void PrintStatisticDay(int choiseNumber)
        //{
        //    for (int i = 0; i < statisticList.Count; i++)
        //    {
        //        if (i == choiseNumber - 1)
        //        {
        //            Console.WriteLine($"Day: {statisticList[i].day}-{statisticList[i].name}-{statisticList[i].quantity}");
        //        }
        //    }
        //}


        ////public void PrintAllStatistic()
        ////{
        ////    if (statisticList.Count != 0)
        ////    {
        ////        for (int i = 0; i < statisticList.Count; i++)
        ////        {
        ////            Console.WriteLine($"Day: {statisticList[i].day}-{statisticList[i].product.name}-{statisticList[i].product.quantity}");
        ////        }
        ////    }
        ////    else
        ////    {
        ////        Console.WriteLine($"We dont have statistic"); 
        ////    }

        ////}

        ////public void AskStatisticDay()
        ////{
        ////    int choiseNumber;

        ////    if (statisticList.Count!=0)
        ////    {             

        ////        Console.WriteLine("Choise number of day");
        ////        for (int i = 0; i < statisticList.Count; i++)
        ////        {
        ////            for (int j = 0; j < statisticList.Count; j++)
        ////            {
        ////                if (statisticList[i].day != statisticList[j].day)
        ////                {
        ////                    Console.WriteLine($"{i+1}. Day: {statisticList[i].day}");
        ////                }
        ////            }

        ////        }
        ////        for (; ; )
        ////        {
        ////            if (int.TryParse(Console.ReadLine(), out choiseNumber) == true)
        ////            {
        ////                if (choiseNumber > 0 && choiseNumber <= statisticList.Count)
        ////                {
        ////                    break;
        ////                }
        ////            }
        ////            else
        ////            {
        ////                Console.WriteLine("Incorrrect input");
        ////            }
        ////        }

        ////        PrintStatisticDay(choiseNumber);
        ////    }
        ////    else
        ////    {
        ////        Console.WriteLine($"We dont have statistic");
        ////    }   
        ////}

        ////public void PrintStatisticDay(int choiseNumber)
        ////{
        ////    for (int i = 0; i < statisticList.Count; i++)
        ////    {
        ////        if (i== choiseNumber - 1)
        ////        {
        ////            Console.WriteLine($"Day: {statisticList[i].day}-{statisticList[i].product.name}-{statisticList[i].product.quantity}");
        ////        }             
        ////    }
        ////}
    }


}
