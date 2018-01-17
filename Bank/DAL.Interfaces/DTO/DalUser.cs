using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    /// <summary>
    /// Dal model of user.
    /// </summary>
    public class DalUser : IEntity
    {
        /// <summary>
        /// Gets or sets id of user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets surname of user.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets email of user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets password of user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets accounts of user.
        /// </summary>
        public virtual List<DalAccount> Accounts { get; set; }
    }
}
