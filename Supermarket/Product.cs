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

        // Вес продуктв в грамммах, нужен для полок.
        public int weight;

        // Срок годности в днях.
        public int daysStored;

        // День началао хранения.
        public DateTime dateStartStored;

    }
}
