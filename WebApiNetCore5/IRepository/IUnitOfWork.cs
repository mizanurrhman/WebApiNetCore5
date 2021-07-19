using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore5.Data;

namespace WebApiNetCore5.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
         IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }

        Task Save();
     }
}
 