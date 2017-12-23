using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models.Algorithms
{
    public class NoPlayerAI : IPlayerAI
    {
        public Player Player { get; set; }

        public Card ChooseCard() { return null; }
    }
}