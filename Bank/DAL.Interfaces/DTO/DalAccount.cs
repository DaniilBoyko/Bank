namespace DAL.Interfaces.DTO
{
    /// <summary>
    /// Data access layer account.
    /// </summary>
    public class DalAccount : IEntity
    {
        /// <summary>
        /// Id of the account.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Amount money on the account.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Bonus points on the account.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Type of the account.
        /// </summary>
        public DalAccountType Type { get; set; }
    }
}
