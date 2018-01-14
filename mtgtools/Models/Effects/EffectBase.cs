using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Abilities;

namespace mtgtools.Models.Effects
{
    public abstract class EffectBase : IEffect
    {
        public IAbility Ability { get; set; }
        public abstract void Resolves();
        public abstract IEffect Clone();
    }
}