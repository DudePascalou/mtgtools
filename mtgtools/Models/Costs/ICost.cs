using mtgtools.Models.Abilities;

namespace mtgtools.Models.Costs
{
    public interface ICost
    {
        IAbility Ability { get; set; }
        bool CanPay();
        void Pay();
    }
}