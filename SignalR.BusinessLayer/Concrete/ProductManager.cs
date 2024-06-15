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

		public async Task<decimal> TAverageProductPriceAsync()
		{
			return await _productDal.AverageProductPriceAsync();
		}

		public async Task<decimal> TAverageProductPriceByHamburgerAsync()
		{
            return await _productDal.AverageProductPriceByHamburgerAsync();
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

        public async Task<decimal> TGetPriceByProductID(int id)
        {
            return await _productDal.GetPriceByProductID(id);
        }

        public async Task<List<Product>> TGetProductsWithCategoriesAsync()
        {
            return await _productDal.GetProductsWithCategoriesAsync();
        }

		public async Task<int> TProductCountAsync()
		{
			return await _productDal.ProductCountAsync();
		}

		public async Task<int> TProductCountByCategoryNameDrinkAsync()
		{
			return await _productDal.ProductCountByCategoryNameDrinkAsync();
		}

		public async Task<int> TProductCountByCategoryNameHamburgerAsync()
		{
			return await _productDal.ProductCountByCategoryNameHamburgerAsync();
		}

		public async Task<string> TProductNameWithHighestPriceAsync()
		{
			return await _productDal.ProductNameWithHighestPriceAsync();
		}

		public async Task<string> TProductNameWithLowestPriceAsync()
		{
            return await _productDal.ProductNameWithLowestPriceAsync();
		}

        public async Task<decimal> TProductPriceBySteakBurger()
        {
            return await _productDal.ProductPriceBySteakBurger();
        }

        public async Task<decimal> TTotalPriceByDrinkCategory()
        {
          return  await _productDal.TotalPriceByDrinkCategory();
        }

        public async Task<decimal> TTotalPriceBySaladCategory()
        {
            return await _productDal.TotalPriceBySaladCategory();
        }

        public async Task TUpdate(Product entity)
        {
           await _productDal.Update(entity);
        }
    }
}
