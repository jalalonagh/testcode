using Common;
using Common.Utilities;
using Data.Contracts;
using Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Warehouse
{
    public class WarehouseServices : IWarehouseServices, IScopedDependency
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Barcode> _barecode;
        private readonly DbSet<SupplierBarecode> _supplierBarecode;
        private readonly DbSet<SupplierStore> _store;
        private readonly DbSet<SupplierStoreActivities> _activities;
        private readonly DbSet<SupplierSupplyRequest> _request;
        private readonly ILogger<WarehouseServices> _logger;

        public WarehouseServices(IUnitOfWork unit, ILogger<WarehouseServices> logger)
        {
            _uow = unit;
            _barecode = _uow.Set<Entities.Warehouse.Barcode>();
            _supplierBarecode = _uow.Set<Entities.Warehouse.SupplierBarecode>();
            _store = _uow.Set<Entities.Warehouse.SupplierStore>();
            _activities = _uow.Set<Entities.Warehouse.SupplierStoreActivities>();
            _request = _uow.Set<Entities.Warehouse.SupplierSupplyRequest>();
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<Barcode>>> GenerateBulkBarecodes(int number)
        {
            if (number > 0)
            {
                var last = await _barecode
                    .OrderBy(o => o.Id)
                    .LastOrDefaultAsync();

                IEnumerable<Barcode> codes = new List<Barcode>();

                if (last != null)
                {

                    int next = int.Parse(last.Code) + 1;
                    for (int i = next; i < next + number; i++)
                    {
                        codes = codes.Append(new Barcode()
                        {
                            Code = i.ToString(),
                            CreateDm = DateTime.Now,
                            CreateDs = DateTime.Now.ToPersian()
                        });
                    }
                }

                await _barecode.AddRangeAsync(codes);

                var result = await _uow.SaveChangesAsync();

                if (result > 0)
                    return new ServiceResult<IEnumerable<Barcode>>(true, ApiResultStatusCode.Success, codes, "");
            }

            return new ServiceResult<IEnumerable<Barcode>>(false, ApiResultStatusCode.ServerError, null, "داده ای یافت نشد");
        }

        public async Task<ServiceResult<IEnumerable<Barcode>>> GetAllBarcodes()
        {
            return await _barecode.ToListAsync();
        }

        public async Task<ServiceResult<IEnumerable<SupplierBarecode>>> SetBarcodeToSupplier(int storeId, int number)
        {
            if (storeId > 0 && number > 0)
            {
                var barcodes = await _barecode
                    .Where(w => !w.Used && w.VendorId == null)
                    .Take(number)
                    .ToListAsync();

                if (barcodes == null || barcodes.Count() < number)
                    return new ServiceResult<IEnumerable<SupplierBarecode>>(false, ApiResultStatusCode.NotFound, null, "موجودی کافی نیست");

                IEnumerable<SupplierBarecode> codes = new List<SupplierBarecode>();
                foreach (var item in barcodes)
                {
                    codes = codes.Append(new SupplierBarecode()
                    {
                        StoreId = storeId,
                        QRCode = item.Code,
                        CreateDm = DateTime.Now,
                        CreateDs = DateTime.Now.ToPersian()
                    });

                    item.VendorId = storeId;
                    item.Used = true;
                }

                await _supplierBarecode.AddRangeAsync(codes);

                var codesResult = await _uow.SaveChangesAsync();

                if (codesResult > 0)
                {
                    _barecode.UpdateRange(barcodes);

                    var result = await _uow.SaveChangesAsync();

                    return new ServiceResult<IEnumerable<SupplierBarecode>>(true, ApiResultStatusCode.Success, codes, "");
                }

                return new ServiceResult<IEnumerable<SupplierBarecode>>(false, ApiResultStatusCode.ServerError, null, "عملیات ذخیره سازی انجام نشد");
            }

            return new ServiceResult<IEnumerable<SupplierBarecode>>(false, ApiResultStatusCode.BadRequest, null, "داده های ورودی مناسب نیست");
        }

        public async Task<ServiceResult<IEnumerable<SupplierBarecode>>> GetSupplierBarcodes(int storeId)
        {
            return await _supplierBarecode
                .Where(w => w.StoreId == storeId)
                .ToListAsync();
        }

        public async Task<ServiceResult<SupplierBarecode>> SetSupplierBarcodeToUse(int barcodeId, bool used)
        {
            if(barcodeId > 0)
            {
                var exist = await _supplierBarecode
                    .Where(w => w.Id == barcodeId)
                    .FirstOrDefaultAsync();

                if(exist != null)
                {
                    exist.Used = used;

                    await _supplierBarecode.UpdateAsync(exist);

                    var result = await _uow.SaveChangesAsync();

                    if (result > 0)
                        return new ServiceResult<SupplierBarecode>(true, ApiResultStatusCode.Success, exist, "");

                    return new ServiceResult<SupplierBarecode>(false, ApiResultStatusCode.ServerError, null, "ذخیره ایجاد نشد");
                }

                return new ServiceResult<SupplierBarecode>(false, ApiResultStatusCode.NotFound, null, "بارکد وجود ندارد");
            }

            return new ServiceResult<SupplierBarecode>(false, ApiResultStatusCode.BadRequest, null, "داده نامناسب");
        }

        public async Task<ServiceResult<SupplierStore>> CreateRequest(SupplierStore store)
        {
            store.Activities = new List<SupplierStoreActivities>();

            store.Activities = store.Activities.Append(new SupplierStoreActivities()
            {
                CreateDm = DateTime.Now,
                CreateDs = DateTime.Now.ToPersian(),
                Summary = "ایجاد شد برای کاربری",
                Status = "create",
                TargetProfileId = store.SupplierId
            });

            await _store.AddAsync(store);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<SupplierStore>(true, ApiResultStatusCode.Success, store, "");

            return new ServiceResult<SupplierStore>(false, ApiResultStatusCode.ServerError, null, "ایجاد انبار موفق نبود");
        }

        public async Task<ServiceResult<SupplierStore>> EditStore(SupplierStore store)
        {
            await _store.UpdateAsync(store);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<SupplierStore>(true, ApiResultStatusCode.Success, store, "");

            return new ServiceResult<SupplierStore>(false, ApiResultStatusCode.ServerError, null, "ویرایش انبار موفق نبود");

        }

        public async Task<ServiceResult<IEnumerable<SupplierStore>>> GetStores()
        {
            return await _store.ToListAsync();
        }

        public async Task<ServiceResult<SupplierStore>> GetStore(int id)
        {
            return await _store
                .Include(i => i.Activities)
                .Include(i => i.Barcodes)
                .Include(i => i.Supplier)
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ServiceResult<SupplierSupplyRequest>> CreateRequest(SupplierSupplyRequest request)
        {
            request.RequestTime = DateTime.Now;

            await _request.AddAsync(request);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<SupplierSupplyRequest>(true, ApiResultStatusCode.Success, request, "");

            return new ServiceResult<SupplierSupplyRequest>(false, ApiResultStatusCode.ServerError, null, "مشکلی پیش آمده است");
        }

        public async Task<ServiceResult<SupplierSupplyRequest>> EditRequest(SupplierSupplyRequest request)
        {
            await _request.UpdateAsync(request);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<SupplierSupplyRequest>(true, ApiResultStatusCode.Success, request, "");

            return new ServiceResult<SupplierSupplyRequest>(false, ApiResultStatusCode.ServerError, null, "مشکلی پیش آمده است");
        }

        public async Task<ServiceResult<SupplierSupplyRequest>> DeleteRequest(int requestId)
        {
            var exist = await _request
                .Where(w => w.Id == requestId)
                .FirstOrDefaultAsync();

            _request.Remove(exist);

            var result = await _uow.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<SupplierSupplyRequest>(true, ApiResultStatusCode.Success, exist, "");

            return new ServiceResult<SupplierSupplyRequest>(false, ApiResultStatusCode.ServerError, null, "مشکلی پیش آمده است");
        }

        public async Task<ServiceResult<SupplierSupplyRequest>> SetOperationTimes(int requestId, TimeSpan? done
            , TimeSpan? packing, TimeSpan? delay, DateTime? start, DateTime? finish)
        {
            if(requestId > 0)
            {
                var exist = await _request
                    .Where(w => w.Id == requestId)
                    .FirstOrDefaultAsync();

                if(exist != null)
                {
                    exist.PackingFinishTime = finish ?? exist.PackingFinishTime;
                    exist.PackingStartTime = start ?? exist.PackingStartTime;
                    exist.TotalDelayTime = delay ?? exist.TotalDelayTime;
                    exist.TotalDoneTime = done ?? exist.TotalDoneTime;
                    exist.TotalPackingTime = packing ?? exist.TotalPackingTime;

                    await _request.UpdateAsync(exist);

                    var result = await _uow.SaveChangesAsync();

                    if (result > 0)
                        return new ServiceResult<SupplierSupplyRequest>(true, ApiResultStatusCode.Success, exist, "");

                    return new ServiceResult<SupplierSupplyRequest>(false, ApiResultStatusCode.ServerError, null, "زمان ها بروز نشد");
                }

                return new ServiceResult<SupplierSupplyRequest>(false, ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
            }

            return new ServiceResult<SupplierSupplyRequest>(false, ApiResultStatusCode.BadRequest, null, "داده نامناسب");
        }

        public async Task<ServiceResult<SupplierSupplyRequest>> SetRequestConfirm(int requestId, bool confirm)
        {
            if(requestId > 0)
            {
                var exist = await _request
                    .Where(w => w.Id == requestId)
                    .FirstOrDefaultAsync();

                if(exist != null)
                {
                    exist.IsConfirmed = confirm;

                    await _request.UpdateAsync(exist);

                    var result = await _uow.SaveChangesAsync();

                    if (result > 0)
                        return new ServiceResult<SupplierSupplyRequest>(true, ApiResultStatusCode.Success, exist, "");

                    return new ServiceResult<SupplierSupplyRequest>(false, ApiResultStatusCode.ServerError, null, "مشکلی رخ داده است");
                }

                return new ServiceResult<SupplierSupplyRequest>(false, ApiResultStatusCode.NotFound, null, "موردی یافت نشد");
            }

            return new ServiceResult<SupplierSupplyRequest>(false, ApiResultStatusCode.BadRequest, null, "داده نامناسب");
        }

        public Task<ServiceResult<SupplierStore>> CreateStore(SupplierStore store)
        {
            throw new NotImplementedException();
        }
    }
}
