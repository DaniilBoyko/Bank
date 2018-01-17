using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Account;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Class for mapping account and data access layer account.
    /// </summary>
    public static class BllEntityMappers
    {
        /// <summary>
        /// Convert account to data access layer account 
        /// </summary>
        /// <param name="account">account</param>
        /// <returns>Data access layer account.</returns>
        public static DalAccount ToDalAccount(this Account account)
        {
            return new DalAccount()
            {
                Id = account.Id,
                Amount = account.Amount,
                Points = account.Points,
                Type = new DalAccountType() { Type = account.GetAccountType() }
            };
        }

        /// <summary>
        /// Convert data access layer account to account
        /// </summary>
        /// <param name="dalAccount">data access layer</param>
        /// <returns>Account.</returns>
        public static Account ToAccount(this DalAccount dalAccount)
        {
            return AccountCreator.CreateAccount(dalAccount.Type.Type, dalAccount.Id, dalAccount.Amount, dalAccount.Points);
        }

        /// <summary>
        /// Convert data access layer account type to account type.
        /// </summary>
        /// <param name="dalAccountType">data access layer account type</param>
        /// <returns>Account type.</returns>
        public static AccountType ToAccountType(this DalAccountType dalAccountType)
        {
            return new AccountType()
            {
                Id = dalAccountType.Id,
                Type = dalAccountType.Type
            };
        }

        /// <summary>
        /// Convert account type to data access layer account type.
        /// </summary>
        /// <param name="accountType">account type</param>
        /// <returns>Data access layer account type.</returns>
        public static DalAccountType ToDalAccountType(this AccountType accountType)
        {
            return new DalAccountType()
            {
                Id = accountType.Id,
                Type = accountType.Type
            };
        }

        /// <summary>
        /// Convert user to data access layer user.
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>Data access layer user.</returns>
        public static DalUser ToDalUser(this User user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Accounts = user.Accounts?.Select(acc => acc.ToDalAccount()).ToList(),
                Password = user.Password
            };
        }

        /// <summary>
        /// Convert data access layer user to user.
        /// </summary>
        /// <param name="dalUser">data access layer user</param>
        /// <returns>User.</returns>
        public static User ToUser(this DalUser dalUser)
        {
            return new User()
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Surname = dalUser.Surname,
                Email = dalUser.Email,
                Accounts = dalUser.Accounts?.Select(dalAcc => dalAcc.ToAccount()).ToList(),
                Password = dalUser.Password
            };
        }
    }
}
