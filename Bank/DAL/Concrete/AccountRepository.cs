using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    /// <summary>
    /// Repository for accounts.
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// Context of database.
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// Initialize the instance of the account repository.
        /// </summary>
        /// <param name="context">database context</param>
        public AccountRepository(DbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc></inheritdoc>
        public IEnumerable<DalAccount> GetAll()
        {
            return _context.Set<OrmAccount>().ToList().Select(account => account.ToDalAccount());
        }

        /// <inheritdoc></inheritdoc>
        public DalAccount GetById(int id)
        {
            var accountTypes = _context.Set<OrmAccountType>().ToList();
            return _context.Set<OrmAccount>().FirstOrDefault(acc => acc.Id.Equals(id))?.ToDalAccount();
        }

        /// <inheritdoc></inheritdoc>
        public DalAccount GetByPredicate(Predicate<DalAccount> predicate)
        {
            return _context.Set<OrmAccount>().FirstOrDefault(account => predicate(account.ToDalAccount()))?.ToDalAccount();
        }

        /// <inheritdoc></inheritdoc>
        public void Create(DalAccount dalAccount)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc></inheritdoc>
        public void Delete(DalAccount dalAccount)
        {
            var account = dalAccount.ToOrmAccount();
            account = _context.Set<OrmAccount>().Single(acc => acc.Id == account.Id);
            _context.Set<OrmAccount>().Remove(account);
        }

        /// <inheritdoc></inheritdoc>
        public void Update(DalAccount account)
        {
            var ormAccount = _context.Set<OrmAccount>().Single(acc => acc.Id.Equals(account.Id));
            ormAccount.Amount = account.Amount;
            ormAccount.Points = account.Points;
            ormAccount.Type = GetType(account.Type.Type);
        }

        /// <inheritdoc></inheritdoc>
        public void AddToUser(DalAccount dalAccount, string email)
        {
            var account = dalAccount.ToOrmAccount();
            var user = _context.Set<OrmUser>().Single(usr => usr.Email.Equals(email));
            if (user.Accounts == null)
            {
                user.Accounts = new List<OrmAccount>();
            }

            user.Accounts.Add(account);
            account.Type = GetType(account.Type.Type);
        }

        private OrmAccountType GetType(string type)
        {
            return _context.Set<OrmAccountType>().Single(typ => typ.Type.Equals(type));
        }
    }
}
