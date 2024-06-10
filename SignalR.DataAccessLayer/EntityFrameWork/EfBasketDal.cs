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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        

        public async Task<List<Basket>> GetBasketByMenuTableNumberAsync(int id)
        {
            using var context = new SignalRContext();

            var values=await context.Baskets.Include(m=>m.MenuTable).Include(z=>z.Product).Where(x => x.MenuTableID == id)
                                     .ToListAsync();

            return values;
        }

      

        public async Task<Basket> GetBasketByProductID(int productId, int menuTableId)
        {
            using var context = new SignalRContext();

            return await context.Baskets.FirstOrDefaultAsync(m => m.ProductID == productId && m.MenuTableID ==menuTableId);
        }
    }
}
