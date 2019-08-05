using RepoLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer
{
    public interface IProductsRepository : IRepository<Product>
    {
        //Add specific data access methods here
    }
}
