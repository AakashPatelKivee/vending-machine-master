namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class VendingItem
    {
        private string message;

        /// <summary>
        /// The name of the VendingItem
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The price of the VendingItem
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// How many of each VendingItem remains
        /// </summary>
        public int ItemsRemaining { get; set; }
     

        /// <summary>
        /// What the menu displays when the VendingItem is vended
        /// </summary>
        public string MessageWhenVended { get; set; }

        public string MessageWhenSoldOut { get; set; }

        public VendingItem()
        {

        }

        public VendingItem(string productName, decimal price, int itemsRemaining, int amount, string messageWhenVended)
        {
            this.ProductName = productName;
            this.Price = price;
            this.ItemsRemaining = itemsRemaining;
            this.MessageWhenVended = messageWhenVended;
            this.MessageWhenSoldOut = $"Sold out of {this.ProductName}!\nBuy something else!";
        }

        protected VendingItem(string productName, decimal price, int itemsRemaining, string message)
        {
            ProductName = productName;
            Price = price;
            ItemsRemaining = itemsRemaining;
            this.message = message;
        }

        /// <summary>
        /// Returns false if it can't get the item
        /// </summary>
        /// <returns>bool</returns>
        public bool RemoveItem()
            {
            if (this.ItemsRemaining > 0)
            {
                this.ItemsRemaining--;
                return true;
            }

            return false;
        }
    }
}
