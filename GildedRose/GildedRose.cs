using System;
using System.Collections.Generic;
using GildedRose;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (QualityCanDecrease(Items[i]))
                {
                    DecrementQuality(Items[i], 1);// for normal items
                }
                else // for aged brie and backstage passes
                {
                    if (Items[i].Quality < 50)
                    {
                        IncrementQuality(Items[i], 1);

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            IncrementBackstagePassBonus(Items[i]);
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0 && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                DecrementQuality(Items[i], 1);
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality; // quality becomes  0 if backstage pass
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            IncrementQuality(Items[i], 1);//incrememnt quality of aged brie
                        }
                    }
                }
            }
        }

        private bool QualityCanDecrease(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
                return true;

            return false;
        }

        private void IncrementQuality(Item item, Int32 multiplier)
        {
            item.Quality = item.Quality + multiplier;
        }

        private void DecrementQuality(Item item, Int32 multiplier)
        {
            item.Quality = item.Quality - multiplier;
        }

        private void IncrementBackstagePassBonus(Item item)
        {
            if (item.SellIn < 11 && item.Quality < 50)
            {
                IncrementQuality(item, 1);
            }

            if (item.SellIn < 6 && item.Quality < 50)
            {
                IncrementQuality(item, 1);
            }
        }

    }

}