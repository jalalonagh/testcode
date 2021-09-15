using BaseBusiness;
using Entities.Phone;
using ManaEntitiesValidation.Phone;
using ManaResourceManager;
using Microsoft.AspNetCore.Mvc;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class PhoneRangeController : BaseController
    {
        private ICrudRange<Phone, PhoneValidator> crud;
        ResourceManagerSingleton resource;

        public PhoneRangeController(ICrudRange<Phone, PhoneValidator> _crud)
        {
            resource = ResourceManagerSingleton.GetInstance();
            crud = _crud;
        }
    }
}