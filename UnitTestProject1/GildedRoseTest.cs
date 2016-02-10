using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.Items;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    [TestClass]
    public class GildedRoseTest
    {
        private Item normalItem;
        private Item agedBrie;
        private Item backstagePass;
        private Item Sulfuras;
        private List<Item> Items;
        private ItemManager gildedRose;
        [TestInitialize]
        public void Initialize()
        {
            normalItem = new Gloves(20, 5);
            agedBrie = new AgedBrie(5, 5);
            backstagePass = new BackstagePass(30, 15);
            Sulfuras = new Sulfuras();
            Items = new List<Item>();
            Items.Add(normalItem);
            Items.Add(agedBrie);
            Items.Add(backstagePass);
            Items.Add(Sulfuras);
            gildedRose = new ItemManager(Items);
        }

        [TestMethod]
        public void TestNormalItemQualityDecay()
        {
            UpdateQualityXTimes(1);
            Assert.AreEqual(19, normalItem.Quality);
        }

        [TestMethod]
        public void TestNormalItemQualityDecayPastSellIn()
        {
            UpdateQualityXTimes(6);
            Assert.AreEqual(13, normalItem.Quality);
        }

        [TestMethod]
        public void TestNormalItemSellInDecay()
        {
            UpdateQualityXTimes(1);
            Assert.AreEqual(4, normalItem.SellIn);
        }

        [TestMethod]
        public void TestNormalItemSellInZero()
        {
            UpdateQualityXTimes(5);
            Assert.AreEqual(0, normalItem.SellIn);
        }

        [TestMethod]
        public void TestNormalItemZeroOrGreaterQuality()
        {
            UpdateQualityXTimes(21);
            Assert.AreEqual(0, normalItem.Quality);
        }

        [TestMethod]
        public void TestAgedBrieQualityIncrease()
        {
            UpdateQualityXTimes(1);
            Assert.AreEqual(6, agedBrie.Quality);
        }

        [TestMethod]
        public void TestAgedBrieQualityIncreaseAfterSellIn()
        {
            UpdateQualityXTimes(6);
            Assert.AreEqual(12, agedBrie.Quality);
        }

        [TestMethod]
        public void TestAgedBrieQualityCap()
        {
            UpdateQualityXTimes(50);
            Assert.AreEqual(50, agedBrie.Quality);
        }

        [TestMethod]
        public void TestAgedBrieSellInDecay()
        {
            UpdateQualityXTimes(1);
            Assert.AreEqual(4, agedBrie.SellIn);
        }

        [TestMethod]
        public void TestBackStagePassSellInDecay()
        {
            UpdateQualityXTimes(1);
            Assert.AreEqual(14, backstagePass.SellIn);
        }

        [TestMethod]
        public void TestBackstagePassQualityIncrease()
        {
            UpdateQualityXTimes(1);
            Assert.AreEqual(31, backstagePass.Quality);
        }

        [TestMethod]
        public void TestBackstagePassQualityIncrease10Daysleft()
        {
            UpdateQualityXTimes(6);
            Assert.AreEqual(37, backstagePass.Quality);
        }

        [TestMethod]
        public void TestBackstagePassQualityIncrease5Daysleft()
        {
            UpdateQualityXTimes(11);
            Assert.AreEqual(48, backstagePass.Quality);
        }

        [TestMethod]
        public void TestBackstagePassQualityCap()
        {
            UpdateQualityXTimes(13);
            Assert.AreEqual(50, backstagePass.Quality);
        }

        [TestMethod]
        public void TestBackstagePassQualityReset()
        {
            UpdateQualityXTimes(17);
            Assert.AreEqual(0, backstagePass.Quality);
        }

        [TestMethod]
        public void TestSulfurasNoQualityDecay()
        {
            UpdateQualityXTimes(1);
            Assert.AreEqual(80, Sulfuras.Quality);
        }

        private void UpdateQualityXTimes(Int32 days)
        {
            for (var i = 0; i < days; i++)
                gildedRose.UpdateQuality();
        }

    }
}
