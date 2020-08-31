using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Shop
    {
        public List<Product> buyerProductList;
        public List<Product> productListShop = new List<Product>();
        public List<Buyer> buyerList = new List<Buyer>();
        public Stock stock = new Stock();
        int daysInshop = 0;

        public DateTime dateInShop = new DateTime(2020, 8, 20, 23, 30, 25); // 2 клиента + 1 день

        //первая загрузка стелажей в торговом зале со склада
        public void FirstDelivery()
        {
            Console.ForegroundColor = ConsoleColor.Magenta; // устанавливаем цвет
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(dateInShop);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.ResetColor(); // сбрасываем в стандартный
            Random random = new Random();
            // Загрузка со склада.
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
            Console.ForegroundColor = ConsoleColor.Yellow; // устанавливаем 
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
                    //Console.WriteLine($"Weight     : {item.weight} gr");
                    //Console.WriteLine($"Shelf      : {item.numberShelf}");
                    //Console.WriteLine($"Days stored: {item.daysStored} days");
                    //Console.WriteLine($"Date       : {item.dateStartStored}");
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
                    //Console.WriteLine($"Weight     : {item.weight} gr");
                    //Console.WriteLine($"Shelf      : {item.numberShelf}");
                    //Console.WriteLine($"Days stored: {item.daysStored} days");
                    //Console.WriteLine($"Date       : {item.dateStartStored}");
                    //Console.WriteLine("------------------------");
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
                    //Console.WriteLine($"Weight     : {item.weight} gr");
                    //Console.WriteLine($"Shelf      : {item.numberShelf}");
                    //Console.WriteLine($"Days stored: {item.daysStored} days");
                    //Console.WriteLine($"Date       : {item.dateStartStored}");
                    Console.WriteLine("------------------------");
                }
            }
            Console.WriteLine("_____________________________");
            Console.ResetColor(); // сбрасываем в стандартный
        }
        
        //создание списка покупок для клиента в очереди
        public Buyer CreateListProductForOneBuyer()
        {
            Buyer buyer = new Buyer();
            // В списке у каждого покупателя 3 товара
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
        public void Choice()
        {
            int choise;
            for (; ; )
            {
                do
                {
                    Console.WriteLine("Do you want to buy some products?");
                    Console.WriteLine("Yes - 1   |   No - 2(exit)");
                } while (!int.TryParse(Console.ReadLine(), out choise));
                if (choise >= 1 && choise <= 2)
                {
                    break;
                }
            }

            if (choise == 1)
            {
                Console.WriteLine("List with products for buy: ");
            } else if(choise == 2) { Environment.Exit(0); }
           
        }

       
        // вызов с главного класса
        public void Start()
        {
            FirstDelivery(); //загрузить продукты со склада
            PanelManager(); // метод для сценария и пользовательского взаимодействия
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
                Console.ForegroundColor = ConsoleColor.Blue; // устанавливаем цвет
                Console.WriteLine();
                Console.WriteLine("Products in supermarket is stock out!");
                Console.WriteLine("Acceptance of goods...");
                Console.WriteLine();
                Console.WriteLine("Key Enter for download products from stock to at shop shelf...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("New delivery of products!!!");
                FirstDelivery();
                Console.WriteLine();
                Console.ResetColor(); // сбрасываем в стандартный
            }
        }


        public void SetTimeInShop()
        {
            
            if (daysInshop % 2 == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta; // устанавливаем цвет
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(dateInShop.AddDays(daysInshop / 2));
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine();
                Console.ResetColor(); // сбрасываем в стандартный
            } else if(daysInshop % 2 != 0)
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
            while (true)
            {
                PrintShopProduct();
                Choice();
                CreateBuyerList();
                CheckStock();
                SetTimeInShop();
            }
        }
    }
}
