using mtgtools.Models.Abilities;
using mtgtools.Models.Algorithms;
using mtgtools.Models.Effects;
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
        private int _NextMulliganCardCount;
        public Deck Deck { get; private set; }
        public int StartingLife { get; private set; }
        public int Life { get; private set; }
        public Library Library { get; private set; }
        public Hand Hand { get; private set; }
        public Graveyard Graveyard { get; private set; }
        public Exile Exile { get; private set; }
        public Battlefield Battlefield { get; private set; }
        public OutOfTheGame OutOfTheGame { get; private set; }
        public IPlayerAI AI { get; private set; }
        public ManaPool ManaPool { get; set; }

        public bool CanPlayLand
        {
            get
            {
                return _LandPlayedThisTurn < _LandCountAllowedToPlayEachTurn
                    && Hand.HasLand;
            }
        }

        public Player(Deck deck, IPlayerAI playerAI, int startingLife = 20, int firstMulligan = 6)
        {
            _LandCountAllowedToPlayEachTurn = 1;
            _NextMulliganCardCount = firstMulligan;
            Deck = deck ?? throw new ArgumentNullException();
            // 103.3 Each player begins the game with a starting life total of 20.
            StartingLife = startingLife;
            Life = StartingLife;
            // 103.1 At the start of a game, the player's decks become their libraries.
            Library = new Library(Deck.Cards);
            Hand = new Hand();
            Graveyard = new Graveyard();
            Exile = new Exile();
            Battlefield = new Battlefield();
            OutOfTheGame = new OutOfTheGame();
            AI = playerAI ?? throw new ArgumentNullException();
            AI.Player = this; // TODO : Can we do without this back reference?
        }

        public void ShuffleLibrary()
        {
            Library.Shuffle();
        }

        public void TakeMulligan()
        {
            // 103.4 A player who is dissatisfied with his or her initial hand 
            // may take a mulligan.
            Library = new Library(Deck.Cards);
            ShuffleLibrary();
            Hand = new Hand();
            Draw(_NextMulliganCardCount);
            _NextMulliganCardCount--;
        }

        public void Draw(int cardCount)
        {
            for (int i = 0; i < cardCount; i++)
            {
                Hand.Cards.Add(Library.Draw());
            }
        }

        public void TakeTurn(int turn, bool skipDrawingPhase)
        {
            // TODO : 500.1. A turn consists of five phases, in this order: 
            // - beginning, 
            // - precombat main, 
            // - combat, 
            // - postcombat main, 
            // - ending.

            StartTheTurn();
            var cardToPlay = AI.ChooseCard();
            while (cardToPlay != null)
            {
                Play(cardToPlay);
                cardToPlay = AI.ChooseCard();
            }
            PassTheTurn();
        }

        public void StartTheTurn()
        {
            _LandPlayedThisTurn = 0;
            // XXX Remove summoning sickness :
            foreach (var creature in Battlefield.Creatures())
            {
                var ssaList = creature.Abilities.Where(a => a.GetType() == typeof(SummoningSicknessStaticAbility)).ToList();
                foreach (var ssa in ssaList)
                {
                    creature.Abilities.Remove(ssa);
                }
            }
        }

        public void Play(Card card)
        {
            // TODO : play a card from another zone than the Hand...
            if (Hand.Pop(card))
            {
                if (card.IsALand && CanPlayLand)
                {
                    _LandPlayedThisTurn++;
                    Battlefield.Enter(card);
                }
                else if (CanPayManaCost(card))
                {
                    PayManaCost(card);
                    Battlefield.Enter(card);
                }
                else
                {
                    // The card cannot be played, 
                    // put it back in the hand
                    // (this is not meant to happen):
                    Hand.Push(card);
                }
            }
        }

        public AvailableMana GetAvailableMana()
        {
            var availableMana = new AvailableMana();

            foreach (var cardInHand in Hand.Cards)
            {
                availableMana.Add(cardInHand.GetAbility<ManaActivatedAbility>().GetEffect<AddToManaPoolEffect>().AvailableMana);
            }
            foreach (var cardOnTheBattlefield in Battlefield.Cards.Where(c => !c.HasAbility<SummoningSicknessStaticAbility>()))
            {
                availableMana.Add(cardOnTheBattlefield.GetAbility<ManaActivatedAbility>().GetEffect<AddToManaPoolEffect>().AvailableMana);
            }

            return availableMana;
        }

        private bool CanPayManaCost(Card card)
        {
            bool canPay = false;

            if (card.Cmc == 0)
            {
                canPay = true;
            }
            else if (GetAvailableMana().IsEnoughFor(card.TypedManaCost))
            {
                canPay = true;
            }
            // TODO : manage X costs...

            return canPay;
        }

        private void PayManaCost(Card card)
        {
            // TODO : PayManaCost
        }

        public void PassTheTurn()
        {
        }

        public void RemoveFromTheGame(Card card)
        {
            Library.Cards.Remove(card);
            Hand.Cards.Remove(card);
            Graveyard.Cards.Remove(card);
            Exile.Cards.Remove(card);
            Battlefield.Cards.Remove(card);
            OutOfTheGame.Cards.Add(card);
        }
    }
}