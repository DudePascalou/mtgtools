using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mtgtools.Models
{
    /// <summary>
    /// A deck of Magic The Gathering © cards.
    /// </summary>
    public class Deck
    {
        public string Name { get; set; }
        public ICollection<Card> MainCards { get; set; }
        public ICollection<Card> SideboardCards { get; set; }
        public Format Format { get; set; }

        public Deck(string name, Format format)
        {
            Name = name;
            Format = format;
            MainCards = new Collection<Card>();
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
                MainCards.Add(card);
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
            return string.Format("{0} ({1}, {2} cards)", Name, Format, MainCards.Count);
        }
    }
}