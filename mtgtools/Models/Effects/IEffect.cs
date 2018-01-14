using mtgtools.Models.Abilities;

namespace mtgtools.Models.Effects
{
    public interface IEffect : IStackable
    {
        IAbility Ability { get; set; }
        IEffect Clone();
    }
}