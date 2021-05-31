using Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Warehouse
{
    public interface IWarehouseServices
    {
        Task<ServiceResult<IEnumerable<Barcode>>> GenerateBulkBarecodes(int number);

        Task<ServiceResult<IEnumerable<Barcode>>> GetAllBarcodes();

        Task<ServiceResult<IEnumerable<SupplierBarecode>>> SetBarcodeToSupplier(int storeId, int number);

        Task<ServiceResult<IEnumerable<SupplierBarecode>>> GetSupplierBarcodes(int storeId);

        Task<ServiceResult<SupplierBarecode>> SetSupplierBarcodeToUse(int barcodeId, bool used);

        Task<ServiceResult<SupplierStore>> CreateStore(SupplierStore store);

        Task<ServiceResult<SupplierStore>> EditStore(SupplierStore store);

        Task<ServiceResult<IEnumerable<SupplierStore>>> GetStores();

        Task<ServiceResult<SupplierStore>> GetStore(int id);

        Task<ServiceResult<SupplierSupplyRequest>> CreateRequest(SupplierSupplyRequest request);

        Task<ServiceResult<SupplierSupplyRequest>> EditRequest(SupplierSupplyRequest request);

        Task<ServiceResult<SupplierSupplyRequest>> DeleteRequest(int requestId);

        Task<ServiceResult<SupplierSupplyRequest>> SetOperationTimes(int requestId, TimeSpan? done
            , TimeSpan? packing, TimeSpan? delay, DateTime? start, DateTime? finish);

        Task<ServiceResult<SupplierSupplyRequest>> SetRequestConfirm(int requestId, bool confirm);
    }
}
