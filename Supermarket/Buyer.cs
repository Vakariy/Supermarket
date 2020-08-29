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
    }
}
