using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
  public  class Buyer
    {
        public List<Product> buyerProductList;
        //кошелек
        public int purse; //кошелек

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
            Console.WriteLine("List Products for 1 buyer:");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"My purse:{purse} grn");

            for (int k = 0; k <buyerProductList.Count; k++)
            {
                Console.WriteLine($"{k + 1} {buyerProductList[k].name}-{buyerProductList[k].price}");
                summa += buyerProductList[k].price;
                buyerProductList[k].quantity--;
            }
            Console.WriteLine($"Summa: {summa}");
            Console.WriteLine("-------------------------");

            if (summa > purse)
            {
                Console.WriteLine("You haven't got money for buy this list of products.");

                for (int k = 0; k < buyerProductList.Count; k++)
                {
                    Console.WriteLine($"{k + 1} {buyerProductList[k].name}-{buyerProductList[k].price}");
                    summa += buyerProductList[k].price;
                    buyerProductList[k].quantity++;
                }

            } else if (summa <= purse)
            {
                Console.WriteLine("Thank you for buy! See you then.");
                //можно как фичу вывести рандомно предсказание в чеке
            }
        }
    }
}
