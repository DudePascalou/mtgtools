using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Services;
using mtgtools.Models;

namespace mtgtools.Tests.Services
{
    [TestClass]
    public class MtgServiceTests
    {
        private static readonly MtgService _Service = new MtgService();
        private static MtgService MtgService
        {
            get { return _Service; }
        }

        //[TestMethod]
        //public void CanConstructMtgService()
        //{
        //    var mtgSvc = new MtgService();
        //}


        [TestMethod]
        public void CanFindByName_WithAftermath()
        {
            var springToMind = MtgService.FindByName("Spring // Mind");

        }

        [TestMethod]
        public void CanParseDeckList()
        {
            // Act
            var deck = MtgService.ParseDeckList("SimpleSample", Format.Legacy, SampleDeckLists.SimpleSample);

            // Assert
            Assert.AreEqual(28, deck.MainCards.Count);
            Assert.AreEqual(17, deck.SideboardCards.Count);
        }

        [TestMethod]
        public void CanParseDeckList_WithAftermath()
        {
            // Act
            var deck = MtgService.ParseDeckList("SampleWithAftermathLayout", Format.Legacy, SampleDeckLists.SampleWithAftermathLayout);

            // Assert
            Assert.AreEqual(1, deck.MainCards.Count);
            Assert.AreEqual(0, deck.SideboardCards.Count);
        }

    }
}
