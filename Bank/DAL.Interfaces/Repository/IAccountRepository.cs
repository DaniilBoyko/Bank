using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    /// <summary>
    /// Interface of account repository.
    /// </summary>
    public interface IAccountRepository : IRepository<DalAccount>
    {
        /// <summary>
        /// Add new account to user.
        /// </summary>
        /// <param name="dalAccount">data access layer account</param>
        /// <param name="email">email of user</param>
        void AddToUser(DalAccount dalAccount, string email);
    }
}
