using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class ManaPool
    {
        /// <summary>
        /// Colorless mana (that has specifically no color).
        /// </summary>
        public int Colorless { get; set; }
        public int White { get; set; }
        public int Blue { get; set; }
        public int Black { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }

        public bool CanPay(TypedMana typedMana)
        {
            return true;
            //return Colorless >= typedMana.Colorless
            //    && White >= typedMana.White
            //    && Blue >= typedMana.Blue
            //    && Black >= typedMana.Black
            //    && Red >= typedMana.Red
            //    && Green >= typedMana.Green
            //    && (X * XValue) >= (Cmc - typedMana.Cmc);
        }

        public void Pay(TypedMana typedMana)
        {
            // Pay typed mana first :
            Colorless -= typedMana.Colorless;
            White -= typedMana.White;
            Blue -= typedMana.Blue;
            Black -= typedMana.Black;
            Red -= typedMana.Red;
            Green -= typedMana.Green;
            // Pay generic mana second :

            // Pay X mana third :

        }

        public void Add(AvailableMana mana)
        {
            // TODO : AnyColor ?
            // TODO : AnyType ?
            Colorless += mana.Colorless;
            White += mana.White;
            Blue += mana.Blue;
            Black += mana.Black;
            Red += mana.Red;
            Green += mana.Green;
        }
    }
}