﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Stock
    {
        public List<Product> stockProductList = new List<Product>();

        public Stock()
        {
            // name, price,  weight, daysStored
            stockProductList.Add(new Product("Jogurt", 18, 300, 3));
            stockProductList.Add(new Product("Сroissant", 18, 100, 10));
            stockProductList.Add(new Product("Ice cream", 20, 100, 60));
            stockProductList.Add(new Product("Сhips", 20, 50, 30));

            stockProductList.Add(new Product("Milk", 25, 1000, 3));
            stockProductList.Add(new Product("Сookies", 70, 1000, 10));
            stockProductList.Add(new Product("Sausage", 250, 1000, 15));

            stockProductList.Add(new Product("Pizza", 250, 1500, 1));
            stockProductList.Add(new Product("Watermelon", 60, 6000, 7));
            stockProductList.Add(new Product("Flour", 30, 2000, 60));
        }
    }
}
