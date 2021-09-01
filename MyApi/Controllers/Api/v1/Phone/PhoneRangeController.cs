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
    public class PhoneRangeController : GenericController<Phone, PhoneValidator, PhoneSearch, PhoneVM, PhoneDTO, int>
    {
        private ICrud<Phone, PhoneValidator, PhoneSearch, PhoneDTO, int> crud;
        ResourceManagerSingleton resource;

        public PhoneRangeController(ICrud<Phone, PhoneValidator, PhoneSearch, PhoneDTO, int> _crud) : base(_crud)
        {
            resource = ResourceManagerSingleton.GetInstance();
            crud = _crud;
        }
    }
}