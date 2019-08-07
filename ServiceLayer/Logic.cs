using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoLayer;
using RepoLayer.Model;
using ViewModelLayer.Models;
using AutoMapper;

namespace ServiceLayer
{
    public class Logic
    {
        ProductsUnitOfWork unitOfWork = new ProductsUnitOfWork(new ProductsContext());

        public List<ProductModel> listProducts(){
            List<ProductModel> products = new List<ProductModel>();
            foreach (var product in unitOfWork.Products.GetAll())
            {
                ProductModel p = new ProductModel
                {
                    ID = product.ID,
                    Name = product.Name,
                    NumberOfDays = (int)product.NumberOfDays
                };
                products.Add(p);
            }
                
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

        public ProductModel getProduct(int ID)
        {
            Product product = unitOfWork.Products.Get(ID);
            ProductModel pm = new ProductModel
            {
                ID = product.ID,
                Name = product.Name,
                NumberOfDays = (int)product.NumberOfDays
            };
            return pm;
        }

        public void editProduct(int ID, string newName, int newNumberOfDays)
        {
            Product product = unitOfWork.Products.Get(ID);
            product.Name = newName;
            product.NumberOfDays = newNumberOfDays;
            unitOfWork.complete();
        }
    }
}