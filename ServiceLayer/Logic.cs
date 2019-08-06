using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoLayer;
using RepoLayer.Model;

namespace ServiceLayer
{
    public class Logic
    {
        ProductsUnitOfWork unitOfWork = new ProductsUnitOfWork(new ProductsContext());

        public IEnumerable<Product> listProducts(){
                IEnumerable<Product> products = unitOfWork.Products.GetAll();
                return products;
        }


        public void addProduct( string Name, int NumberOfDays)
        {

            unitOfWork.Products.Add(new Product { 
            Name = Name,
            NumberOfDays = NumberOfDays
            });
            unitOfWork.complete();
        }

        public void removeProduct(int ID)
        {
            Product product = unitOfWork.Products.Get(ID);
            unitOfWork.Products.Remove(product);
            unitOfWork.complete();
        }

        public Product getProduct(int ID)
        {
            Product product = unitOfWork.Products.Get(ID);
            return product;
        }

        public Product editProduct(int ID, string newName, int newNumberOfDays)
        {
            Product product = unitOfWork.Products.Get(ID);
            product.Name = newName;
            product.NumberOfDays = newNumberOfDays;
            unitOfWork.complete();
            return product;
        }
    }
}