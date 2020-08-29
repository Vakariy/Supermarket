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

        // Вес продуктв в граммах, нужен для полок.
        public int weight;

        // Номер полки - зависит от веса продукта.
        public int numberShelf;

        // Срок годности в днях.
        public int daysStored;

        // День начала хранения.
        public DateTime dateStartStored;     
    }
}
