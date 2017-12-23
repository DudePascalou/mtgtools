using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Effects;

namespace mtgtools.Models.Abilities
{
    public class TriggeredAbilityBase : AbilityBase, ITriggeredAbility
    {
        public IEffect Effect { get; set; }

        public TEffect GetEffect<TEffect>() where TEffect : class, IEffect
        {
            return Effect as TEffect;
        }
    }
}