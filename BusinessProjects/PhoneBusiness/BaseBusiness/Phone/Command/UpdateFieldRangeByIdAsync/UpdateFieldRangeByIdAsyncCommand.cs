﻿using BusinessBaseConfig.Configuration.Commands;
using Services.Models;
using System.Collections.Generic;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommand : CommandBase<ServiceResult<Entities.Phone.Phone>>
    {
        public UpdateFieldRangeByIdAsyncCommand(int id, params KeyValuePair<string, dynamic>[] fields)
        {
            EntityId = id;
            Fields = fields;
        }

        public int EntityId { get; }
        public KeyValuePair<string, dynamic>[] Fields { get; }
    }
}