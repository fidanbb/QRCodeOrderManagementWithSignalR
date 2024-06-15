using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFrameWork
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

		public async Task<decimal> AverageProductPriceAsync()
		{
			using var context = new SignalRContext();


			return await context.Products.AverageAsync(x => x.Price);
		}

		public async Task<decimal> AverageProductPriceByHamburgerAsync()
		{
			using var context = new SignalRContext();

			return await context.Products.Where(x => x.CategoryId == (context.Categories
										 .Where(y => y.CategoryName == "Hamburger")
										 .Select(z=>z.CategoryId).FirstOrDefault()))
					                     .AverageAsync(a => a.Price);			
										 
										 
		}

        public async Task<decimal> GetPriceByProductID(int id)
        {
            using var context = new SignalRContext();

			return await context.Products.Where(x=>x.ProductId==id).Select(x=>x.Price).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductsWithCategoriesAsync()
        {
            var context = new SignalRContext();

            var values = await context.Products.Include(x => x.Category).ToListAsync();

            return values;
        }

		public async Task<int> ProductCountAsync()
		{
			using var context=new SignalRContext();

            return await context.Products.CountAsync();
		}

		public async Task<int> ProductCountByCategoryNameDrinkAsync()
		{
			using var context=new SignalRContext();

			return await context.Products.Where(x => x.CategoryId == (context.Categories
								   .Where(y => y.CategoryName == "Drink")
								   .Select(z => z.CategoryId).FirstOrDefault())).CountAsync();
		}

		public async Task<int> ProductCountByCategoryNameHamburgerAsync()
		{
			using var context = new SignalRContext();

			return await context.Products.Where(x => x.CategoryId == (context.Categories
								   .Where(y => y.CategoryName == "Hamburger")
								   .Select(z => z.CategoryId).FirstOrDefault())).CountAsync();
		}

		public async Task<string> ProductNameWithHighestPriceAsync()
		{
			using var context=new SignalRContext();

			return await context.Products.Where(m => m.Price == (context.Products.Max(y => y.Price)))
				                         .Select(z => z.ProductName).FirstOrDefaultAsync() ?? "No Product Found";
		}

		public async Task<string> ProductNameWithLowestPriceAsync()
		{
			using var context = new SignalRContext();

			return await context.Products.Where(m => m.Price == (context.Products.Min(y => y.Price)))
										 .Select(z => z.ProductName).FirstOrDefaultAsync() ?? "No Product Found";
		}

        public async Task<decimal> ProductPriceBySteakBurger()
        {
            using var context = new SignalRContext();
            return await context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.Price).FirstOrDefaultAsync();
        }

        public async Task<decimal> TotalPriceByDrinkCategory()
        {
            using var context = new SignalRContext();
            int id = await context.Categories.Where(x => x.CategoryName == "Drink").Select(y => y.CategoryId).FirstOrDefaultAsync();
            return await context.Products.Where(x => x.CategoryId == id).SumAsync(y => y.Price);
        }

        public async Task<decimal> TotalPriceBySaladCategory()
        {
            using var context = new SignalRContext();
            int id =await context.Categories.Where(x => x.CategoryName == "Salad").Select(y => y.CategoryId).FirstOrDefaultAsync();
            return await context.Products.Where(x => x.CategoryId == id).SumAsync(y => y.Price);
        }

		public async Task<decimal> TotalProductPriceAsync()
		{
			using var context = new SignalRContext();
			return await context.Products.SumAsync(x => x.Price);
		}
	}
}
