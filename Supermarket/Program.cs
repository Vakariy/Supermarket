using System;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our supermarket!");
            Shop supermarket = new Shop();
            supermarket.Start();
        }
    }
}
