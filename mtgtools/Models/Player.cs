﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class Player
    {
        public int Life { get; set; }
        public Library Library { get; set; }
        public Hand Hand { get; set; }
        public Graveyard Graveyard { get; set; }
        public Exile Exile { get; set; }
        public Battlefield Battlefield { get; set; }

        public Player(Deck startingDeck, int startingLife = 20)
        {
            // 103.3 Each player begins the game with a starting life total of 20.
            Life = startingLife;
            // 103.1 At the start of a game, the player's decks become their libraries.
            Library = new Library(startingDeck.Cards);
            Hand = new Hand();
            Graveyard = new Graveyard();
            Exile = new Exile();
            Battlefield = new Battlefield();
        }

        public void TakeMulligan()
        {
            // TODO : 103.4 A player who is dissatisfied with his or her initial hand may take a mulligan.
        }
    }
}