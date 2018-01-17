using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities.Exceptions
{
    /// <summary>
    /// Exception for add user which already exists.
    /// </summary>
    public class UserAlreadyExistsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">message of exception</param>
        public UserAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
