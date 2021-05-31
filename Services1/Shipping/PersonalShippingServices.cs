using Data.Contracts;
using Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shipping
{
    public class PersonalShippingServices : IPersonalShippingServices
    {
        private IUnitOfWork _uow;
        private readonly ILogger<PersonalShippingServices> _logger;
        private DbSet<PersonalShipper> _personal;
        private DbSet<PersonalShipperTarget> _target;
        private DbSet<PersonalShipperTargetCost> _cost;
        private DbSet<VehicleType> _vehicle;
        private DbSet<ShippingBoxType> _box;

        public PersonalShippingServices(IUnitOfWork uow, ILogger<PersonalShippingServices> logger)
        {
            _uow = uow;
            _logger = logger;
            _personal = _uow.Set<PersonalShipper>();
            _target = _uow.Set<PersonalShipperTarget>();
            _cost = _uow.Set<PersonalShipperTargetCost>();
            _vehicle = _uow.Set<VehicleType>();
            _box = _uow.Set<ShippingBoxType>();
        }

        public async Task<ServiceResult<IEnumerable<PersonalShipper>>> SearchShipper(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new ServiceResult<IEnumerable<PersonalShipper>>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            var result = await _personal
                .Include(i => i.DestinationCity)
                .Include(i => i.Targets)
                .ThenInclude(t => t.TargetCity)
                .Include(i => i.Type)
                .Where(w => w.FirstName.Contains(text)
                || w.LastName.Contains(text)
                || w.DestinationCity.Name.Contains(text)
                || w.Targets.Where(w1 => w1.TargetCity.Name.Contains(text)).Any())
                .ToListAsync();

            if (result == null || !result.Any())
                return new ServiceResult<IEnumerable<PersonalShipper>>(false, Common.ApiResultStatusCode.NotFound, null, "موردی یافت نشد");

            return new ServiceResult<IEnumerable<PersonalShipper>>(true, Common.ApiResultStatusCode.Success, result, "");
        }

        public async Task<ServiceResult<PersonalShipper>> AddShipper(PersonalShipper shipper)
        {
            if (shipper == null)
                return new ServiceResult<PersonalShipper>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            await _personal.AddAsync(shipper, new System.Threading.CancellationToken());

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<PersonalShipper>(true, Common.ApiResultStatusCode.Success, shipper, "");

            return new ServiceResult<PersonalShipper>(false, Common.ApiResultStatusCode.ServerError, null, "ذخیره سازی موفقیت آمیز نبود");
        }

        public async Task<ServiceResult<PersonalShipper>> EditShipper(PersonalShipper shipper)
        {
            if (shipper == null)
                return new ServiceResult<PersonalShipper>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            await _personal.UpdateAsync(shipper);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<PersonalShipper>(true, Common.ApiResultStatusCode.Success, shipper, "");

            return new ServiceResult<PersonalShipper>(false, Common.ApiResultStatusCode.ServerError, null, "ذخیره سازی موفقیت آمیز نبود");
        }

        public async Task<ServiceResult<PersonalShipper>> DeleteShipper(int shipperId)
        {
            if (shipperId > 0)
                return new ServiceResult<PersonalShipper>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            var data = await _personal.Where(w => w.Id == shipperId).FirstOrDefaultAsync();

            _personal.Remove(data);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<PersonalShipper>(true, Common.ApiResultStatusCode.Success, data, "");

            return new ServiceResult<PersonalShipper>(false, Common.ApiResultStatusCode.ServerError, null, "حذف موفقیت آمیز نبود");
        }

        public async Task<ServiceResult<IEnumerable<PersonalShipper>>> GetShippers()
        {
            var result = await _personal
                .Include(i => i.DestinationCity)
                .Include(i => i.Targets)
                .ToListAsync();

            if (result != null)
                return new ServiceResult<IEnumerable<PersonalShipper>>(true, Common.ApiResultStatusCode.Success, result, "");

            return new ServiceResult<IEnumerable<PersonalShipper>>(false, Common.ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
        }

        public async Task<ServiceResult<PersonalShipperTarget>> AddTarget(PersonalShipperTarget target)
        {
            if (target == null)
                return new ServiceResult<PersonalShipperTarget>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            await _target.AddAsync(target, new System.Threading.CancellationToken());

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<PersonalShipperTarget>(true, Common.ApiResultStatusCode.Success, target, "");

            return new ServiceResult<PersonalShipperTarget>(false, Common.ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
        }

        public async Task<ServiceResult<PersonalShipperTarget>> EditTarget(PersonalShipperTarget target)
        {
            if (target == null)
                return new ServiceResult<PersonalShipperTarget>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            await _target.UpdateAsync(target);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<PersonalShipperTarget>(true, Common.ApiResultStatusCode.Success, target, "");

            return new ServiceResult<PersonalShipperTarget>(false, Common.ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
        }

        public async Task<ServiceResult<PersonalShipperTarget>> DeleteTarget(int targetId)
        {
            if (targetId > 0)
                return new ServiceResult<PersonalShipperTarget>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            var target = await _target.Where(w => w.Id == targetId).FirstOrDefaultAsync();

            _target.Remove(target);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<PersonalShipperTarget>(true, Common.ApiResultStatusCode.Success, target, "");

            return new ServiceResult<PersonalShipperTarget>(false, Common.ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
        }

        public async Task<ServiceResult<IEnumerable<PersonalShipperTarget>>> GetTargets(int shipperId)
        {
            var result = await _target
                .Include(i => i.Costs)
                .Include(i => i.TargetCity)
                .Include(i => i.Vehicle)
                .Where(w => w.VehicleId == shipperId)
                .ToListAsync();

            if (result != null)
                return new ServiceResult<IEnumerable<PersonalShipperTarget>>(true, Common.ApiResultStatusCode.Success, result, "");

            return new ServiceResult<IEnumerable<PersonalShipperTarget>>(false, Common.ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
        }

        public async Task<ServiceResult<PersonalShipperTargetCost>> AddCost(PersonalShipperTargetCost cost)
        {
            if (cost == null)
                return new ServiceResult<PersonalShipperTargetCost>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            await _cost.AddAsync(cost, new System.Threading.CancellationToken());

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<PersonalShipperTargetCost>(true, Common.ApiResultStatusCode.Success, cost, "");

            return new ServiceResult<PersonalShipperTargetCost>(false, Common.ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
        }

        public async Task<ServiceResult<PersonalShipperTargetCost>> EditCost(PersonalShipperTargetCost cost)
        {
            if (cost == null)
                return new ServiceResult<PersonalShipperTargetCost>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            await _cost.UpdateAsync(cost);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<PersonalShipperTargetCost>(true, Common.ApiResultStatusCode.Success, cost, "");

            return new ServiceResult<PersonalShipperTargetCost>(false, Common.ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
        }

        public async Task<ServiceResult<PersonalShipperTargetCost>> DeleteCost(int costId)
        {
            if (costId > 0)
                return new ServiceResult<PersonalShipperTargetCost>(false, Common.ApiResultStatusCode.BadRequest, null, "داده ورودی خالی است");

            var target = await _cost.Where(w => w.Id == costId).FirstOrDefaultAsync();

            _cost.Remove(target);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<PersonalShipperTargetCost>(true, Common.ApiResultStatusCode.Success, target, "");

            return new ServiceResult<PersonalShipperTargetCost>(false, Common.ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
        }

        public async Task<ServiceResult<IEnumerable<PersonalShipperTargetCost>>> GetTargetCosts(int targetId)
        {
            if (targetId > 0)
            {
                var data = await _cost.Where(w => w.TargetId == targetId).ToListAsync();

                if (data != null && data.Any())
                    return new ServiceResult<IEnumerable<PersonalShipperTargetCost>>(true, Common.ApiResultStatusCode.Success, data, "");
            }

            return new ServiceResult<IEnumerable<PersonalShipperTargetCost>>(false, Common.ApiResultStatusCode.NotFound, null, "");
        }
    }
}
