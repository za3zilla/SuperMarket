using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMarket.Entities.Items;
using SuperMarket.Entities.Rules;

namespace SuperMarket.UnitTests.Items
{
    [TestClass]
    public class ItemTests : BaseTest
    {
        [TestMethod]
        public void ItemShouldHaveData()
        {
            //Create can of beans item
            string itemName;
            decimal itemPrice;
            Item item = GetItem(out itemName, out itemPrice);

            //New item created
            Assert.IsNotNull(item);

            //Check that the item has an unique identifier
            Assert.IsNotNull(item.Id);

            //Check that the item has the right name
            Assert.AreEqual(itemName, item.Name);

            //Check that the item has the right price
            Assert.AreEqual(itemPrice, item.Price);

            //Check that the item has the right total price without rules
            decimal expectedPrice = 2 * itemPrice;
            Assert.AreEqual(expectedPrice, item.GetTotalPrice(itemCount: 2));

            //Set a rule for the item
            CountRule rule = new CountRule(name: "Three for a dollar", unit: 3, price: 1);
            item.SetRule(rule);

            //Check that the item has the right total price with rule
            Assert.AreEqual(expectedPrice, item.GetTotalPrice(itemCount: 2));

            expectedPrice = 1;
            Assert.AreEqual(expectedPrice, item.GetTotalPrice(itemCount: 3));
        }

        [TestMethod]
        public void ItemShouldNotHaveSameId()
        {
            Item firstItem = new Item("can of beans", 0.65m);
            Item secondItem = new Item("can of soda", 0.95m);

            Assert.AreNotEqual(firstItem.Id, secondItem.Id);
        }

        [TestMethod]
        public void ItemDetailShouldHaveData()
        {
            //Create can of beans item
            decimal itemPrice;
            int itemCount = 2;
            Item item = GetItem(out _, out itemPrice);

            ItemDetail itemDetail = new ItemDetail(item, itemCount);

            //New itemDetail created
            Assert.IsNotNull(itemDetail);

            //Check that the item has the right cost
            decimal expectedPrice = 2 * itemPrice;
            Assert.AreEqual(expectedPrice, itemDetail.GetCost());
        }
    }
}
