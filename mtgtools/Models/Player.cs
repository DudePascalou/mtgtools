using mtgtools.Models.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class Player
    {
        private int _LandPlayedThisTurn;
        private int _LandCountAllowedToPlayEachTurn;
        private TypedMana _AvailableMana;
        public int Life { get; set; }
        public Library Library { get; set; }
        public Hand Hand { get; set; }
        public Graveyard Graveyard { get; set; }
        public Exile Exile { get; set; }
        public Battlefield Battlefield { get; set; }

        public Player(Deck startingDeck, int startingLife = 20)
        {
            _LandCountAllowedToPlayEachTurn = 1;
            // 103.3 Each player begins the game with a starting life total of 20.
            Life = startingLife;
            // 103.1 At the start of a game, the player's decks become their libraries.
            Library = new Library(startingDeck.Cards);
            Hand = new Hand();
            Graveyard = new Graveyard();
            Exile = new Exile();
            Battlefield = new Battlefield();
        }

        public void ShuffleLibrary()
        {
            Library.Shuffle();
        }

        public void TakeMulligan()
        {
            // TODO : 103.4 A player who is dissatisfied with his or her initial hand 
            // may take a mulligan.
        }

        public void Draw(int cardCount)
        {
            for (int i = 0; i < cardCount; i++)
            {
                Hand.Cards.Add(Library.Draw());
            }
        }

        public void StartTheTurn()
        {
            _LandPlayedThisTurn = 0;
        }

        public bool CanPlayLand()
        {
            return _LandPlayedThisTurn < _LandCountAllowedToPlayEachTurn
                && Hand.HasLand;
        }

        /// <summary>
        /// Put a card from the <see cref="Hand"/>
        /// on the <see cref="Battlefield"/>.
        /// </summary>
        /// <param name="card">Card to play.</param>
        public void Play(Card card)
        {
            if (Hand.Pop(card))
            {
                if (CanPayManaCost(card))
                {
                    PayManaCost(card);
                    Battlefield.Enter(card);
                }
                if (card.IsALand)
                {
                    _LandPlayedThisTurn++;
                }
            }
        }

        private bool CanPayManaCost(Card card)
        {
            bool canPay = false;
            if (card.Cmc == 0)
            {
                canPay = true;
            }
            else
            {

            }
            // TODO : manage X costs...
            return canPay;
        }

        private void PayManaCost(Card card)
        {
            throw new NotImplementedException();
        }

        //public void TakeTurn(int turn, bool skipDrawingPhase)
        //{
        //    // TODO : 500.1. A turn consists of five phases, in this order: beginning, precombat main, combat, postcombat main, and ending.
        //}

        public void PassTheTurn()
        {
        }

    }
}