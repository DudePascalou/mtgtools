using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Models;
using mtgtools.Services;

namespace mtgtools.Tests.Models
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CanStartNewGame()
        {
            var deck = new MtgService().ParseDeckList("TODO", Format.Legacy, "TODO");
            var player = new Player(deck);
            var game = new Game(player);
            game.Start();

            // TODO Turns, PlayLand, CastSpells
        }
    }
}
