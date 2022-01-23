using System;

namespace SuperMarket.Entities.Rules
{
    public interface IRule
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal GetPrice(decimal itemPrice, int ItemCount);
    }
}
