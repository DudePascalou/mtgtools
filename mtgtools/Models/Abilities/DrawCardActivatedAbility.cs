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
        public override bool IsAManaAbility { get { return false; } }
        public DrawCardActivatedAbility(ICondition condition, ICost cost, IEffect effect) : base(condition, cost, effect) { }
        public DrawCardActivatedAbility(ICost cost, IEffect effect) : base(new NoCondition(), cost, effect) { }

        public override IAbility Clone()
        {
            return new DrawCardActivatedAbility
            (
                Condition.Clone(),
                Cost.Clone(),
                Effect.Clone()
            );
        }
    }
}