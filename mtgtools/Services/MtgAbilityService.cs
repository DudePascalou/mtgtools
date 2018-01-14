using mtgtools.Models;
using mtgtools.Models.Abilities;
using mtgtools.Models.Conditions;
using mtgtools.Models.Costs;
using mtgtools.Models.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace mtgtools.Services
{
    public class MtgAbilityService
    {
        private readonly IDictionary<string, ICollection<IAbility>> _CardAbilitiesByName;

        public MtgAbilityService()
        {
            _CardAbilitiesByName = new Dictionary<string, ICollection<IAbility>>();

            // TODO : serialize/deserialize abilities on a json file.

            AddAbility("Island", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{U}")));
            AddAbility("Forest", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{G}")));

            AddAbility("Elvish Spirit Guide", new ManaActivatedAbility(new IsInHandCondition(), new RemoveFromTheGameCost(), new AddToManaPoolEffect("{G}")));
            AddAbility("Magus of the Library", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{C}")));
            AddAbility("Llanowar Elves", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{G}")));
            AddAbility("Hedron Archive", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{C}{C}")));
            AddAbility("Lotus Petal", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{AC}")));
            AddAbility("Ghost Quarter", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{C}")));
            AddAbility("Mishra's Factory", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{C}")));
            AddAbility("Spawning Bed", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{C}")));
            AddAbility("Unclaimed Territory", new ManaActivatedAbility(new IsOnBattlefieldCondition(), new TapCost(), new AddToManaPoolEffect("{C}"))); // TODO : choose a creature type
        }

        public void AddAbility(string cardName, params IAbility[] abilities)
        {
            if (!_CardAbilitiesByName.ContainsKey(cardName))
            {
                _CardAbilitiesByName.Add(cardName, new List<IAbility>());
            }
            foreach (var ability in abilities)
            {
                _CardAbilitiesByName[cardName].Add(ability);
            }
        }

        public void AffectAbilities(Card card)
        {
            if (_CardAbilitiesByName.ContainsKey(card.Name))
            {
                var abilities = _CardAbilitiesByName[card.Name].Clone(); // Abilities have to be cloned because they receive the card instance below.
                foreach (var ability in abilities)
                {
                    card.Abilities.Add(ability);
                    ability.Card = card;
                }
            }
            else if (card.Abilities == null)
            {
                card.Abilities = new List<IAbility>();
            }
            else
            {
                Debug.WriteLine($"No ability found for {card.Name}.");
            }
        }
    }
}