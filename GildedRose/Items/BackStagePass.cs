using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Items
{
    public class BackstagePass : Item
    {
        public BackstagePass(Int32 Quality, Int32 SellIn)
        {
            this.Name = "Backstage passes to a TAFKAL80ETC concert";
            this.Quality = Quality;
            this.SellIn = SellIn;
        }

        public override void Update()
        {
            IncrementQuality(1);

            if (SellIn < 11)
                IncrementQuality(1);

            if (SellIn < 6)
                IncrementQuality(1);

            DecrementSellIn(1);

            if (SellIn < 0)
                Quality -= Quality;
        }
    }
}
