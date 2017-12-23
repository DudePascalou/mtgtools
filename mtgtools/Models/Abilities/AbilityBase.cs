using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Conditions;

namespace mtgtools.Models.Abilities
{
    public abstract class AbilityBase : IAbility
    {
        public Player Owner { get; set; }
        public Card Card { get; set; }
        public ICondition Condition { get; set; }
        public bool IsLegal { get; set; }
        public bool IsAManaAbility { get; set; }

        public TCondition GetCondition<TCondition>() where TCondition : class, ICondition
        {
            return Condition as TCondition;
        }
    }
}