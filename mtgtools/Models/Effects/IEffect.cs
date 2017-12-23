using mtgtools.Models.Abilities;

namespace mtgtools.Models.Effects
{
    public interface IEffect
    {
        IAbility Ability { get; set; }
        void Resolves();
    }
}