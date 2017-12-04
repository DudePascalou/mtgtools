using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class Game
    {
        public IList<Player> Players { get; set; }

        public Game(params Player[] players)
        {
            if (players == null) { throw new ArgumentNullException("players"); }

            Players = players.ToList();
        }

        public void Start()
        {
            // 103.4 Each player draws a number of cards equal to his or her starting hand size, which is normally seven.
            foreach (var player in Players)
            {
                for (int i = 0; i < 7; i++)
                {
                    player.Hand.Cards.Add(player.Library.Draw());
                }
            }
        }

    }
}