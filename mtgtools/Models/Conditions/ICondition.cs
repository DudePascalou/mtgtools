using mtgtools.Models.Abilities;

namespace mtgtools.Models.Conditions
{
    public interface ICondition
    {
        IAbility Ability { get; set; }
        bool IsTrue { get; }
    }
}