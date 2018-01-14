using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Abilities;

namespace mtgtools.Models.Conditions
{
    public class NoCondition : ICondition
    {
        public IAbility Ability { get; set; }
        public bool IsTrue() { return true; }
        
        public ICondition Clone()
        {
            return new NoCondition();
        }
    }
}