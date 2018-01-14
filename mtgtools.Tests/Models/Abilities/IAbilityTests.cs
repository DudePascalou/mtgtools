using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Models.Abilities;
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
    public class IAbilityTests
    {
        [TestMethod]
        public void CanTellIsAManaAbility()
        {
            // Arrange - Act - Assert
            Assert.IsFalse(new DrawCardActivatedAbility(new TapCost(), new DrawCardEffect(1)).IsAManaAbility);
            Assert.IsFalse(new FlyingStaticAbility().IsAManaAbility);
            Assert.IsFalse(new HasteStaticAbility().IsAManaAbility);
            Assert.IsTrue(new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{C}")).IsAManaAbility);
            Assert.IsFalse(new SummoningSicknessStaticAbility().IsAManaAbility);
        }
    }
}
