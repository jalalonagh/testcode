﻿using BusinessBaseConfig.Configuration.Commands;
using Services.Models;
using System.Collections.Generic;

namespace SMSRegexBusiness.BaseBusinessLevel.SMSRegex.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.SMSRegex.SMSRegex>>>
    {
        public DeleteRangeByIdsAsyncCommand(IEnumerable<int> ids)
        {
            EntityIds = ids;
        }

        public IEnumerable<int> EntityIds { get; }
    }
}