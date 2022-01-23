using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMarket.Entities.Items;
using SuperMarket.Entities.Rules;

namespace SuperMarket.UnitTests.Checkouts
{
    [TestClass]
    public class CheckoutTests : BaseTest
    {
        [TestMethod]
        public void CheckoutWithoutShouldHaveData()
        {
            //Create a can of beans item
            decimal itemPrice;
            Item item = GetItem(out _, out itemPrice);

            //Create an item detail
            int itemCount = 2;
            ItemDetail itemDetail = new ItemDetail(item, itemCount);

            //Create Checkout class to calculate the total cost
            Checkout checkout = new Checkout();
            checkout.AddItem(itemDetail);

            //Check the total cost
            decimal expectedPrice = itemPrice * itemCount;
            Assert.AreEqual(expectedPrice, checkout.GetTotalPrice(), $"Total price should be itemPrice x itemCount = {expectedPrice}");
        }

        [TestMethod]
        public void CheckoutWithShouldHaveData()
        {
            //Create a can of beans item
            Item item = GetItem(out _, out _);

            //Create Three for a dollar rule
            CountRule rule = GetCountRule(out _, out _, out _);
            item.SetRule(rule);

            //Create an item detail
            ItemDetail itemDetail = new ItemDetail(item, count: 3);

            //Create Checkout class to calculate the total cost
            Checkout checkout = new Checkout();
            checkout.AddItem(itemDetail);

            //Check the total cost
            Assert.AreEqual(1, checkout.GetTotalPrice(), "Total price should be 1$ dollar");
        }
    }
}
