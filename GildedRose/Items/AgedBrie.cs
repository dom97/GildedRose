using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Items
{
    public class AgedBrie : Item
    {
        public AgedBrie(Int32 Quality, Int32 SellIn)
        {
            this.Name = "Aged Brie";
            this.Quality = Quality;
            this.SellIn = SellIn;
        }

        public override void Update()
        {
            IncrementQuality(1);
            DecrementSellIn(1);

            if (SellIn < 0)
                IncrementQuality(1);
        }
    }
}
