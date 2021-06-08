﻿using Entities.Phone;
using ManaDataTransferObject.Phone;
using ManaViewModel.Phone;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class PhoneCommandsController : BaseBusinessCommandController<Phone, PhoneDTO, PhoneVM, PhoneSearch, int>
    {
        private readonly ILogger<PhoneCommandsController> _logger;
        private IMediator mediator;

        public PhoneCommandsController(ILogger<PhoneCommandsController> logger, IMediator _mediator):base(_mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }
    }
}