﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Registr
    {
        


        public DateTime day;
        //  public Product product;
        public string name;
        public int quantity;
        public int price;

        public Registr()
        {

        }

        public Registr(DateTime day, string name, int quantity, int price)
        {
            this.day = day;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }
    }
}

    