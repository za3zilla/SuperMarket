using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMarket.Entities.Rules;

namespace SuperMarket.UnitTests.Rules
{
    [TestClass]
    public class RuleTests
    {
        [TestMethod]
        public void CountRuleShouldHaveData()
        {
            string name = "Three for a dollar";
            int unit = 3;
            decimal price = 1;

            CountRule rule = new CountRule(name, unit, price);

            //New rule created
            Assert.IsNotNull(rule);

            //Check that the rule has an unique identifier
            Assert.IsNotNull(rule.Id);

            //Check that the rule has the right name
            Assert.AreEqual(name, rule.Name);

            //Check that the unit has the right name
            Assert.AreEqual(unit, rule.Unit);

            //Check that the rule has the right price
            Assert.AreEqual(price, rule.Price);


            //Check the total price for 1 item
            decimal itemPrice = 0.65m;
            decimal expectedPrice = itemPrice;
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 1));

            //Check the total price for 3 items
            expectedPrice = 1m;
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 3));

            //Check the total price for 4 items
            expectedPrice += itemPrice;
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 4));
        }

        [TestMethod]
        public void WeightRuleShouldHaveData()
        {
            string name = "1 kilo for 1.99";
            decimal weight = 1;
            decimal itemWeight = 0.5m;
            decimal price = 1.99m;

            WeightRule rule = new WeightRule(name, weight, itemWeight, price);

            //New rule created
            Assert.IsNotNull(rule);

            //Check that the rule has an unique identifier
            Assert.IsNotNull(rule.Id);

            //Check that the rule has the right name
            Assert.AreEqual(name, rule.Name);

            //Check that the weight has the right name
            Assert.AreEqual(weight, rule.Weight);

            //Check that the itemWeight has the right name
            Assert.AreEqual(weight, rule.Weight);

            //Check that the rule has the right price
            Assert.AreEqual(price, rule.Price);


            //Check the total price for 1 item (0.5 Kilo)
            decimal itemPrice = 0.65m;
            decimal expectedPrice = itemPrice;
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 1));

            //Check the total price for 2 items (1 Kilo)
            expectedPrice = 1.99m;
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 2));

            //Check the total price for 3 items (1.5 Kilo)
            expectedPrice += itemPrice;
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 3));
        }

        [TestMethod]
        public void FreeItemRuleShouldHaveData()
        {
            string name = "Buy 2 get 1 free";
            int unit = 2;
            int freeItemCount = 1;

            FreeItemRule rule = new FreeItemRule(name, unit, freeItemCount);

            //New rule created
            Assert.IsNotNull(rule);

            //Check that the rule has an unique identifier
            Assert.IsNotNull(rule.Id);

            //Check that the rule has the right name
            Assert.AreEqual(name, rule.Name);

            //Check that the unit has the right name
            Assert.AreEqual(unit, rule.Unit);

            //Check that the freeItemCount has the right name
            Assert.AreEqual(freeItemCount, rule.FreeItemCount);


            //Check the total price for 1 item
            decimal itemPrice = 0.65m;
            decimal expectedPrice = itemPrice;
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 1));

            //Check the total price for 2 items
            expectedPrice += itemPrice;
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 2));

            //Check the total price for 3 items
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 3));

            //Check the total price for 4 items
            expectedPrice += itemPrice;
            Assert.AreEqual(expectedPrice, rule.GetPrice(itemPrice, itemCount: 4));
        }
    }
}
