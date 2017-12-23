using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Costs;
using mtgtools.Models.Effects;

namespace mtgtools.Models.Abilities
{
    /// <summary>
    /// Interface that defines an activated ability (602).
    /// </summary>
    public interface IActivatedAbility : IAbility
    {
        ICost Cost { get; set; }
        IEffect Effect { get; set; }

        TCost GetCost<TCost>() where TCost : class, ICost;
        TEffect GetEffect<TEffect>() where TEffect : class, IEffect;
    }
}