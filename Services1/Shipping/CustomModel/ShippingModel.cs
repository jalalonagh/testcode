using Entities.Order;
using Entities.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shipping.CustomModel
{
    public class ShippingModel
    {
        public OrderHeader order { get; set; }
        public IEnumerable<Shipper> shippers { get; set; }
    }
}
