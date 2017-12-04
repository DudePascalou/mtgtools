using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class Graveyard : CardSetBase, ICardSet
    {
        public Graveyard() : base()
        { }

        public Graveyard(IList<Card> cards) : base(cards)
        { }
    }
}