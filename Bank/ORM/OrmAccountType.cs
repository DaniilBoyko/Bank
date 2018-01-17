using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Store the types of account.
    /// </summary>
    public class OrmAccountType
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
