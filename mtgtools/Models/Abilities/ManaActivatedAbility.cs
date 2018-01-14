﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mtgtools.Models.Costs;
using mtgtools.Models.Effects;
using mtgtools.Models.Conditions;

namespace mtgtools.Models.Abilities
{
    /// <summary>
    /// 605.1a An activated ability is a mana ability if it meets all of the following criteria: 
    /// - it doesn’t have a target, 
    /// - it could add mana to a player’s mana pool when it resolves, 
    /// - and it’s not a loyalty ability.
    /// </summary>
    public class ManaActivatedAbility : ActivatedAbilityBase, IActivatedAbility
    {
        public override bool IsAManaAbility { get { return true; } }

        public ManaActivatedAbility(ICondition condition, ICost cost, IEffect effect) : base(condition, cost, effect) { }
        public ManaActivatedAbility(ICost cost, IEffect effect) : base(new NoCondition(), cost, effect) { }

        public override IAbility Clone()
        {
            return new ManaActivatedAbility
            (
                Condition.Clone(),
                Cost.Clone(),
                Effect.Clone()
            );
        }
    }
}