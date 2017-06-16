namespace ISIS.Core.Factory
{
    using Enums;
    using Interfaces;
    using Models;

    public class GroupFactory : IMilitantGroupFactory
    {
        public IMilitantGroup CreateGroup(string name, int health, int damage, WarEffect warEffect, AttackType attackType)
        {
            return new MilitantGroup(name, health, damage, warEffect, attackType);
        }
    }
}
