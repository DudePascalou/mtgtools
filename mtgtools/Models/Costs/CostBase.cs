using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Abilities;

namespace mtgtools.Models.Costs
{
    public abstract class CostBase : ICost
    {
        public IAbility Ability { get; set; }
        public abstract bool CanPay();
        public abstract void Pay();
        public abstract ICost Clone();
    }
}