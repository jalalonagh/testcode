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
    public class PhoneFilterController : GenericFilterController<Phone, PhoneValidator, PhoneSearch, PhoneVM, PhoneDTO, int>
    {
        private IFilter<Phone, PhoneValidator, PhoneSearch, PhoneDTO, int> crud;
        ResourceManagerSingleton resource;

        public PhoneFilterController(IFilter<Phone, PhoneValidator, PhoneSearch, PhoneDTO, int> _crud) : base(_crud)
        {
            resource = ResourceManagerSingleton.GetInstance();
            crud = _crud;
        }
    }
}