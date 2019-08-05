using RepoLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer
{
    public class ProductsUnitOfWork : IUnitOfWork
    {
        private readonly ProductsContext _context;

        public ProductsUnitOfWork(ProductsContext context)
        {
            _context = context;
            Products = new ProductsRepository(_context);
        }

        public IProductsRepository Products {get; private set;}

        public int complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
