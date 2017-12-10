using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Models;
using mtgtools.Services;

namespace mtgtools.Tests.Models
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void CanStartGame()
        {
            // Arrange
            var deck = new MtgCardService().ParseDeckList("CanStartGame", Format.Legacy, SampleDeckLists.SimpleSample);
            var player = new Player(deck);
            var expectedStartingHand = 7;
            var expectedStartingLibrary = deck.Cards.Count - expectedStartingHand;

            // Act
            player.Draw(expectedStartingHand);

            // Assert
            Assert.AreEqual(expectedStartingHand, player.Hand.Cards.Count);
            Assert.AreEqual(expectedStartingLibrary, player.Library.Cards.Count);
        }
    }
}
