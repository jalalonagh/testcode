﻿using BusinessBaseConfig.Configuration.Commands;
using Entities.SMSConfirmation;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SMSConfirmationBusiness.BaseBusinessLevel.SMSConfirmation.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommandHandler : ICommandHandler<UpdateFieldRangeByIdAsyncCommand, ServiceResult<Entities.SMSConfirmation.SMSConfirmation>>
    {
        private readonly IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> _service;
        private readonly ILogger<UpdateFieldRangeByIdAsyncCommandHandler> _logger;

        public UpdateFieldRangeByIdAsyncCommandHandler(ILogger<UpdateFieldRangeByIdAsyncCommandHandler> logger, IBaseService<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.SMSConfirmation.SMSConfirmation>> Handle(UpdateFieldRangeByIdAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateFieldRangeByIdAsync(request.EntityId, request.Fields);
        }
    }
}