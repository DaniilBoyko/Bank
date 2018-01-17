namespace ORM
{
    using System.Data.Entity;

    /// <summary>
    /// Module of entity.
    /// </summary>
    public class EntityModel : DbContext
    {
        /// <summary>
        /// Constructor initialize the instance of <see cref="EntityModel"/> class.
        /// </summary>
        public EntityModel()
            : base("name=BankDB")
        {
        }

        /// <summary>
        /// Gets or sets database set of accounts.
        /// </summary>
        public virtual DbSet<OrmAccount> Accounts { get; set; }

        /// <summary>
        /// Gets or sets database set of users.
        /// </summary>
        public virtual DbSet<OrmUser> Users { get; set; }

        /// <summary>
        /// Gets or sets database set of account types.
        /// </summary>
        public virtual DbSet<OrmAccountType> AccountTypes { get; set; }
    }
}