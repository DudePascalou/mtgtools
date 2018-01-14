using mtgtools.Models.Conditions;

namespace mtgtools.Models.Abilities
{
    public abstract class StaticAbilityBase : AbilityBase, IStaticAbility
    {
        public StaticAbilityBase()
        { }
        public StaticAbilityBase(ICondition condition) : base(condition)
        { }
    }
}