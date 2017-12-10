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
        [Ignore("WIP")]
        public void CanComputePlayabilityStatistics()
        {
            var deck = new MtgCardService().ParseDeckList("TODO", Format.Legacy, "TODO");
            var statsSvc = new MtgStatisticsService();
            var choiceAlgo = new DesolationChoiceAlgorithm();
            statsSvc.ComputePlayabilityStatistics(deck, choiceAlgo, 8);
        }
    }
}
