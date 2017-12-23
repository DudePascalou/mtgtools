using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Abilities;
using mtgtools.Models.Zones;

namespace mtgtools.Models.Conditions
{
    public class IsInHandCondition : ICondition
    {
        public bool IsTrue { get { return Ability.Owner.Hand.Cards.Any(c => c.Equals(Ability.Card)); } }
        public IAbility Ability { get; set; }
    }
}