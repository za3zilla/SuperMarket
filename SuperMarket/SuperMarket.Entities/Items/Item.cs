using SuperMarket.Entities.Rules;
using System;

namespace SuperMarket.Entities.Items
{
    public class Item
    {
        public Item(string name, decimal price)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IRule Rule { get; private set; }

        public void SetRule(IRule rule)
        {
            this.Rule = rule;
        }

        public decimal GetTotalPrice(int itemCount)
        {
            return this.Rule?.GetPrice(this.Price, itemCount) ?? itemCount * this.Price;
        }
    }
}
