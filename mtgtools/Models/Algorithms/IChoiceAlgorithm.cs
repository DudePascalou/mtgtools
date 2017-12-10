using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgtools.Models.Algorithms
{
    public interface IChoiceAlgorithm
    {
        Player Player { get; set; }
        /// <summary>
        /// Choose a land to play.
        /// </summary>
        /// <returns></returns>
        bool ChooseLand(out Card land);
        /// <summary>
        /// Choose a spell to play.
        /// </summary>
        /// <returns></returns>
        bool ChooseSpell(out Card spell);
    }
}
