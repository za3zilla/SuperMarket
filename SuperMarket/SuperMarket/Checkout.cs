using SuperMarket.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public class Checkout
    {
        public List<ItemDetail> ItemDetails { get; private set; }

        public Checkout()
        {
            ItemDetails = new List<ItemDetail>();
        }

        public void AddItem(ItemDetail itemDetail)
        {
            ItemDetails.Add(itemDetail);
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0.0m;
            foreach (var itemDetail in ItemDetails)
                totalPrice += itemDetail.GetCost();

            return totalPrice;
        }
    }
}
