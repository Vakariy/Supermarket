using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Shop
    {
        public List<Product> prodactListShop = new List<Product>();
        public List<Buyer> buyerList = new List<Buyer>();
        public Stock stock = new Stock();

        public DateTime dateInShop;

        public void FirstDelivery()
        {
            Random random = new Random();
            //  prodactListShop = stock.stockProductList;
            for (int i = 0; i < stock.stockProductList.Count; i++)
            {
                prodactListShop.Add(stock.stockProductList[i]);
                prodactListShop[i].quantity = random.Next(3, 5);
            }
        }


        public void PrintShopProduct()
        {
            Console.WriteLine("--Print catalog products of supermarket--");
            Console.WriteLine("------------------------");

            foreach (var item in prodactListShop)
            {
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

        public void Start()
        {
            FirstDelivery();

            // Показать наличие продуктов в супермеркете.
            PrintShopProduct();
        }


    }
}
