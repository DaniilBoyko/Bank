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
    /// Repository for users.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Context of database.
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// Initialize the instance of the account repository.
        /// </summary>
        /// <param name="context">database context</param>
        public UserRepository(DbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc></inheritdoc>
        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<OrmUser>().ToList().Select(user => user.ToDalUser());
        }

        /// <inheritdoc></inheritdoc>
        public DalUser GetById(int id)
        {
            var ormUser = _context.Set<OrmUser>().FirstOrDefault(user => user.Id == id);
            return ormUser.ToDalUser();
        }

        /// <inheritdoc></inheritdoc>
        public DalUser GetByPredicate(Predicate<DalUser> predicate)
        {
            var accountTypes = _context.Set<OrmAccountType>().ToList();
            return _context.Set<OrmUser>().ToList().FirstOrDefault(user => predicate(user.ToDalUser()))?.ToDalUser();
        }

        /// <inheritdoc></inheritdoc>
        public void Create(DalUser dalUser)
        {
            var user = dalUser.ToOrmUser();
            _context.Set<OrmUser>().Add(user);
        }

        /// <inheritdoc></inheritdoc>
        public void Delete(DalUser dalUser)
        {
            var user = dalUser.ToOrmUser();
            user = _context.Set<OrmUser>().Single(usr => usr.Id == user.Id);
            _context.Set<OrmUser>().Remove(user);
        }

        /// <inheritdoc></inheritdoc>
        public void Update(DalUser user)
        {
            Delete(user);
            Create(user);
        }
    }
}
