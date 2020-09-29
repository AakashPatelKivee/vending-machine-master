using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class total
    {
        //public int quantity { get; set; }
        public void totalamount()
        {
            decimal Qut;
            decimal Total;
            decimal mult, price;
           // decimal itemsRemaining;
            Console.WriteLine("Enter Quantity");
            Qut = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter price");
            //Console.WriteLine("Enter Value of price\n");
            price = Convert.ToDecimal(Console.ReadLine());
            //itemsRemaining = Convert.ToDecimal(Console.ReadLine());
            mult = Qut * price;
            Console.WriteLine("The Multiplication of {0} and {1} = {2}\n", price, Qut, mult);
            Total = mult;
            Console.WriteLine("The Total is ", Total);
        }
    }
}
