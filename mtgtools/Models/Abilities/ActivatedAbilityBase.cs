using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Conditions;
using mtgtools.Models.Costs;
using mtgtools.Models.Effects;

namespace mtgtools.Models.Abilities
{
    public abstract class ActivatedAbilityBase : AbilityBase, IActivatedAbility
    {
        public ICost Cost { get; set; }
        public IEffect Effect { get; set; }

        public ActivatedAbilityBase(ICondition condition, ICost cost, IEffect effect)
        {
            Condition = condition;
            Condition.Ability = this;
            Cost = cost;
            Cost.Ability = this;
            Effect = effect;
            Effect.Ability = this;
        }

        public TCost GetCost<TCost>() where TCost : class, ICost
        {
            return Cost as TCost;
        }

        public TEffect GetEffect<TEffect>() where TEffect : class, IEffect
        {
            return Effect as TEffect;
        }
    }
}