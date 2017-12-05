using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class CardSetBase : ICardSet
    {
        public IList<Card> Cards { get; set; }

        public CardSetBase() : this(new List<Card>())
        { }

        public CardSetBase(IList<Card> cards)
        {
            Cards = cards ?? throw new ArgumentNullException("cards");
        }
    }
}