using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Abilities;

namespace mtgtools.Models.Effects
{
    public class AddToManaPoolEffect : EffectBase, IEffect
    {
        public AvailableMana AvailableMana { get; private set; }

        public AddToManaPoolEffect(string rawMana)
        {
            AvailableMana = new AvailableMana(rawMana);
        }

        public override void Resolves()
        {
            Ability.Owner.ManaPool.Add(AvailableMana); // TODO : choose color or type, when required...
        }
    }
}