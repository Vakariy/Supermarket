﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Shop
    {
        public Statistics statistics = new Statistics();
        public List<Product> buyerProductList;
        public List<Product> productListShop = new List<Product>();
        public List<Buyer> buyerList = new List<Buyer>();
        public Stock stock = new Stock();
        int daysInshop = 0;
        public static DateTime dateInShop = DateTime.Now; 

        //загрузка стелажей в торговый зал со склада
        public void FirstDelivery()
        {
             stock.StockSet();
            Console.WriteLine();
            Random random = new Random();            
            for (int i = 0; i < stock.stockProductList.Count; i++)
            {
                productListShop.Add(stock.stockProductList[i]);
                productListShop[i].quantity = random.Next(3, 5);
            }
        }

        //вывод продукции на полках магазина в разрезе стеллажей
        public void PrintShopProduct()
        {

            Console.WriteLine("--Print catalog products of supermarket--");
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine("_____________Shelf 1________________");

            foreach (var item in productListShop)
            {

                if (item.numberShelf == 1)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine($"Shelf      : {item.numberShelf}");
                    Console.WriteLine($"Name       : {item.name}");
                    Console.WriteLine($"Price      : {item.price} grn");
                    Console.WriteLine($"Quantity   : {item.quantity}");
                    Console.WriteLine($"Weight     : {item.weight} gr");
                    Console.WriteLine($"Shelf      : {item.numberShelf}");
                    Console.WriteLine($"Days stored: {item.daysStored} days");
                    Console.WriteLine($"Date       : {item.dateStartStored}");
                    Console.WriteLine("------------------------");
                }
            }
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.WriteLine("_____________Shelf 2________________");

            foreach (var item in productListShop)
            {
                if (item.numberShelf == 2)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine($"Shelf      : {item.numberShelf}");
                    Console.WriteLine($"Name       : {item.name}");
                    Console.WriteLine($"Price      : {item.price} grn");
                    Console.WriteLine($"Quantity   : {item.quantity}");
                    Console.WriteLine($"Weight     : {item.weight} gr");
                    Console.WriteLine($"Shelf      : {item.numberShelf}");
                    Console.WriteLine($"Days stored: {item.daysStored} days");
                    Console.WriteLine($"Date       : {item.dateStartStored}");
                    Console.WriteLine("------------------------");
                }
            }
            Console.WriteLine("____________________________________");

            Console.WriteLine("_____________Shelf 3________________");
            foreach (var item in productListShop)
            {
                if (item.numberShelf == 3)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine($"Shelf      : {item.numberShelf}");
                    Console.WriteLine($"Name       : {item.name}");
                    Console.WriteLine($"Price      : {item.price} grn");
                    Console.WriteLine($"Quantity   : {item.quantity}");
                    Console.WriteLine($"Weight     : {item.weight} gr");
                    Console.WriteLine($"Shelf      : {item.numberShelf}");
                    Console.WriteLine($"Days stored: {item.daysStored} days");
                    Console.WriteLine($"Date       : {item.dateStartStored}");
                    Console.WriteLine("------------------------");
                }
            }
            Console.WriteLine("_____________________________");
            Console.ResetColor(); 
        }

        //создание списка покупок для клиента в очереди
        public Buyer CreateListProductForOneBuyer()
        {
            Buyer buyer = new Buyer();
            int myProductList = 3;
            Random random = new Random();
            int index = 0;

            for (int i = 0; i < myProductList; i++)
            {
                index = random.Next(0, stock.stockProductList.Count);
                buyer.buyerProductList.Add(stock.stockProductList[index]);
            }
            return buyer;
        }

        //точка входа в создание клиента в очереди
        public void CreateBuyerList()
        {
            Buyer buyer = new Buyer();
            buyer = CreateListProductForOneBuyer();
            buyerList.Add(buyer);
            daysInshop += buyer.GenerationCheckForBayer();
        }


        //выбор пользователя
        public int Choice()
        {
            int choise;
            for (; ; )
            {
                do
                {
                    Console.WriteLine("Do you want to buy some products?");
                    Console.WriteLine("Yes - 1   |   No - 2(Go to menu)");
                } while (!int.TryParse(Console.ReadLine(), out choise));
                if (choise >= 1 && choise <= 2)
                {
                    break;
                }
            }
            return choise;
        }

        //метод проверки остатков на полках в торговом зале. Если пусто, то заполнить товаром со склада
        public void CheckStock()
        {
            int id = 0;
            foreach (var item in productListShop)
            {
                if (item.quantity > 0)
                {
                    id++;
                }
            }

            if (id == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue; 
                Console.WriteLine();
                Console.WriteLine("Products in supermarket is stock out!");
                Console.WriteLine("Acceptance of goods...");
                Console.WriteLine();
                Console.WriteLine("Key Enter for download products from stock to at shop shelf...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("New delivery of products!!!");
                Console.WriteLine();
                productListShop.Clear();
                stock.stockProductList.Clear();
                FirstDelivery();
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        //проверка срока годности
        public void CheckSrokGodnosti()
        {
            foreach (Product item in productListShop)
            {
                if (item.dateStartStored.AddDays(item.daysStored) < dateInShop && item.status == "OK")
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("Product " + item.name + " has expired. Product has been deleted from shelf!");
                    Console.WriteLine("Key Enter for continue...");
                    Console.ReadKey();
                    Console.ResetColor(); 
                    item.status = "NON";
                    item.quantity = 0;
                }
            }   
        }   

    public void SetTimeInShop()
    {
        if (daysInshop % 2 == 0 && daysInshop != 0)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta; 
            Console.WriteLine("---------------------------------------------");
            Console.Write("Today is ");
            Console.WriteLine(dateInShop = dateInShop.AddDays(1));
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.ResetColor(); 
        }
        else if (daysInshop % 2 != 0 || daysInshop == 0)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Today is " + dateInShop);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.ResetColor(); // сбрасываем в стандартный
        }
    }

    //сценарий и взаимодействие с пользователем
    public void PanelManager()
    {
        int input;
        while (true)
        {
            PrintShopProduct();
            SetTimeInShop();
            input = Choice();

            switch (input)
            {
                case 1:
                    CreateBuyerList();
                    CheckStock();
                    CheckSrokGodnosti();
                    break;
                case 2:
                        Menu();
                    break;
            }
        }
    }

        public void Menu()
        {
            int choise;
            for (; ; )
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("What would you like do?");
                    Console.WriteLine("1 - Go to supermarket   |   2 - Generation report for one day  |   3 - Generation of the entire report by day");
                } while (!int.TryParse(Console.ReadLine(), out choise));

                if (choise >= 1 && choise <= 3)
                {
                    break;
                }
            }

            switch (choise)
            {
                case 1:
                    break;
                case 2:
                    statistics.AskStatisticDay();
                    break;
                case 3:
                    statistics.PrintAllStatistic();
                    break;
            }
        }

        // вызов с главного класса
        public void Start()
        {
            FirstDelivery(); //загрузить продукты со склада
            PanelManager(); // метод для сценария и пользовательского взаимодействия
        }
    }
}

