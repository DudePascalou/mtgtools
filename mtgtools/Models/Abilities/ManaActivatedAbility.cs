using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Costs;
using mtgtools.Models.Effects;
using mtgtools.Models.Conditions;

namespace mtgtools.Models.Abilities
{
    public class ManaActivatedAbility : ActivatedAbilityBase, IActivatedAbility
    {
        public ManaActivatedAbility(ICondition condition, ICost cost, IEffect effect) : base(condition, cost, effect) { }
        public ManaActivatedAbility(ICost cost, IEffect effect) : base(new NoCondition(), cost, effect) { }
    }
}