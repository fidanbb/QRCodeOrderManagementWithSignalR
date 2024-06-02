using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task TAdd(Product entity)
        {
           await _productDal.Add(entity);   
        }

        public async Task TDelete(Product entity)
        {
             await _productDal.Delete(entity);
        }

        public async Task<List<Product>> TGetAll()
        {
            return await _productDal.GetAll();
        }

        public async Task<Product> TGetByID(int id)
        {
            return await _productDal.GetByID(id);
        }

        public async Task<List<Product>> TGetProductsWithCategoriesAsync()
        {
            return await _productDal.GetProductsWithCategoriesAsync();
        }

        public async Task TUpdate(Product entity)
        {
           await _productDal.Update(entity);
        }
    }
}
