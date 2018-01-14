using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Models;
using mtgtools.Models.Abilities;
using mtgtools.Models.Algorithms;
using mtgtools.Models.Conditions;
using mtgtools.Models.Costs;
using mtgtools.Models.Effects;
using mtgtools.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgtools.Tests.Models.Condition
{
    [TestClass]
    public class IConditionTests
    {
        [TestMethod]
        public void CanTellIsTrue()
        {
            // Arrange
            var cardSvc = new MtgCardService();
            var abilitySvc = new MtgAbilityService();
            var esg = cardSvc.ParseCardJson(CardSamples.ElvishSpiritGuide);
            var deck = new Deck("CanTellIsTrue", Format.None, new[] { esg });
            foreach (var card in deck.Cards) { abilitySvc.AffectAbilities(card); }
            var player = new Player(deck, new NoPlayerAI());

            // Act - Assert
            player.Draw(1);
            Assert.IsTrue(esg.GetAbility<ManaActivatedAbility>().Condition.IsTrue());

            // Act - Assert
            player.Hand.Pop(esg);
            player.Battlefield.Enter(esg);
            Assert.IsFalse(esg.GetAbility<ManaActivatedAbility>().Condition.IsTrue());
        }
    }
}
