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
    public class MtgCardServiceTests
    {
        private static readonly MtgCardService _Service = new MtgCardService();
        private static MtgCardService MtgCardService
        {
            get { return _Service; }
        }
        
        [TestMethod]
        public void CanFindByName_WithAftermath()
        {
            var springToMind = MtgCardService.FindByName("Spring // Mind");

        }

        [TestMethod]
        public void CanParseDeckList()
        {
            // Act
            var deck = MtgCardService.ParseDeckList("SimpleSample", Format.Legacy, SampleDeckLists.SimpleSample);

            // Assert
            Assert.AreEqual(28, deck.Cards.Count);
            Assert.AreEqual(17, deck.SideboardCards.Count);
        }

        [TestMethod]
        [Ignore("TODO")]
        public void CanParseDeckList_WithAftermath()
        {
            // Act
            var deck = MtgCardService.ParseDeckList("SampleWithAftermathLayout", Format.Legacy, SampleDeckLists.SampleWithAftermathLayout);

            // Assert
            Assert.AreEqual(1, deck.Cards.Count);
            Assert.AreEqual(0, deck.SideboardCards.Count);
        }

    }
}
