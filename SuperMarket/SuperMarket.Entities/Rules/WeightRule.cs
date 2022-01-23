using System;

namespace SuperMarket.Entities.Rules
{
    public class WeightRule : IRule
    {
        public WeightRule(string name, decimal weight, decimal itemWeight, decimal price)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Weight = weight;
            this.ItemWeight = itemWeight;
            this.Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal ItemWeight { get; set; }
        public decimal Price { get; set; }
        public decimal GetPrice(decimal itemPrice, int itemCount)
        {
            var totalItemsWeight = itemCount * this.ItemWeight;
            return Math.Truncate(totalItemsWeight / this.Weight) * this.Price 
                + ((totalItemsWeight % this.Weight) / this.ItemWeight) * itemPrice;
        }
    }
}
