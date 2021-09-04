﻿using BaseBusiness;
using Entities.Phone;
using ManaDataTransferObject.Phone;
using ManaEntitiesValidation.Phone;
using ManaResourceManager;
using ManaViewModel.Phone;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class PhoneRangeController : GenericRangeController<Phone, PhoneValidator, PhoneVM, PhoneDTO>
    {
        private ICrudRange<Phone, PhoneValidator> crud;
        ResourceManagerSingleton resource;

        public PhoneRangeController(ICrudRange<Phone, PhoneValidator> _crud) : base(_crud)
        {
            resource = ResourceManagerSingleton.GetInstance();
            crud = _crud;
        }
    }
}