using Entities.Shipping;
using Services.Shipping.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shipping
{
    public interface IShippingServices
    {
        Task<ServiceResult<IEnumerable<Country>>> GetCountriesData();
        Task<ServiceResult<IEnumerable<Shipper>>> GetAllShippers();
        Task<ServiceResult<IEnumerable<Shipper>>> SearchAllShippers(string text);
        Task<ServiceResult<IEnumerable<ShipperDistination>>> GetAllDistinations();
        Task<ServiceResult<ShipperDistination>> GetDistination(int id);
        Task<ServiceResult<ShippingModel>> FindAllShippers(int orderId);
    }
}
