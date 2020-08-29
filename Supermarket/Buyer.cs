using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
  public  class Buyer
    {
        public List<Product> buyerProductList;
        public int purse;

        public Buyer()
        {
            buyerProductList = new List<Product>();
            Random random = new Random();
            purse = random.Next(200, 500);
        }

        public void PrintInfoBuyer()
        {
            int summa = 0;
            Console.WriteLine("************************");
            Console.WriteLine("List Prodacts for 1 buyer:");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"My purse:{purse} grn");

            for (int k = 0; k <buyerProductList.Count; k++)
            {
                Console.WriteLine($"{k + 1} {buyerProductList[k].name}-{buyerProductList[k].price}");
                summa += buyerProductList[k].price;
            }
            Console.WriteLine($"Summa: {summa}");
            Console.WriteLine("-------------------------");
        }
    }
}
