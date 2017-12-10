using mtgtools.Models;
using mtgtools.Models.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgtools.Tests.TestsModels
{
    /// <summary>
    /// <see cref="IChoiceAlgorithm"/> implementation 
    /// to choose a land for my Desolation Deck.
    /// </summary>
    class DesolationChoiceAlgorithm : IChoiceAlgorithm
    {
        public Player Player { get; set; }
        
        public bool ChooseLand(out Card land)
        {
            throw new NotImplementedException();
        }
        
        public bool ChooseSpell(out Card spell)
        {
            throw new NotImplementedException();
        }
    }
}
