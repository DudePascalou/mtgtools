using mtgtools.Models.Conditions;
using mtgtools.Models.Costs;
using mtgtools.Models.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models.Abilities
{
    public class DrawCardActivatedAbility : ActivatedAbilityBase, IActivatedAbility
    {
        public DrawCardActivatedAbility(ICost cost, IEffect effect) : base(new NoCondition(), cost, effect) { }
    }
}