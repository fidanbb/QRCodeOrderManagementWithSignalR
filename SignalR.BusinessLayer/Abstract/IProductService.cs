﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        Task<List<Product>> TGetProductsWithCategoriesAsync();
		Task<int> TProductCountAsync();
		Task<int> TProductCountByCategoryNameHamburgerAsync();
		Task<int> TProductCountByCategoryNameDrinkAsync();
		Task<decimal> TAverageProductPriceAsync();
		Task<string> TProductNameWithHighestPriceAsync();
		Task<string> TProductNameWithLowestPriceAsync();
		Task<decimal> TAverageProductPriceByHamburgerAsync();
        Task<decimal> TGetPriceByProductID(int id);

        Task<decimal> TProductPriceBySteakBurger();
        Task<decimal> TTotalPriceByDrinkCategory();
        Task<decimal> TTotalPriceBySaladCategory();

		Task<decimal> TTotalProductPriceAsync();
	}
}
