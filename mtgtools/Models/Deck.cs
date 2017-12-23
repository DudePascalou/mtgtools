using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mtgtools.Models
{
    /// <summary>
    /// A deck of Magic The Gathering © cards.
    /// </summary>
    public class Deck : CardSetBase, ICardSet
    {
        public string Name { get; set; }
        public ICollection<Card> SideboardCards { get; set; }
        public Format Format { get; set; }

        public Deck() : base()
        { }

        public Deck(IList<Card> cards) : base(cards)
        { }

        public Deck(string name, Format format) : this(name, format, new List<Card>())
        { }

        public Deck(string name, Format format, IList<Card> cards) : base(cards)
        {
            Name = name;
            Format = format;
            SideboardCards = new Collection<Card>();
        }

        public void Add(Card card, bool toSideboard = false)
        {
            if (toSideboard)
            {
                SideboardCards.Add(card);
            }
            else
            {
                Cards.Add(card);
            }
        }

        public void Add(Card card, int count, bool toSideboard = false)
        {
            for (int i = 0; i < count; i++)
            {
                Add(card, toSideboard);
            }
        }

        public bool IsLegal()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}, {2} cards)", Name, Format, Cards.Count);
        }
    }
}