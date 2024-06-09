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

        public Task<List<Basket>> GetBasketByMenuTableNumberAsync(int id)
        {
            using var context = new SignalRContext();

            var values=context.Baskets.Include(b => b.MenuTable)
                                      .Include(b => b.Product)
                                      .Where(x=>x.MenuTableID==id).ToListAsync();

            return values;
        }
    }
}
