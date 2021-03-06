﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Abilities;
using mtgtools.Models.Zones;

namespace mtgtools.Models.Conditions
{
    public class IsInHandCondition : ICondition
    {
        public IAbility Ability { get; set; }
        public bool IsTrue() { return Ability.Owner.Hand.Cards.Contains(Ability.Card); }

        public ICondition Clone()
        {
            return new IsInHandCondition();
        }
    }
}