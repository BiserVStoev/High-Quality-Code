namespace ISIS.Interfaces
{
    /// <summary>
    /// An attack behaviour interface.
    /// </summary>
    public interface IAttack
    {
        /// <summary>
        /// Produces an attack against a IMilitantGroup <see cref="ISIS.Interfaces.IMilitantGroup"/>
        /// </summary>
        /// <param name="group"></param>
        void Attack(IMilitantGroup group);
    }
}
