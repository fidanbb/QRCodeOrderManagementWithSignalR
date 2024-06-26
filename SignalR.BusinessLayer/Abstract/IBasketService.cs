﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        Task<List<Basket>> TGetBasketByMenuTableNumberAsync(int id);
        Task<Basket> TGetBasketByProductID(int productId, int menuTableId);
    }
}
