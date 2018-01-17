using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    /// <summary>
    /// Repository for accounts type.
    /// </summary>
    public class AccountTypeRepository : IAccountTypeRepository
    {
        /// <summary>
        /// Context of database.
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// Initialize the instance of the account repository.
        /// </summary>
        /// <param name="context">database context</param>
        public AccountTypeRepository(DbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc></inheritdoc>
        public IEnumerable<DalAccountType> GetAll()
        {
            return _context.Set<OrmAccountType>().ToList().Select(type => type.ToDalAccountType());
        }

        /// <inheritdoc></inheritdoc>
        public DalAccountType GetById(int id)
        {
            var ormAccountType = _context.Set<OrmAccountType>().FirstOrDefault(type => type.Id == id);
            return ormAccountType.ToDalAccountType();
        }

        /// <inheritdoc></inheritdoc>
        public DalAccountType GetByPredicate(Predicate<DalAccountType> predicate)
        {
            return _context.Set<OrmAccountType>().FirstOrDefault(type => predicate(type.ToDalAccountType()))?.ToDalAccountType();
        }

        /// <inheritdoc></inheritdoc>
        public void Create(DalAccountType dalAccountType)
        {
            var accountType = dalAccountType.ToOrmAccountType();
            _context.Set<OrmAccountType>().Add(accountType);
        }

        /// <inheritdoc></inheritdoc>
        public void Delete(DalAccountType dalAccountType)
        {
            var accountType = dalAccountType.ToOrmAccountType();
            accountType = _context.Set<OrmAccountType>().Single(type => type.Id == accountType.Id);
            _context.Set<OrmAccountType>().Remove(accountType);
        }

        /// <inheritdoc></inheritdoc>
        public void Update(DalAccountType type)
        {
            Delete(type);
            Create(type);
        }
    }
}
