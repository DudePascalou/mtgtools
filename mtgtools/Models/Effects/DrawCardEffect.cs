﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models.Effects
{
    public class DrawCardEffect : EffectBase, IEffect
    {
        public int CardToDraw { get; set; }

        public DrawCardEffect(int cardToDraw)
        {
            CardToDraw = cardToDraw;
        }

        public override void Resolves()
        {
            Ability.Owner.Draw(CardToDraw);
        }
    }
}