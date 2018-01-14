using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Abilities;

namespace mtgtools.Models.Conditions
{
    public class IsOnBattlefieldCondition : ICondition
    {
        public IAbility Ability { get; set; }

        public bool IsTrue() { return Ability.Owner.Battlefield.Cards.Contains(Ability.Card); }

        public ICondition Clone()
        {
            return new IsOnBattlefieldCondition();
        }
    }
}