using Common;
using Data.Contracts;
using Entities.Order;
using Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Shipping.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shipping
{
    public class ShippingServices : IScopedDependency, IShippingServices
    {
        private IUnitOfWork _uow;
        private readonly ILogger<ShippingServices> _logger;
        private DbSet<Country> _country;
        private DbSet<OrderHeader> _order;
        private DbSet<Shipper> _shipper;
        private DbSet<ShipperDistination> _distination;

        public ShippingServices(IUnitOfWork uow, ILogger<ShippingServices> logger)
        {
            _uow = uow;
            _logger = logger;

            _order = _uow.Set<OrderHeader>();
            _country = _uow.Set<Country>();
            _shipper = _uow.Set<Shipper>();
            _distination = _uow.Set<ShipperDistination>();
        }

        public async Task<ServiceResult<IEnumerable<Country>>> GetCountriesData()
        {
            return await _country
                .Include(i => i.CountryProvinces)
                .ThenInclude(t => t.ProvinceCities)
                .ToListAsync();
        }

        public async Task<ServiceResult<IEnumerable<Shipper>>> GetAllShippers()
        {
            return await _shipper
                .Include(i => i.ShipperDistinations)
                .ThenInclude(t => t.Distination)
                .ToListAsync();
        }

        public async Task<ServiceResult<IEnumerable<Shipper>>> SearchAllShippers(string text)
        {
            return await _shipper
                .Include(i => i.ShipperDistinations)
                .ThenInclude(t => t.Distination)
                .Where(w => w.ShipperHtmlData.Contains(text)
                || w.ShipperName.Contains(text))
                .ToListAsync();
        }

        public async Task<ServiceResult<ShippingModel>> FindAllShippers(int orderId)
        {
            var orderData = await _order.Where(i => i.Id == orderId).FirstOrDefaultAsync();

            if (orderData != null)
            {
                var shprs = await _shipper
                .Include(i => i.ShipperDistinations)
                .ThenInclude(t => t.Distination)
                .Where(w => w.ShipperDistinations.Where(ww => ww.Distination.PersianName.Contains(orderData.DeliveryCity)).Any())
                .ToListAsync();

                return new ServiceResult<ShippingModel>(true, ApiResultStatusCode.Success, new ShippingModel()
                {
                    order = orderData,
                    shippers = shprs
                });
            }

            return new ServiceResult<ShippingModel>(false, ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
        }

        public async Task<ServiceResult<IEnumerable<ShipperDistination>>> GetAllDistinations()
        {
            return await _distination
                .Include(i => i.Distination)
                .Include(i => i.ShipperData)
                .ToListAsync();
        }

        public async Task<ServiceResult<ShipperDistination>> GetDistination(int id)
        {
            return await _distination
                .Include(i => i.Distination)
                .Include(i => i.ShipperData)
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
