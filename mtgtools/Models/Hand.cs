using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class Hand : CardSetBase, ICardSet
    {
        public Hand() : base()
        { }

        public Hand(IList<Card> cards) : base(cards)
        { }
    }
}