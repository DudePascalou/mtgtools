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
        [Ignore("TODO")] // TODO : Manage aftermath cards...
        public void CanFindByName_WithAftermath()
        {
            var springToMind = MtgCardService.FindByName("Spring // Mind");

        }

        [TestMethod]
        public void CanParseDeckList()
        {
            // Act
            var deck = new MtgCardService().ParseDeckListJson("SimpleSample", Format.Legacy, SampleDeckListsJson.SimpleSample);

            // Assert
            Assert.AreEqual(28, deck.Cards.Count);
            Assert.AreEqual(17, deck.SideboardCards.Count);
        }

        [TestMethod]
        [Ignore("TODO")] // TODO : Manage aftermath cards...
        public void CanParseDeckList_WithAftermath()
        {
            // Act
            var deck = new MtgCardService().ParseDeckListJson("SampleWithAftermathLayout", Format.Legacy, SampleDeckListsJson.SampleWithAftermathLayout);

            // Assert
            Assert.AreEqual(1, deck.Cards.Count);
            Assert.AreEqual(0, deck.SideboardCards.Count);
        }

    }
}
