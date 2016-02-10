using System;
using System.Collections.Generic;
using GildedRose.Items;

namespace GildedRoseKata
{
    public class ItemManager
    {
        IList<Item> Items;
        public ItemManager(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
                item.Update();
        }
    }
}