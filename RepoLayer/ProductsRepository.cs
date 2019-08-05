using RepoLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer
{
    class ProductsRepository : Repository<Product>, IProductsRepository 
    {
        public ProductsRepository(ProductsContext context)
            : base(context)
        { 
        }

        public ProductsContext ProductsContext
        {
            get { return Context as ProductsContext; }
        }
    }
}
