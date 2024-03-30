using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopV3.Order.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProructTotalPrice { get; set; }
        public int OrderId { get; set; }
        public Ordering Ordering { get; set; }

    }
}
