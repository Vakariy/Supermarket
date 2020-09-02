using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
public class Product
    {
        public string name;
        public int price;
        public int quantity;
        public string status = "OK"; //для срока годности, если СГ истек, то статус = "NON"

        // Вес продуктв в граммах, нужен для полок.
        public int weight;

        // Номер полки - зависит от веса продукта.
        public int numberShelf;

        // Срок годности в днях.
        public int daysStored;

        // День начала хранения.
        public DateTime dateStartStored;
     
        public Product() { }
        public Product(string name, int price, int weight, int daysStored) 
        {
            this.name = name;
            this.price = price;
            quantity = 1;

            this.weight = weight;
            if (weight > 0 && weight < 500)
            {
                numberShelf = 1;
            }
            else if (weight >= 500 && weight <= 1000)
            {
                numberShelf = 2;
            }
            else if (weight > 1000)
            {
                numberShelf = 3;
            }

            this.daysStored = daysStored;
            this.dateStartStored = Shop.dateInShop;
        }
    }
}
