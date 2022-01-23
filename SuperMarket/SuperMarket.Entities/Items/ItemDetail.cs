using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Entities.Items
{
    public class ItemDetail
    {
        public Item Item { get; set; }
        public int Count { get; set; }

        public ItemDetail(Item item, int count)
        {
            this.Item = item;
            this.Count = count;
        }

        public decimal GetCost()
        {
            return Item.GetTotalPrice(this.Count);
        }
    }
}
