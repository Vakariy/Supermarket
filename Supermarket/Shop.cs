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
        
        public DateTime dateInShop; // 2 клиента + 1 день

        public void FirstDelivery()
        {
            Random random = new Random();
            // Загрузка со склада.
            for (int i = 0; i < stock.stockProductList.Count; i++)
            {
                productListShop.Add(stock.stockProductList[i]);
                productListShop[i].quantity = random.Next(3, 5);
            }
        }


        public void PrintShopProduct()
        {
            Console.WriteLine("--Print catalog products of supermarket--");
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
        }
        

        public Buyer CreateListProductForOneBuyer()
        {
            Buyer buyer = new Buyer();
            // В списке у каждого покупателя 3 товара
            int myProductList = 3;

            Random random = new Random();
            int index = 0;

            for (int i = 0; i < myProductList; i++)
            {
                index = random.Next(1, stock.stockProductList.Count);
                buyer.buyerProductList.Add(stock.stockProductList[index]);
            }
            return buyer;
        }

        //public void CreateBuyerList()
        //{
        //    int queue = 16;
        //    Buyer buyer = new Buyer();
        //    for (int i = 0; i < queue; i++)
        //    {
        //        buyer = CreateListProductForOneBuyer();
        //        buyerList.Add(buyer);
        //        //Это проверка. Закомментировать buyer.PrintInfoBuyer
        //        buyer.PrintInfoBuyer();
        //    }
        //} старый код, новый снизу

        public void CreateBuyerList()
        {
            Buyer buyer = new Buyer();
            buyer = CreateListProductForOneBuyer();
            buyerList.Add(buyer);
            //Это проверка. Закомментировать buyer.PrintInfoBuyer
            buyer.PrintInfoBuyer();
        }

        //public void BuyProduct()
        //{

        //}

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

       

        public void Start()
        {
            FirstDelivery(); //загрузить продукты со склада
            PanelManager(); // метод для сценария и пользовательского взаимодействия

            // Показать наличие продуктов в супермеркете.
            // PrintShopProduct();
        }

        public void PanelManager()
        {
            while (true)
            {
                PrintShopProduct();
                Choice();
                CreateBuyerList();
               // BuyProduct();
            }
        }
    }
}
