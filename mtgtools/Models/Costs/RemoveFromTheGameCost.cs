using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Abilities;

namespace mtgtools.Models.Costs
{
    public class RemoveFromTheGameCost : CostBase, ICost
    {
        public override bool CanPay()
        {
            return Ability.Owner.OutOfTheGame.Cards.All(c => !c.Equals(Ability.Card));
        }

        public override ICost Clone()
        {
            return new RemoveFromTheGameCost();
        }

        public override void Pay()
        {
            if (CanPay())
            {
                Ability.Owner.RemoveFromTheGame(Ability.Card);
            }
        }
    }
}