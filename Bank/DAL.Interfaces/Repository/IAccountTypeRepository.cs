using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    /// <summary>
    /// Interface of account type repository.
    /// </summary>
    public interface IAccountTypeRepository : IRepository<DalAccountType>
    {
    }
}
