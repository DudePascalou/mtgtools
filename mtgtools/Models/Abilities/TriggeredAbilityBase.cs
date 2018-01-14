using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Effects;
using mtgtools.Models.Conditions;

namespace mtgtools.Models.Abilities
{
    public abstract class TriggeredAbilityBase : AbilityBase, ITriggeredAbility
    {
        public override bool IsAManaAbility { get { return false; } }
        public IEffect Effect { get; set; }
        
        public TriggeredAbilityBase()
        { }
        public TriggeredAbilityBase(ICondition condition, IEffect effect) : base(condition)
        {
            Effect = effect;
        }

        public TEffect GetEffect<TEffect>() where TEffect : class, IEffect
        {
            return Effect as TEffect;
        }
    }
}