using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class OutOfTheGame : CardSetBase, ICardSet
    {
        public OutOfTheGame() : base()
        { }

        public OutOfTheGame(IList<Card> cards) : base(cards)
        { }
    }
}