using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
  public class Buyer
    {

        public List<Product> buyerProductList;
        Shop Shop = new Shop();
        public int purse; //кошелек
        public int amountOfBuyers = 0;

        public Buyer()
        {
            buyerProductList = new List<Product>();
            Random random = new Random();
            purse = random.Next(200, 500);
        }


        //генерация чека для покупателя
        public int GenerationCheckForBayer()
        {
            int summa = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("************************");
            Console.WriteLine("List Products for 1 buyer:");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"My purse:{purse} grn");

            for (int k = 0; k < buyerProductList.Count; k++)
            {
                Console.WriteLine($"{k + 1} {buyerProductList[k].name}-{buyerProductList[k].price}");
                

                if (buyerProductList[k].quantity > 0)
                {
                    summa += buyerProductList[k].price;
                    buyerProductList[k].quantity--;

                } else if(buyerProductList[k].quantity < 1)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red; // устанавливаем 
                    Console.WriteLine("Sorry Dear client!");
                    Console.WriteLine("Product such as: " + buyerProductList[k].name + " out of stock!");
                    Console.ResetColor(); // сбрасываем в стандартный
                }
            }

            Console.WriteLine($"Summa: {summa}");
            Console.WriteLine("-------------------------");
            

            if (summa > purse)
            {
                Console.ForegroundColor = ConsoleColor.Red; // устанавливаем 
                Console.WriteLine("You haven't got money for buy this list of products: ");

                for (int k = 0; k < buyerProductList.Count; k++)
                {
                    Console.WriteLine($"{k + 1} {buyerProductList[k].name}-{buyerProductList[k].price}");
                    
                    if (buyerProductList[k].quantity >= 0 )
                    {
                        buyerProductList[k].quantity++;
                    }
                    
                }
                Console.WriteLine();
                Console.WriteLine("Key Enter for continue...");
                Console.ReadKey();
                Console.ResetColor(); // сбрасываем в стандартный
                return 0;

            } else if (summa <= purse)
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for buy! See you then.");
                amountOfBuyers++;
                Console.WriteLine();
                Console.WriteLine("Key Enter for continue...");
                Console.ReadKey();
                return 1;
                //можно как фичу вывести рандомно предсказание в чеке
            }
           
            return 0;

        }
    }   
}
