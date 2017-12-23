using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Models;
using mtgtools.Services;
using mtgtools.Models.Abilities;

namespace mtgtools.Tests.Models
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CanTellIsAnArtifact()
        {
            // Arrange
            var artifact = new MtgCardService().ParseCardJson(CardSamples.JsonArtifact);

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
            var creature = new MtgCardService().ParseCardJson(CardSamples.JsonCreature);

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
            var enchantment = new MtgCardService().ParseCardJson(CardSamples.JsonEnchantment);

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
            var instant = new MtgCardService().ParseCardJson(CardSamples.JsonInstant);

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
            var land = new MtgCardService().ParseCardJson(CardSamples.JsonLand);

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
            var planeswalker = new MtgCardService().ParseCardJson(CardSamples.JsonPlaneswalker);

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
            var sorcery = new MtgCardService().ParseCardJson(CardSamples.JsonSorcery);

            // Act - Assert
            Assert.IsFalse(sorcery.IsAnArtifact);
            Assert.IsFalse(sorcery.IsACreature);
            Assert.IsFalse(sorcery.IsAnEnchantment);
            Assert.IsFalse(sorcery.IsAnInstant);
            Assert.IsFalse(sorcery.IsALand);
            Assert.IsFalse(sorcery.IsAPlaneswalker);
            Assert.IsTrue(sorcery.IsASorcery);
        }

        [TestMethod]
        public void CanTellHasAbility()
        {
            // Arrange
            var card = new Card();

            // Assert
            Assert.IsFalse(card.HasAbility<FlyingStaticAbility>());
            Assert.IsFalse(card.HasAbility<SummoningSicknessStaticAbility>());

            card.Abilities.Add(new SummoningSicknessStaticAbility());

            // Act - Assert
            Assert.IsFalse(card.HasAbility<FlyingStaticAbility>());
            Assert.IsTrue(card.HasAbility<SummoningSicknessStaticAbility>());
        }

        [TestMethod]
        public void CanGetAbility()
        {
            // Arrange
            var card = new Card();

            // Assert
            Assert.AreEqual(null, card.GetAbility<FlyingStaticAbility>());
            Assert.AreEqual(null, card.GetAbility<SummoningSicknessStaticAbility>());

            card.Abilities.Add(new SummoningSicknessStaticAbility());

            // Act - Assert
            Assert.AreEqual(null, card.GetAbility<FlyingStaticAbility>());
            Assert.IsInstanceOfType(card.GetAbility<SummoningSicknessStaticAbility>(), typeof(SummoningSicknessStaticAbility));
        }

    }
}
