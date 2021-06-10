﻿using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteRangeByIdsAsync
{
    public class DeleteRangeByIdsAsyncCommand : CommandBase<ServiceResult<IEnumerable<Entities.Phone.Phone>>>
    {
        public DeleteRangeByIdsAsyncCommand(IEnumerable<int> ids)
        {
            EntityIds = ids;
        }

        public IEnumerable<int> EntityIds { get; }
    }
}