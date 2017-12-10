using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class Battlefield : CardSetBase, ICardSet
    {
        public Battlefield() : base()
        { }

        public Battlefield(IList<Card> cards) : base(cards)
        { }

        public void Enter(Card card)
        {
            Cards.Add(card);
        }
    }
}