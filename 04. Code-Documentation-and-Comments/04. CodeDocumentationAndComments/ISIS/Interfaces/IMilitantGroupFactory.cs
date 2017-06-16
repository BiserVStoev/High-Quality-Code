namespace ISIS.Interfaces
{
    using Enums;

    /// <summary>
    /// An interface for a militant group factory.
    /// </summary>
    public interface IMilitantGroupFactory
    {
        /// <summary>
        /// Creates an group using the IMilitant group interface. <see cref="ISIS.Interfaces.IMilitantGroup"/>
        /// </summary>
        /// <param name="name">The name of the group.</param>
        /// <param name="health">The health of the group.</param>
        /// <param name="damage">The damage of the group.</param>
        /// <param name="warEffect">The war effect of the group.<see cref="ISIS.Enums.WarEffect"/></param>
        /// <param name="attackType">The attack type of the group.<see cref="ISIS.Enums.AttackType"/></param>
        /// <returns>An implementation of an IMilitant group.</returns>
        IMilitantGroup CreateGroup(string name, int health, int damage, WarEffect warEffect, AttackType attackType);
    }
}
