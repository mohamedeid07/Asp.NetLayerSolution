using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer
{
    interface IUnitOfWork : IDisposable
    {
        IProductsRepository Products { get; }
        int complete();
    }
}
