using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        Task<List<Product>> GetProductsWithCategoriesAsync();
        Task<int> ProductCountAsync();
        Task<int> ProductCountByCategoryNameHamburgerAsync();
        Task<int> ProductCountByCategoryNameDrinkAsync();

        Task<decimal> AverageProductPriceAsync();

        Task<string> ProductNameWithHighestPriceAsync();
        Task<string> ProductNameWithLowestPriceAsync();

        Task<decimal> AverageProductPriceByHamburgerAsync();
    }
}
