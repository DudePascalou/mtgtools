using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Abilities;

namespace mtgtools.Models.Costs
{
    public class TapCost : CostBase, ICost
    {
        public override bool CanPay()
        {
            return Ability.Card.CanTap();
        }

        public override ICost Clone()
        {
            return new TapCost();
        }

        public override void Pay()
        {
            if (CanPay())
            {
                Ability.Card.Tap();
            }
        }
    }
}