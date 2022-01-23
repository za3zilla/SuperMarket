using System;

namespace SuperMarket.Entities.Rules
{
    public class CountRule : IRule
    {
        public CountRule(string name, int unit, decimal price)
        { 
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Unit = unit;
            this.Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public decimal GetPrice(decimal itemPrice, int itemCount)
        {
            return (itemCount / this.Unit) * this.Price + (itemCount % this.Unit) * itemPrice;
        }
    }
}
