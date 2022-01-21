using System;

namespace SuperMarket.Entities.Items
{
    public class Item
    {
        public Item(string name,decimal price)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
