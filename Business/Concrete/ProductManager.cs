using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCusttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //yetkisi varmı?
            //if (DateTime.Now.Hour==18)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p =>
                p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productıd)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productıd));
        }

        
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        { 

            //business codes


            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<ProductDeatilDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDeatilDto>>(_productDal.GetProductDetails());
        }
    }
}
