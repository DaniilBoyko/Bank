using System.Linq;
using DAL.Interfaces.DTO;
using ORM;

namespace DAL.Mappers
{
    /// <summary>
    /// Class for mapping object relational account and data access layer.
    /// </summary>
    public static class OrmEntityMappers
    {
        /// <summary>
        /// Convert data access layer account to object relational account.
        /// </summary>
        /// <param name="dalAccount">data access layer account</param>
        /// <returns>Object relation account.</returns>
        public static OrmAccount ToOrmAccount(this DalAccount dalAccount)
        {
            return new OrmAccount()
            {
                Id = dalAccount.Id,
                Amount = dalAccount.Amount,
                Points = dalAccount.Points,
                Type = dalAccount.Type.ToOrmAccountType(),
            };
        }

        /// <summary>
        /// Convert object relation account to data access layer account.
        /// </summary>
        /// <param name="ormAccount">object relation account</param>
        /// <returns>Data access layer account.</returns>
        public static DalAccount ToDalAccount(this OrmAccount ormAccount)
        {
            return new DalAccount()
            {
                Id = ormAccount.Id,
                Amount = ormAccount.Amount,
                Points = ormAccount.Points,
                Type = ormAccount.Type.ToDalAccountType(),
            };
        }

        /// <summary>
        /// Convert object relation account type to data access layer account type.
        /// </summary>
        /// <param name="ormAccountType"></param>
        /// <returns>Data access layer account type.</returns>
        public static DalAccountType ToDalAccountType(this OrmAccountType ormAccountType)
        {
            return new DalAccountType()
            {
                Id = ormAccountType.Id,
                Type = ormAccountType.Type
            };
        }

        /// <summary>
        /// Convert data access layer account type to object relation account type.
        /// </summary>
        /// <param name="dalAccountType">data access layer account type</param>
        /// <returns>Object relation account type.</returns>
        public static OrmAccountType ToOrmAccountType(this DalAccountType dalAccountType)
        {
            return new OrmAccountType()
            {
                Id = dalAccountType.Id,
                Type = dalAccountType.Type
            };
        }

        /// <summary>
        /// Convert object relation user to data access layer user.
        /// </summary>
        /// <param name="ormUser">object relation user</param>
        /// <returns>Data access layer user.</returns>
        public static DalUser ToDalUser(this OrmUser ormUser)
        {
            return new DalUser()
            {
                Id = ormUser.Id,
                Name = ormUser.Name,
                Surname = ormUser.Surname,
                Email = ormUser.Email,
                Accounts = ormUser.Accounts?.Select(ormAcc => ormAcc.ToDalAccount()).ToList(),
                Password = ormUser.Password
            };
        }

        /// <summary>
        /// Convert data access layer user to object relation user.
        /// </summary>
        /// <param name="dalUser">data access layer user</param>
        /// <returns>Object relation user.</returns>
        public static OrmUser ToOrmUser(this DalUser dalUser)
        {
            return new OrmUser()
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Surname = dalUser.Surname,
                Email = dalUser.Email,
                Accounts = dalUser.Accounts?.Select(dalAcc => dalAcc.ToOrmAccount()).ToList(),
                Password = dalUser.Password
            };
        }
    }
}
