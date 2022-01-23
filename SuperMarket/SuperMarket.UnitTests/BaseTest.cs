using SuperMarket.Entities.Items;
using SuperMarket.Entities.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.UnitTests
{
    public class BaseTest
    {
        public static Item GetItem(out string itemName, out decimal itemPrice)
        {
            itemName = "can of beans";
            itemPrice = 0.65m;
            return new Item(itemName, itemPrice);
        }

        public static CountRule GetCountRule(out string name, out int unit, out decimal price)
        {
            name = "Three for a dollar";
            unit = 3;
            price = 1;
            return new CountRule(name, unit, price);
        }

        public static WeightRule GetWeightRule(out string name, out decimal weight, out decimal price)
        {
            name = "1 kilo for 1.99";
            weight = 1;
            decimal itemWeight = 0.5m;
            price = 1.99m;
            return new WeightRule(name, weight, itemWeight, price);
        }

        public static FreeItemRule GetFreeItemRule(out string name, out int unit, out int freeItemCount)
        {
            name = "Buy 2 get 1 free";
            unit = 2;
            freeItemCount = 1;
            return new FreeItemRule(name, unit, freeItemCount);
        }
    }
}
