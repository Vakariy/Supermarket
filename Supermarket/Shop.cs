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

        public void Start()
        {

        }
    }
}
