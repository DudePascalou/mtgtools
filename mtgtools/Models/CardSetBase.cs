using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class CardSetBase : ICardSet
    {
        public IList<Card> Cards { get; set; }
        public bool HasLand { get { return Cards.Any(c => c.IsALand); } }

        public CardSetBase() : this(new List<Card>())
        { }

        public CardSetBase(IList<Card> cards)
        {
            Cards = cards ?? throw new ArgumentNullException("cards");
        }

        public IEnumerable<Card> Artifacts()
        {
            return Cards.Where(c => c.IsAnArtifact);
        }

        public IEnumerable<Card> Creatures()
        {
            return Cards.Where(c => c.IsACreature);
        }

        public IEnumerable<Card> Enchantments()
        {
            return Cards.Where(c => c.IsAnEnchantment);
        }

        public IEnumerable<Card> Instants()
        {
            return Cards.Where(c => c.IsAnInstant);
        }

        public IEnumerable<Card> Lands()
        {
            return Cards.Where(c => c.IsALand);
        }

        public IEnumerable<Card> Planeswalkers()
        {
            return Cards.Where(c => c.IsAPlaneswalker);
        }

        public IEnumerable<Card> Sorceries()
        {
            return Cards.Where(c => c.IsASorcery);
        }
    }
}