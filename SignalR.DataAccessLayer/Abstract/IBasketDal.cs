﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        Task<List<Basket>> GetBasketByMenuTableNumberAsync(int id);

        Task<Basket> GetBasketByProductID(int productId,int menuTableId);
    }
}
