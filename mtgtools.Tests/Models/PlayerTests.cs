using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Models;
using mtgtools.Services;
using mtgtools.Models.Algorithms;

namespace mtgtools.Tests.Models
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void CanStartGame()
        {
            // Arrange
            var deck = new MtgCardService().ParseDeckListJson("CanStartGame", Format.Legacy, SampleDeckListsJson.SimpleSample);
            var player = new Player(deck, new NoPlayerAI());
            var expectedStartingHand = 7;
            var expectedStartingLibrary = deck.Cards.Count - expectedStartingHand;

            // Act
            player.Draw(expectedStartingHand);

            // Assert
            Assert.AreEqual(expectedStartingHand, player.Hand.Cards.Count);
            Assert.AreEqual(expectedStartingLibrary, player.Library.Cards.Count);
        }

        [TestMethod]
        public void CanTakeMulligan()
        {
            // Arrange
            var deck = new MtgCardService().ParseDeckListJson("CanTakeMulligan", Format.Legacy, SampleDeckListsJson.SimpleSample);
            var firstMulligan = 4;
            var player = new Player(deck, new NoPlayerAI(), 20, firstMulligan);

            // Act
            player.TakeMulligan();

            // Assert
            Assert.AreEqual(4, player.Hand.Cards.Count);
            Assert.AreEqual(deck.Cards.Count - 4, player.Library.Cards.Count);

            // Act
            player.TakeMulligan();

            // Assert
            Assert.AreEqual(3, player.Hand.Cards.Count);
            Assert.AreEqual(deck.Cards.Count - 3, player.Library.Cards.Count);

            // Act
            player.TakeMulligan();

            // Assert
            Assert.AreEqual(2, player.Hand.Cards.Count);
            Assert.AreEqual(deck.Cards.Count - 2, player.Library.Cards.Count);

            // Act
            player.TakeMulligan();

            // Assert
            Assert.AreEqual(1, player.Hand.Cards.Count);
            Assert.AreEqual(deck.Cards.Count - 1, player.Library.Cards.Count);

            // Act
            player.TakeMulligan();

            // Assert
            Assert.AreEqual(0, player.Hand.Cards.Count);
            Assert.AreEqual(deck.Cards.Count, player.Library.Cards.Count);

            // Act
            player.TakeMulligan();

            // Assert
            Assert.AreEqual(0, player.Hand.Cards.Count);
            Assert.AreEqual(deck.Cards.Count, player.Library.Cards.Count);
        }
    }
}
