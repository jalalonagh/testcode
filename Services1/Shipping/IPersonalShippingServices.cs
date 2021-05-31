using Entities.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shipping
{
    public interface IPersonalShippingServices
    {
        Task<ServiceResult<IEnumerable<PersonalShipper>>> SearchShipper(string text);

        Task<ServiceResult<PersonalShipper>> AddShipper(PersonalShipper shipper);

        Task<ServiceResult<PersonalShipper>> EditShipper(PersonalShipper shipper);

        Task<ServiceResult<PersonalShipper>> DeleteShipper(int shipperId);

        Task<ServiceResult<IEnumerable<PersonalShipper>>> GetShippers();

        Task<ServiceResult<PersonalShipperTarget>> AddTarget(PersonalShipperTarget target);

        Task<ServiceResult<PersonalShipperTarget>> EditTarget(PersonalShipperTarget target);

        Task<ServiceResult<PersonalShipperTarget>> DeleteTarget(int targetId);

        Task<ServiceResult<IEnumerable<PersonalShipperTarget>>> GetTargets(int shipperId);

        Task<ServiceResult<PersonalShipperTargetCost>> AddCost(PersonalShipperTargetCost cost);

        Task<ServiceResult<PersonalShipperTargetCost>> EditCost(PersonalShipperTargetCost cost);

        Task<ServiceResult<PersonalShipperTargetCost>> DeleteCost(int costId);

        Task<ServiceResult<IEnumerable<PersonalShipperTargetCost>>> GetTargetCosts(int targetId);
    }
}
