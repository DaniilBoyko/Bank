namespace BLL.Interfaces.Entities
{
    /// <summary>
    /// Model of account type.
    /// </summary>
    public class AccountType
    {
        /// <summary>
        /// Gets or sets id of account type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets type of account.
        /// </summary>
        public string Type { get; set; }
    }
}
