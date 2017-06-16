namespace ISIS.Interfaces
{
    using Enums;

    /// <summary>
    /// An interface for a militant group.
    /// </summary>
    public interface IMilitantGroup : IGroup, IAttack, IUpdateable
    {
        /// <summary>
        /// Gets the war effect of the millitint group. <see cref="ISIS.Enums.WarEffect"/>
        /// </summary>
        WarEffect WarEffect { get; }

        /// <summary>
        /// Gets the attack type of the millitant group. <see cref="ISIS.Enums.AttackType"/>
        /// </summary>
        AttackType AttackType { get; }

        /// <summary>
        /// Checks whether the war effect of the group has been triggered.
        /// </summary>
        bool WarEffectHasTriggered { get; set; }
    }
}
