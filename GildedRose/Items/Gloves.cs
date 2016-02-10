using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Items
{
    public class Gloves : Item
    {
        public Gloves(Int32 Quality, Int32 SellIn)
        {
            this.Name = "Gloves";
            this.Quality = Quality;
            this.SellIn = SellIn;
        }

        public override void Update()
        {
            if (Quality > 0)
                DecrementQuality(1);

            DecrementSellIn(1);

            if (Quality > 0 && SellIn < 0)
                DecrementQuality(1);
        }
    }
}
