using mtgtools.Models;
using mtgtools.Models.Abilities;
using mtgtools.Models.Algorithms;
using mtgtools.Models.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgtools.Tests.TestsModels
{
    /// <summary>
    /// <see cref="IPlayerAI"/> implementation 
    /// to choose a card to play for my Desolation Deck.
    /// </summary>
    class DesolationPlayerAI : IPlayerAI
    {
        public Player Player { get; set; }

        //private IDictionary<string, TypedMana> _AvailableManaInHandByName;
        //private IDictionary<string, TypedMana> _AvailableManaOnBattlefieldByName;

        public DesolationPlayerAI()
        {
            //_AvailableManaInHandByName = new Dictionary<string, TypedMana>
            //{
            //    { "Elvish Spirit Guide", TypedMana.Parse("{G}") }
            //};
            //_AvailableManaOnBattlefieldByName = new Dictionary<string, TypedMana>
            //{
            //    { "Magus of the Library", TypedMana.Parse("{C}") },
            //    { "Llanowar Elves", TypedMana.Parse("{G}") },
            //    { "Hedron Archive", TypedMana.Parse("{C}{C}") },
            //    // TODO :{ "Lotus Petal", TypedMana.Parse("{A}") },
            //    { "Island", TypedMana.Parse("{U}") },
            //    { "Forest", TypedMana.Parse("{G}") },
            //    { "Ghost Quarter", TypedMana.Parse("{C}") },
            //    { "Mishra's Factory", TypedMana.Parse("{C}") },
            //    { "Spawning Bed", TypedMana.Parse("{C}") },
            //    { "Unclaimed Territory", TypedMana.Parse("{C}") },
            //};
        }

        public Card ChooseCard()
        {
            // 1. Play Lotus Petal, if any :
            if (Player.Hand.Cards.Any(c => c.Name == "Lotus Petal"))
            {
                return Player.Hand.Cards.First(c => c.Name == "Lotus Petal");
            }
            // 2. Play a land, if any and possible :
            if (Player.CanPlayLand)
            {
                return ChooseLand();
            }
            // 3. Add player's available mana :
            var totalManaAvailable = Player.GetAvailableMana();
            // 4.5.6. Try to cast the most expensive card in hand or a ramp card, or a draw card :
            var sortedCards = Player.Hand.Cards
                .OrderByDescending(c => c.Cmc)
                .ThenByDescending(c => c.HasAbility<ManaActivatedAbility>())
                .ThenByDescending(c => c.HasAbility<DrawCardActivatedAbility>());
            foreach (var card in sortedCards)
            {
                if (totalManaAvailable.IsEnoughFor(card.TypedManaCost))
                {
                    return card;
                }
            }

            // TODO 7.Draw card

            return null;
        }

        private Card ChooseLand()
        {
            var lands = Player.Hand.Lands().ToList();
            if (lands.Count == 1)
            {
                // Only one land in hand :
                return Player.Hand.Cards.First(c => c.IsALand);
            }
            else if (lands.Select(c => c.Name).Distinct().Count() == 1)
            {
                // Same land :
                return Player.Hand.Cards.First(c => c.IsALand);
            }
            else
            {
                // TODO : Choose the best land to play :

                return null;
            }
        }
    }
}
