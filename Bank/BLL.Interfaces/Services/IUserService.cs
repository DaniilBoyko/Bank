using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Account;

namespace BLL.Interfaces.Services
{
    /// <summary>
    /// Interface of user service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get user from database.
        /// </summary>
        /// <param name="email">email of the user</param>
        /// <param name="password">password of the user</param>
        /// <returns>user</returns>
        User GetUser(string email, string password);

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name">name of the user</param>
        /// <param name="surname">surname of the user</param>
        /// <param name="email">email of the user</param>
        /// <param name="password">password of the user</param>
        void CreateUser(string name, string surname, string email, string password);

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="user">user</param>
        void DeleteUser(User user);
    }
}
