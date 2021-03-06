﻿using BLL.Interfaces.Entities.Account;
using BLL.Interfaces.Entities.Exceptions;

namespace BLL.Mappers
{
    /// <summary>
    /// Class for create an instance of classes: BaseAccount, GoldAccount, PlatinumAccount
    /// </summary>
    public static class AccountCreator
    {
        /// <summary>
        /// Contains account types.
        /// </summary>
        public enum AccountType
        {
            /// <summary>
            /// Base account type.
            /// </summary>
            Base,

            /// <summary>
            /// Gold account type.
            /// </summary>
            Gold,

            /// <summary>
            /// Platinum account type.
            /// </summary>
            Platinum
        }

        /// <summary>
        /// Create an instance of account.
        /// </summary>
        /// <param name="accountType">type of account</param>
        /// <param name="id">id of the account</param>
        /// <param name="amount">start amount of money on account</param>
        /// <param name="points">start points of the account</param>
        /// <returns>An instance of account.</returns>
        public static Account CreateAccount(AccountType accountType, int id, double amount = 0, int points = 0)
        {
            switch (accountType)
            {
                case AccountType.Base: return new BaseAccount(id, amount, points);
                case AccountType.Gold: return new GoldAccount(id, amount, points);
                case AccountType.Platinum: return new PlatinumAccount(id, amount, points);
                default: throw new UnknownAccountTypeException("Unknown account type");
            }
        }

        /// <summary>
        /// Create an instance of account
        /// </summary>
        /// <param name="accountType">type of account</param>
        /// <param name="id">id of the account</param>
        /// <param name="amount">start amount of money on account</param>
        /// <param name="points">start points of the account</param>
        /// <returns>An instance of account.</returns>
        public static Account CreateAccount(string accountType, int id, double amount = 0, int points = 0)
        {
            switch (accountType)
            {
                case "Base": return CreateAccount(AccountType.Base, id, amount, points);
                case "Gold": return CreateAccount(AccountType.Gold, id, amount, points);
                case "Platinum": return CreateAccount(AccountType.Platinum, id, amount, points);
                default: throw new UnknownAccountTypeException("Unknown account type");
            }
        }
    }
}
