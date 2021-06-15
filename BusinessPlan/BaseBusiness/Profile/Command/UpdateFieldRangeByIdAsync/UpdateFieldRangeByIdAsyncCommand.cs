﻿using BusinessLayout.Configuration.Commands;
using Services;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Profile.Command.UpdateFieldRangeByIdAsync
{
    public class UpdateFieldRangeByIdAsyncCommand : CommandBase<ServiceResult<Entities.Profile.Profile>>
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