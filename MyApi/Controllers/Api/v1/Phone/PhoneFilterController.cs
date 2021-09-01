using BaseBusiness;
using Entities.Phone;
using ManaEntitiesValidation.Phone;
using ManaResourceManager;
using ManaViewModel.Phone;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class PhoneFilterController : GenericFilterController<Phone, PhoneValidator, PhoneSearch, PhoneVM>
    {
        private IFilter<Phone, PhoneValidator, PhoneSearch> crud;
        ResourceManagerSingleton resource;

        public PhoneFilterController(IFilter<Phone, PhoneValidator, PhoneSearch> _crud) : base(_crud)
        {
            resource = ResourceManagerSingleton.GetInstance();
            crud = _crud;
        }
    }
}