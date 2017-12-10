using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class TypedMana
    {
        private readonly string _RawMana;
        /// <summary>
        /// Generic mana ("unaware" of any type or color).
        /// </summary>
        public int Generic { get; set; }
        /// <summary>
        /// X mana cost.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Colorless mana (that has specifically no color).
        /// </summary>
        public int Colorless { get; set; }
        public int White { get; set; }
        public int Blue { get; set; }
        public int Black { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        /// <summary>
        /// Converted Mana Cost.
        /// </summary>
        public int Cmc { get { return Generic + Colorless + White + Blue + Black + Red + Green; } }

        public TypedMana(string rawMana)
        {
            _RawMana = rawMana;

            var rawTypes = rawMana
                .TrimStart('{')
                .TrimEnd('}')
                .Split(new[] { "}{" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var rawType in rawTypes)
            {
                if (rawType == RawMana.X)
                {
                    X++;
                }
                if (rawType == RawMana.Colorless)
                {
                    Colorless++;
                }
                if (rawType == RawMana.White)
                {
                    White++;
                }
                if (rawType == RawMana.Blue)
                {
                    Blue++;
                }
                if (rawType == RawMana.Black)
                {
                    Black++;
                }
                if (rawType == RawMana.Red)
                {
                    Red++;
                }
                if (rawType == RawMana.Green)
                {
                    Green++;
                }
                else if (int.TryParse(rawType, out int genericMana))
                {
                    Generic = genericMana;
                }
            }
        }

        public override string ToString()
        {
            return _RawMana;
        }

        public string ToLongString()
        {
            return $"X:{X}-G:{Generic}-C:{Colorless}-W:{White}-U:{Blue}-B:{Black}-R:{Red}-G:{Green}";
        }

        public static TypedMana Parse(string rawMana)
        {
            return new TypedMana(rawMana);
        }
    }
}