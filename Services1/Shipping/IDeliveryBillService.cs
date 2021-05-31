using Data.Contracts;
using Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shipping
{
    public interface IDeliveryBillService
    {
        Task<ServiceResult<IEnumerable<DeliveryBill>>> GetDeliveryBillsByOrder(int orderId);
        Task<ServiceResult<DeliveryBill>> GetDeliveryBillById(int id);
        Task<ServiceResult<DeliveryBill>> UpdateDeliveryBill(DeliveryBill bill);
        Task<ServiceResult<DeliveryBill>> CreateDeliveryBill(DeliveryBill bill);
    }
}
