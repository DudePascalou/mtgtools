using mtgtools.Models.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models.Abilities
{
    public class HasteStaticAbility : StaticAbilityBase, IStaticAbility
    {
        public override bool IsAManaAbility { get { return false; } }

        public HasteStaticAbility()
        { }
        public HasteStaticAbility(ICondition condition) : base(condition)
        { }

        public override IAbility Clone()
        {
            return new HasteStaticAbility(Condition.Clone());
        }
    }
}