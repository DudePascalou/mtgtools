using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Models;
using mtgtools.Models.Abilities;
using mtgtools.Models.Algorithms;
using mtgtools.Models.Conditions;
using mtgtools.Models.Costs;
using mtgtools.Models.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgtools.Tests.Models.Abilities
{
    [TestClass]
    public class ActivatedAbilityTests
    {
        [TestMethod]
        public void CanActivate()
        {
            // Arrange - Act - Assert
            var player = new Player(Deck.Empty, new NoPlayerAI());
            Assert.AreEqual("C:0-W:0-U:0-B:0-R:0-G:0", player.ManaPool.ToLongString());

            var activatedAbility = new ManaActivatedAbility(new NoCondition(), new TapCost(), new AddToManaPoolEffect("{C}"));
            activatedAbility.Card = Card.Fake;
            activatedAbility.Owner = player;
            activatedAbility.Activate();

            Assert.AreEqual("C:1-W:0-U:0-B:0-R:0-G:0", player.ManaPool.ToLongString());
        }
    }
}
