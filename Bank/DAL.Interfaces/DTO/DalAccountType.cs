using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    /// <summary>
    /// Dal model of account.
    /// </summary>
    public class DalAccountType : IEntity
    {
        /// <summary>
        /// Gets or sets id of account type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets type of account.
        /// </summary>
        public string Type { get; set; }
    }
}
