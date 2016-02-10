using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Items
{
    public abstract class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
        protected void IncrementQuality(Int32 multiplier)
        {
            for (var i = 0; i < multiplier; i++)
            {
                if (Quality < 50)
                    Quality += 1;
                else
                    return;
            }
        }

        protected void DecrementQuality(Int32 multiplier)
        {
            for (var i = 0; i < multiplier; i++)
            {
                if (Quality > 0)
                    Quality -= 1;
                else
                    return;
            }            
        }

        protected void DecrementSellIn(Int32 multiplier)
        {
            SellIn = SellIn - multiplier;
        }

        public abstract void Update();
    }
}
