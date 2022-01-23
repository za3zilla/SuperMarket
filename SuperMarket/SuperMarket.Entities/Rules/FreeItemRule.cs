using System;

namespace SuperMarket.Entities.Rules
{
    public class FreeItemRule : IRule
    {
        public FreeItemRule(string name, int unit, int freeItemCount)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Unit = unit;
            this.FreeItemCount = freeItemCount;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public int FreeItemCount { get; set; }
        public decimal GetPrice(decimal itemPrice, int itemCount)
        {
            return ((itemCount / (this.Unit + this.FreeItemCount)) * this.Unit * itemPrice) 
                + ((itemCount % (this.Unit + this.FreeItemCount)) * itemPrice);
        }
    }
}
