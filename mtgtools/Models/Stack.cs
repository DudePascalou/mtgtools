using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public class Stack
    {
        public Stack<IStackable> SpellsOrEffects { get; set; }

        public Stack()
        {
            SpellsOrEffects = new Stack<IStackable>();
        }

        public void Put(IStackable spellOrEffect)
        {
            SpellsOrEffects.Push(spellOrEffect);
        }

        public void Resolves()
        {
            while (SpellsOrEffects.Peek() != null)
            {
                var spellOfEffect = SpellsOrEffects.Pop();
                spellOfEffect.Resolves();
            }
        }
    }
}