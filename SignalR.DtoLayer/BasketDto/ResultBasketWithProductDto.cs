using SignalR.DtoLayer.MenuTableDto;
using SignalR.DtoLayer.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BasketDto
{
    public class ResultBasketWithProductDto
    {
        public int BasketID { get; set; }
        public ResultProductDto Product { get; set; }
        public ResultMenuTableDto MenuTable { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}
