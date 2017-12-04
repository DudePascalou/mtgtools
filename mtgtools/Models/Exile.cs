using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class Exile : CardSetBase, ICardSet
    {
        public Exile() : base()
        { }

        public Exile(IList<Card> cards) : base(cards)
        { }
    }
}