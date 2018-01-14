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
        /// <summary>
        /// 602.1. Activated abilities have a cost.
        /// </summary>
        ICost Cost { get; set; }
        /// <summary>
        /// 602.1. Activated abilities have an effect.
        /// </summary>
        IEffect Effect { get; set; }

        TCost GetCost<TCost>() where TCost : class, ICost;
        TEffect GetEffect<TEffect>() where TEffect : class, IEffect;

        /// <summary>
        /// 602.2. To activate an ability is to put it onto the stack and pay its costs, 
        /// so that it will eventually resolve and have its effect.
        /// </summary>
        void Activate();
    }
}