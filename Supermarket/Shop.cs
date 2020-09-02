using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Shop
    {
        public List<Product> productListShop = new List<Product>();
        public List<Buyer> buyerList = new List<Buyer>();
        public Stock stock = new Stock();
        public Statistics statistics = new Statistics();
        public DateTime dateInShop; // 2 клиента = 1 день

        public void Start()
        {
            //   stock.PrintStock();// Показать товар на складе
            DataAdd(0);// Установить/сменить дату дня в магазине
            FirstDelivery(); // Загрузить продукты со склада
            PanelManager(); // Меню
            // PrintShopProduct();// Показать наличие продуктов в супермеркете.
        }


        public void ShowDay()
        {
            Console.ForegroundColor = ConsoleColor.Magenta; // Устанавливаем цвет
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine($"   {dateInShop.ToShortDateString()}  ");
            Console.WriteLine("---------------------------------------------\n");
            Console.ResetColor(); // Сбрасываем в стандартный
        }

        public void FirstDelivery()
        {
            ShowDay();
            Random random = new Random();
            // Загрузка со склада.
            for (int i = 0; i < stock.stockProductList.Count; i++)
            {
                productListShop.Add(new Product(stock.stockProductList[i]));
                productListShop[i].quantity = random.Next(3, 5);
            }
            Console.WriteLine();
        }

        public void PanelManager()
        {
            //   stock.PrintStock();
            PrintShopProduct();

            int choise;
            for (; ; )
            {
                Console.WriteLine("Press - 1. if you want to sell product for 1 buyer");
                Console.WriteLine("Press - 2. if you want to sell product queue buyer");
                Console.WriteLine("Press - 3. if you want to print statistic for all days");
                Console.WriteLine("Press - 4. if you want to print statistic for for 1 day");
                Console.WriteLine("Press - 5. if you want to print product catalog shop");
                Console.WriteLine("Press - 6. if you want to exit to admin panel");
                if (int.TryParse(Console.ReadLine(), out choise) == true)
                {
                    if (choise == 1)
                    {
                        CreateBuyer();
                    }
                    else if (choise == 2)
                    {
                        CreateBuyersQueue();
                    }
                    else if (choise == 3)
                    {
                        statistics.PrintAllStatistic();
                    }
                    else if (choise == 4)
                    {
                        statistics.AskStatisticDay();
                    }
                    else if (choise == 5)
                    {
                        PrintShopProduct();
                    }
                    else if (choise == 6)
                    {
                        break;
                        // Environment.Exit(0);
                        //  PanelManager();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }

                }
            }
        }

        public void DataAdd(int change)
        {
            if (change == 0)
            {
                dateInShop = DateTime.Now;
            }
            else
            {
                dateInShop = dateInShop.AddDays(1);
            }
        }
        public void PrintShopProduct()
        {
            Console.WriteLine("--Print catalog products of supermarket--");
            Console.ForegroundColor = ConsoleColor.Yellow; // устанавливаем цвет

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"_____________Shelf {i + 1}________________");
                foreach (var item in productListShop)
                {
                    if (item.numberShelf == i + 1)
                    {
                        Console.WriteLine($"Shelf      : {item.numberShelf}");
                        Console.WriteLine($"Name       : {item.name}");
                        Console.WriteLine($"Price      : {item.price} grn");
                        Console.WriteLine($"Quantity   : {item.quantity}");
                        //Console.WriteLine($"Weight     : {item.weight} gr");
                        Console.WriteLine($"Days stored: {item.daysStored} days");
                        Console.WriteLine($"Date       : {item.dateStartStored.ToShortDateString()}");
                        Console.WriteLine("------------------------");
                    }
                }
            }
            Console.WriteLine("_____________________________");
            Console.ResetColor(); // сбрасываем в стандартный
        }

        public Buyer CreateListProductForOneBuyer()
        {
            Buyer buyer = new Buyer();
            int myProductList = 3;// В списке у каждого покупателя 3 товара
            Random random = new Random();
            int index;
            for (int i = 0; i < myProductList; i++)
            {
                index = random.Next(0, stock.stockProductList.Count);
                buyer.buyerProductList.Add(new Product(stock.stockProductList[index]));///изм.1
            }
            return buyer;
        }

        public void CreateBuyersQueue()
        {
            int queue;
            for (; ; )
            {
                Console.WriteLine("Enter amount people in the queue");
                if (int.TryParse(Console.ReadLine(), out queue))
                {
                    if (queue >= 2 && queue < 20)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input (queue 2-20 buyers)");
                    }
                }
            }

            Buyer buyer = new Buyer();
            for (int i = 0; i < queue; i++)
            {
                buyer = CreateListProductForOneBuyer();
                BuyProduct(buyer);
            }
        }

        public void CreateBuyer()
        {
            Buyer buyer = new Buyer();
            buyer = CreateListProductForOneBuyer(); // Заполнение продуктами списка 
            BuyProduct(buyer);
        }

        //процесс покупки общий для всех что для 1покупателя  что для очереди
        public void BuyProduct(Buyer buyer)
        {
            {
                // все продукты из списка покупателей есть в магазине
                int emptyCheck = AvailabilityListProdactBuyersInShop(buyer);
                if (emptyCheck == 3)
                {
                    Console.WriteLine("Sorry....we dont have all list of product");
                }
                else
                {
                    //проверка хватит ли денег у покупателя
                    if (buyer.CheckSumma() == true)
                    {
                        buyer.GenerationCheck();  
                        buyerList.Add(buyer);
                        AddStatistic(buyer);
                        DeleteProduct(buyer);
                        EmptyShop();
                    }


                    // добавление +1 день если прошло 2 покупателя    
                    if (buyerList.Count % 2 == 0 && buyerList.Count != 0)
                    {
                        DataAdd(1);
                        ShowDay();
                        Inventarization();
                    }
                }


            }
        }

        public int AvailabilityListProdactBuyersInShop(Buyer buyer)
        {
            int count = 0;
            //   bool existAll = true;
            for (int i = 0; i < productListShop.Count; i++)
            {
                for (int j = 0; j < buyer.buyerProductList.Count; j++)
                {
                    if (productListShop[i].name == buyer.buyerProductList[j].name)
                    {
                        if (productListShop[i].quantity == 0)
                        {
                            // если нет в магазине -обнуляем количество этого товара у покупателя  в списке
                            buyer.buyerProductList[j].quantity = 0;
                            Console.WriteLine($"Sorry...We dont have -{buyer.buyerProductList[j].name}");
                            // existAll = false;
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        public void DeleteProduct(Buyer buyer)
        {
            Console.WriteLine("\n===========Repot of sell================");
            for (int i = 0; i < productListShop.Count; i++)
            {
                for (int j = 0; j < buyer.buyerProductList.Count; j++)
                {
                    if (productListShop[i].name == buyer.buyerProductList[j].name && buyer.buyerProductList[j].quantity != 0)
                    {
                        productListShop[i].quantity -= 1;
                        Console.WriteLine($"We sell product -{productListShop[i].name}");
                    }
                }
            }
            Console.WriteLine("===========================");
        }

        public void AddStatistic(Buyer buyer)
        {
            Registr registr = new Registr();
            List<Registr> newList = new List<Registr>();
            for (int i = 0; i < buyer.buyerProductList.Count; i++)
            {
              
                registr.day = dateInShop;
                registr.name = buyer.buyerProductList[i].name;
                registr.quantity = buyer.buyerProductList[i].quantity;
                registr.price = buyer.buyerProductList[i].price;


                if (statistics.statisticDictionary.ContainsKey(dateInShop))
                {
                    statistics.statisticDictionary[dateInShop].Add(registr);
                }
                else
                {
                    newList.Add(registr);
                    statistics.statisticDictionary.Add(dateInShop, newList);
                }
              //  statistics.statisticList.Add(registr);
            }

            //for (int i = 0; i < buyer.buyerProductList.Count; i++)
            //{
            //    Registr registr = new Registr();
            //    registr.day = dateInShop;
            //    registr.name = buyer.buyerProductList[i].name;
            //    registr.quantity = buyer.buyerProductList[i].quantity;
            //    registr.price = buyer.buyerProductList[i].price;
            //    statistics.statisticList.Add(registr);
            //}
        }

        public void Inventarization()
        {
            Console.WriteLine($"====Report Inventarization={dateInShop.ToShortDateString()}====");
            for (int i = 0; i < productListShop.Count; i++)
            {
                if (productListShop[i].dateStartStored.AddDays(productListShop[i].daysStored) <= dateInShop)
                {
                    Console.WriteLine($"not OK { productListShop[i].name}" +
                        $"......{productListShop[i].dateStartStored.ToShortDateString()}" +
                        $"....{productListShop[i].daysStored} days- Deleted");
                    productListShop[i].quantity = 0;// удаляем продукт

                }
                else
                {
                    //  Console.WriteLine("OK");
                }
            }
            Console.WriteLine("========================");
        }

        public void EmptyShop()
        {
            int count = 0;
            for (int i = 0; i < productListShop.Count; i++)
            {
                count += productListShop[i].quantity;
            }

            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                Console.WriteLine($"Dont have ALL product");
                Console.WriteLine($"Start delivery from stock");
                FirstDelivery();
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine($"Shop not empty");
                Console.WriteLine($"count {count}");
            }
        }
    }
}
