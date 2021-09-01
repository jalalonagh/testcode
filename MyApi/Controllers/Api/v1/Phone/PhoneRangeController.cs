using BaseBusiness;
using Entities.Phone;
using ManaDataTransferObject.Phone;
using ManaEntitiesValidation.Phone;
using ManaResourceManager;
using ManaViewModel.Phone;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class PhoneRangeController : GenericRangeController<Phone, PhoneValidator, PhoneSearch, PhoneVM, PhoneDTO>
    {
        private ICrudRange<Phone, PhoneValidator, PhoneSearch, PhoneDTO> crud;
        ResourceManagerSingleton resource;

        public PhoneRangeController(ICrudRange<Phone, PhoneValidator, PhoneSearch, PhoneDTO> _crud) : base(_crud)
        {
            resource = ResourceManagerSingleton.GetInstance();
            crud = _crud;
        }
    }
}