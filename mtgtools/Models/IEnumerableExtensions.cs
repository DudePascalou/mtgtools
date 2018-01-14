using mtgtools.Models.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IAbility> Clone(this IEnumerable<IAbility> abilities)
        {
            foreach (var ability in abilities)
            {
                yield return ability.Clone();
            }
        }
    }
}