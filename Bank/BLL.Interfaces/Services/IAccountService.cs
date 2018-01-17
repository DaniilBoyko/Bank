using System.Collections.Generic;
using System.Net.Http.Headers;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Account;

namespace BLL.Interfaces.Services
{
    /// <summary>
    /// Interface of account service.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Deposit money to account.
        /// </summary>
        /// <param name="id">id of account</param>
        /// <param name="amount">amount of money</param>
        /// <returns>True if success, false otherwise.</returns>
        bool DepositToAccount(int id, double amount);

        /// <summary>
        /// Withdraw money from account.
        /// </summary>
        /// <param name="id">id of account</param>
        /// <param name="amount">amount of money</param>
        /// <returns>True if success, false otherwise.</returns>
        bool WithdrawFromAccount(int id, double amount);

        /// <summary>
        /// Create new account.
        /// </summary>
        /// <param name="accountType">account type</param>
        /// <param name="email">email of user</param>
        /// <param name="amount">start amount of money</param>
        void CreateNewAccount(string accountType, string email, double amount = 0);

        /// <summary>
        /// Delete account.
        /// </summary>
        void DeleteAccount(int id);

        /// <summary>
        /// Show account info.
        /// </summary>
        void ShowAccountInfo(int id);

        /// <summary>
        /// Get all account of user with specified email.
        /// </summary>
        /// <param name="email">email of user</param>
        /// <returns>List of accounts.</returns>
        List<Account> SelectAll(string email);

        /// <summary>
        /// Get account with specified id.
        /// </summary>
        /// <param name="id">id of the account</param>
        /// <returns>Account.</returns>
        Account GetAccount(int id);

        /// <summary>
        /// Get all types.
        /// </summary>
        /// <returns>List of account types.</returns>
        IEnumerable<AccountType> GetAllTypes();

        /// <summary>
        /// Transfer money from one account to another.
        /// </summary>
        /// <param name="fromId">id of from account</param>
        /// <param name="toId">id of to account</param>
        /// <param name="amount">amount of transfer</param>
        bool Transfer(int fromId, int toId, double amount);
    }
}
