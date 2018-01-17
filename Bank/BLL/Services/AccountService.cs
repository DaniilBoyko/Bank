using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Account;
using BLL.Interfaces.Entities.Exceptions;
using BLL.Interfaces.Services;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    /// <summary>
    /// Class for manipulation with bank accounts.
    /// </summary>
    public class AccountService : IAccountService
    {
        #region public Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="accountRepository">contains methods for manipulate with accounts</param>
        public AccountService(IUnitOfWork unitOfWork, IAccountRepository accountRepository, IAccountTypeRepository accountTypeRepository, IUserRepository userRepository) 
            : this(unitOfWork, accountRepository, accountTypeRepository, userRepository, new GenerateId())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class
        /// </summary>
        /// <param name="unitOfWork">contains methods for commit after solve unit of work</param>
        /// <param name="accountRepository">repository for accounts</param>
        /// <param name="generateId">contains method for generate id</param>
        public AccountService(IUnitOfWork unitOfWork, IAccountRepository accountRepository, IAccountTypeRepository accountTypeRepository, IUserRepository userRepository, IGenerateId generateId)
        {
            AccountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            AccountTypeRepository = accountTypeRepository ?? throw new ArgumentNullException(nameof(accountTypeRepository));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            GenerateId = generateId ?? throw new ArgumentNullException(nameof(generateId));
        }
        #endregion

        #region private Properties
        /// <summary>
        /// Gets account repository.
        /// </summary>
        private IAccountRepository AccountRepository { get; }

        /// <summary>
        /// Gets account type repository.
        /// </summary>
        private IAccountTypeRepository AccountTypeRepository { get; }

        /// <summary>
        /// Gets user repository.
        /// </summary>
        private IUserRepository UserRepository { get; }

        /// <summary>
        /// Gets unit of work.
        /// </summary>
        private IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Gets id generator.
        /// </summary>
        private IGenerateId GenerateId { get; }
        #endregion // !private Properties

        #region public Methods
        /// <inheritdoc cref="IAccountService.DepositToAccount"/>
        public bool DepositToAccount(int id, double amount)
        {
            Account account = AccountRepository.GetById(id).ToAccount();
            if (account.Deposit(amount))
            {
                AccountRepository.Update(account.ToDalAccount());
                UnitOfWork.Commit();
                return true;
            }

            return false;
        }

        /// <inheritdoc cref="IAccountService.WithdrawFromAccount"/>
        public bool WithdrawFromAccount(int id, double amount)
        {
            Account account = AccountRepository.GetById(id).ToAccount();

            if (account.Withdraw(amount))
            {
                AccountRepository.Update(account.ToDalAccount());
                UnitOfWork.Commit();
                return true;
            }

            return false;
        }

        /// <inheritdoc cref="IAccountService.CreateNewAccount"/>
        public void CreateNewAccount(string accountType, string email, double amount = 0)
        {
            Account account = AccountCreator.CreateAccount(accountType, GenerateId.Generate(), amount);
            AccountRepository.AddToUser(account.ToDalAccount(), email);
            UnitOfWork.Commit();
        }

        /// <inheritdoc cref="IAccountService.DeleteAccount"/>
        public void DeleteAccount(int id)
        {
            Account account = AccountRepository.GetById(id).ToAccount();
            if (account.Amount > 0)
            {
                throw new AccountHasMoneyException("Account already has money! Withdraw before delete.");
            }

            AccountRepository.Delete(account.ToDalAccount());
            UnitOfWork.Commit();
        }

        /// <inheritdoc cref="IAccountService.ShowAccountInfo"/>
        public void ShowAccountInfo(int id)
        {
            Account account = AccountRepository.GetById(id).ToAccount();

            Console.WriteLine(account);
        }

        /// <inheritdoc cref="IAccountService.SelectAll"/>
        public List<Account> SelectAll(string email)
        {
            List<Account> accounts = UserRepository.GetByPredicate(user => user.Email.Equals(email)).ToUser().Accounts;
            return accounts;
        }

        /// <inheritdoc cref="IAccountService.GetAccount"/>
        public Account GetAccount(int id)
        {
            return AccountRepository.GetById(id).ToAccount();
        }

        /// <inheritdoc cref="IAccountService.GetAllTypes"/>
        public IEnumerable<AccountType> GetAllTypes()
        {
            return AccountTypeRepository.GetAll().Select(type => type.ToAccountType());
        }

        /// <inheritdoc cref="IAccountService.Transfer"/>
        public bool Transfer(int fromId, int toId, double amount)
        {
            Account accountFrom = AccountRepository.GetById(fromId).ToAccount();
            Account accountTo = AccountRepository.GetById(toId)?.ToAccount();

            if (accountTo == null)
            {
                throw new AccountNotFoundException("Account to transfer not found.");
            }

            if (accountFrom.Withdraw(amount))
            {
                AccountRepository.Update(accountFrom.ToDalAccount());
                accountTo.Deposit(amount);
                AccountRepository.Update(accountTo.ToDalAccount());
                UnitOfWork.Commit();
                return true;
            }

            return false;
        }

        #endregion // !public Methods
    }
}
