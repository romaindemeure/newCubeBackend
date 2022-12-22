using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newCubeBackend.CustomerOrderModel
{
    public class CustomerOrder
    {
        public string? NumberItemCustomer { get; set; }
        public string? OrderCustomer { get; set; }
        public string? PriceCustomer { get; set; }
        public string? PriceWithoutTccCustomer { get; set; }
        public string? OrderDateCustomer { get; set; }
        public string? DiscountCustomer { get; set; }
        public string? DeliveryCostCustomer { get; set; }
        public string? OrderItemIdCustomer { get; set; }
    }
}