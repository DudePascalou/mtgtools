using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Conditions;

namespace mtgtools.Models.Abilities
{
    public class FlyingStaticAbility : StaticAbilityBase, IStaticAbility
    {
        public override bool IsAManaAbility { get { return false; } }

        public FlyingStaticAbility()
        { }
        public FlyingStaticAbility(ICondition condition) : base(condition)
        { }

        public override IAbility Clone()
        {
            return new FlyingStaticAbility(Condition.Clone());
        }
    }
}