using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMarket.Entities.Items;

namespace SuperMarket.UnitTests.Items
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void ItemShouldHaveData()
        {
            string itemName = "can of beans";
            decimal itemPrice = 0.65m;
            Item item = new Item(itemName, itemPrice);

            //New item created
            Assert.IsNotNull(item);

            //Check that the item has an unique identifier
            Assert.IsNotNull(item.Id);

            //Check that the item has the right name
            Assert.AreEqual(itemName, item.Name);

            //Check that the item has the right price
            Assert.AreEqual(itemPrice, item.Price);

        }

        [TestMethod]
        public void ItemShouldNotHaveSameId()
        {
            Item firstItem = new Item("can of beans", 0.65m);
            Item secondItem = new Item("can of soda", 0.95m);

            Assert.AreNotEqual(firstItem.Id, secondItem.Id);
        }
    }
}
