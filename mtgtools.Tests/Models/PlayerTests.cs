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

        [TestMethod]
        public void CanGetAvailableMana()
        {
            // Arrange
            //Bane of Bala Ged    {7}
            //Thought - Knot Seer   {3}{C}
            //Elvish Spirit Guide {2}{G}
            //Magus of the Library    {G}{G}
            //Forest
            //Ghost Quarter
            //Spawning Bed
            var svc = new MtgCardService();
            var deck = svc.ParseDeckListJson("CanGetAvailableMana", Format.None, SampleDeckListsJson.CanGetAvailableMana);
            var abilitySvc = new MtgAbilityService();
            foreach (var card in deck.Cards)
            {
                abilitySvc.AffectAbilities(card);
            }
            var playerAI = new NoPlayerAI();
            var player = new Player(deck, playerAI);
            player.ShuffleLibrary();
            player.Draw(7);
            var expectedAvailableMana = new AvailableMana();

            // Act
            var actualAvailableMana = player.GetAvailableMana();

            // Assert
            Assert.AreEqual("AT:0-AC:0-C:0-W:0-U:0-B:0-R:0-G:1", actualAvailableMana.ToString());

            // Arrange
            var forest = player.Hand.Get("Forest");
            player.Play(forest);

            // Act
            actualAvailableMana = player.GetAvailableMana();

            // Assert
            Assert.AreEqual("AT:0-AC:0-C:0-W:0-U:0-B:0-R:0-G:2", actualAvailableMana.ToString());

            // Arrange
            var magus = player.Hand.Cards.First(c => c.Name == "Magus of the Library");
            player.Play(magus); // Use Forest & Elvish Spirit Guide

            // Act
            actualAvailableMana = player.GetAvailableMana();

            // Assert
            Assert.AreEqual("AT:0-AC:0-C:0-W:0-U:0-B:0-R:0-G:0", actualAvailableMana.ToString());

            // Arrange
            player.PassTheTurn();
            player.StartTheTurn();

            // Act
            actualAvailableMana = player.GetAvailableMana();

            // Assert
            Assert.AreEqual("AT:0-AC:0-C:1-W:0-U:0-B:0-R:0-G:1", actualAvailableMana.ToString());

            // Arrange
            var ghostQuarter = player.Hand.Cards.First(c => c.Name == "Ghost Quarter");
            player.Play(ghostQuarter);

            // Act
            actualAvailableMana = player.GetAvailableMana();

            // Assert
            Assert.AreEqual("AT:0-AC:0-C:2-W:0-U:0-B:0-R:0-G:1", actualAvailableMana.ToString());

        }

        [TestMethod]
        public void CanPayManaCost()
        {
            // Arrange
            var svc = new MtgCardService();
            var deck = svc.ParseDeckListJson("CanPayManaCost", Format.None, SampleDeckListsJson.Desolation);
            var abilitySvc = new MtgAbilityService();
            foreach (var card in deck.Cards)
            {
                abilitySvc.AffectAbilities(card);
            }
            var playerAI = new NoPlayerAI();
            var player = new Player(deck, playerAI);

            // Act

            // Assert

        }
    }
}
