using Common;
using Common.Utilities;
using Data.Contracts;
using Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Shipping
{
    /// <summary>
    /// سرویس کار با هزینه های حمل و حمل و نقل های کالا
    /// </summary>
    public class DeliveryBillService : IDeliveryBillService, IScopedDependency
    {
        private IUnitOfWork _uow;
        private readonly ILogger<DeliveryBillService> _logger;
        private DbSet<DeliveryBill> _deliveryHeader;

        public DeliveryBillService(IUnitOfWork uow, ILogger<DeliveryBillService> logger)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _logger = logger;

            _deliveryHeader = _uow.Set<DeliveryBill>();
        }

        /// <summary>
        /// دریافت رکورد یک حمل از طریق شناسه آن
        /// </summary>
        /// <param name="id">شناسه رکورد</param>
        /// <returns>مدل حمل</returns>
        public async Task<ServiceResult<DeliveryBill>> GetDeliveryBillById(int id)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, id);
            return await _deliveryHeader.SingleAsync(z => z.Id == id);
        }

        /// <summary>
        /// دریافت تمام حمل های یک سفارش و فاکتور از روی شناسه آن فاکتور
        /// </summary>
        /// <param name="orderId">شناسه فاکتور صادر شده</param>
        /// <returns>فهرست مدل</returns>
        public async Task<ServiceResult<IEnumerable<DeliveryBill>>> GetDeliveryBillsByOrder(int orderId)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, orderId);
            return await _deliveryHeader.Where(z => z.OrderId == orderId).ToListAsync();
        }

        /// <summary>
        /// بروزرسانی داده های یک حمل
        /// </summary>
        /// <param name="bill">مدل جیسونی یک حمل</param>
        /// <returns>مدل</returns>
        public async Task<ServiceResult<DeliveryBill>> UpdateDeliveryBill(DeliveryBill bill)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, bill);
            await _deliveryHeader.UpdateAsync(bill);
            var result = await _uow.SaveChangesAsync();

            if (result > 0)
            {
                return bill;
            }

            return null;
        }

        /// <summary>
        /// ایجاد یک سند حمل برای یک فاکتور
        /// </summary>
        /// <param name="bill">مدل جیسونی حمل</param>
        /// <returns>مدل داده</returns>
        public async Task<ServiceResult<DeliveryBill>> CreateDeliveryBill(DeliveryBill bill)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, bill);
            await _deliveryHeader.AddAsync(bill);
            var result = await _uow.SaveChangesAsync();

            if (result > 0)
            {
                return bill;
            }

            return null;
        }
    }
}