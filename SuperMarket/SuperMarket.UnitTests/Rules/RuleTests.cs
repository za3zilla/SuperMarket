using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMarket.Entities.Rules;

namespace SuperMarket.UnitTests.Rules
{
    [TestClass]
    public class RuleTests : BaseTest
    {
        [TestMethod]
        public void CountRuleShouldHaveData()
        {
            //Create Three for a dollar rule
            string name;
            int unit;
            decimal price;
            CountRule rule = GetCountRule(out name, out unit, out price);

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
            //Create 1 kilo for 1.99 rule
            string name;
            decimal weight, price;
            WeightRule rule = GetWeightRule(out name, out weight, out price);

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
            //Create Buy 2 get 1 free rule
            string name;
            int unit, freeItemCount;
            FreeItemRule rule = GetFreeItemRule(out name, out unit, out freeItemCount);

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
