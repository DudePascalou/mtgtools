using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Services;
using mtgtools.Models;
using mtgtools.Tests.TestsModels;

namespace mtgtools.Tests.Services
{
    [TestClass]
    public class MtgStatisticsServiceTests
    {
        [TestMethod]
        //[Ignore("WIP")]
        public void CanComputePlayabilityStatistics()
        {
            var svc = new MtgCardService();
            //svc.LoadCardsDatabase();
            var deck = svc.ParseDeckListJson("Desolation", Format.Legacy, SampleDeckListsJson.Desolation);
            //var str = Newtonsoft.Json.JsonConvert.SerializeObject(deck.Cards);
            var statsSvc = new MtgStatisticsService();
            var playerAI = new DesolationPlayerAI();
            var player = new Player(deck, playerAI);

            statsSvc.ComputePlayabilityStatistics(deck, player, 8);
        }
    }
}
