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
        ProductsUnitOfWork unitOfWork;
        public Logic(){
            unitOfWork = new ProductsUnitOfWork(new ProductsContext());
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<ProductModel, Product>();
            });
        }
        
        public List<ProductModel> listProducts(){
            List<ProductModel> products = new List<ProductModel>();
            foreach (var product in unitOfWork.Products.GetAll())
            {
                ProductModel p = Mapper.Map<Product, ProductModel>(product);
                products.Add(p);
            }
                return products;
        }


        public void addProduct( ProductModel productModel)
        {

            unitOfWork.Products.Add(Mapper.Map<ProductModel, Product>(productModel));
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
            ProductModel pm = Mapper.Map<Product, ProductModel>(product);
            return pm;
        }

        public void editProduct(ProductModel productModel)
        {
            Product product = unitOfWork.Products.Get(productModel.ID);
            product.Name = productModel.Name;
            product.NumberOfDays = productModel.NumberOfDays;
            unitOfWork.complete();
        }
    }
}