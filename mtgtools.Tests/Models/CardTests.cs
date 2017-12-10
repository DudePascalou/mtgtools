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
    public class CardTests
    {
        [TestMethod]
        public void CanTellIsAnArtifact()
        {
            // Arrange
            var artifact = MtgCardService.ParseCard(CardSamples.JsonArtifact);

            // Act - Assert
            Assert.IsTrue(artifact.IsAnArtifact);
            Assert.IsFalse(artifact.IsACreature);
            Assert.IsFalse(artifact.IsAnEnchantment);
            Assert.IsFalse(artifact.IsAnInstant);
            Assert.IsFalse(artifact.IsALand);
            Assert.IsFalse(artifact.IsAPlaneswalker);
            Assert.IsFalse(artifact.IsASorcery);
        }

        [TestMethod]
        public void CanTellIsACreature()
        {
            // Arrange
            var creature = MtgCardService.ParseCard(CardSamples.JsonCreature);

            // Act - Assert
            Assert.IsFalse(creature.IsAnArtifact);
            Assert.IsTrue(creature.IsACreature);
            Assert.IsFalse(creature.IsAnEnchantment);
            Assert.IsFalse(creature.IsAnInstant);
            Assert.IsFalse(creature.IsALand);
            Assert.IsFalse(creature.IsAPlaneswalker);
            Assert.IsFalse(creature.IsASorcery);
        }

        [TestMethod]
        public void CanTellIsAnEnchantment()
        {
            // Arrange
            var enchantment = MtgCardService.ParseCard(CardSamples.JsonEnchantment);

            // Act - Assert
            Assert.IsFalse(enchantment.IsAnArtifact);
            Assert.IsFalse(enchantment.IsACreature);
            Assert.IsTrue(enchantment.IsAnEnchantment);
            Assert.IsFalse(enchantment.IsAnInstant);
            Assert.IsFalse(enchantment.IsALand);
            Assert.IsFalse(enchantment.IsAPlaneswalker);
            Assert.IsFalse(enchantment.IsASorcery);
        }

        [TestMethod]
        public void CanTellIsAnInstant()
        {
            // Arrange
            var instant = MtgCardService.ParseCard(CardSamples.JsonInstant);

            // Act - Assert
            Assert.IsFalse(instant.IsAnArtifact);
            Assert.IsFalse(instant.IsACreature);
            Assert.IsFalse(instant.IsAnEnchantment);
            Assert.IsTrue(instant.IsAnInstant);
            Assert.IsFalse(instant.IsALand);
            Assert.IsFalse(instant.IsAPlaneswalker);
            Assert.IsFalse(instant.IsASorcery);
        }

        [TestMethod]
        public void CanTellIsALand()
        {
            // Arrange
            var land = MtgCardService.ParseCard(CardSamples.JsonLand);

            // Act - Assert
            Assert.IsFalse(land.IsAnArtifact);
            Assert.IsFalse(land.IsACreature);
            Assert.IsFalse(land.IsAnEnchantment);
            Assert.IsFalse(land.IsAnInstant);
            Assert.IsTrue(land.IsALand);
            Assert.IsFalse(land.IsAPlaneswalker);
            Assert.IsFalse(land.IsASorcery);
        }

        [TestMethod]
        public void CanTellIsAPlaneswalker()
        {
            // Arrange
            var planeswalker = MtgCardService.ParseCard(CardSamples.JsonPlaneswalker);

            // Act - Assert
            Assert.IsFalse(planeswalker.IsAnArtifact);
            Assert.IsFalse(planeswalker.IsACreature);
            Assert.IsFalse(planeswalker.IsAnEnchantment);
            Assert.IsFalse(planeswalker.IsAnInstant);
            Assert.IsFalse(planeswalker.IsALand);
            Assert.IsTrue(planeswalker.IsAPlaneswalker);
            Assert.IsFalse(planeswalker.IsASorcery);
        }

        [TestMethod]
        public void CanTellIsASorcery()
        {
            // Arrange
            var sorcery = MtgCardService.ParseCard(CardSamples.JsonSorcery);

            // Act - Assert
            Assert.IsFalse(sorcery.IsAnArtifact);
            Assert.IsFalse(sorcery.IsACreature);
            Assert.IsFalse(sorcery.IsAnEnchantment);
            Assert.IsFalse(sorcery.IsAnInstant);
            Assert.IsFalse(sorcery.IsALand);
            Assert.IsFalse(sorcery.IsAPlaneswalker);
            Assert.IsTrue(sorcery.IsASorcery);
        }
    }
}
