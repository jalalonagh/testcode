using BusinessBaseConfig.Configuration.Queries;
using Services.Models;
using System.Collections.Generic;

namespace BusinessLayout.BaseBusinessLevel.Profile.Query.GetAllAsync
{
    public class ProfileGetAllAsyncQuery : IQuery<ServiceResult<IEnumerable<Entities.Profile.Profile>>>
    {
        public ProfileGetAllAsyncQuery(int total, int more)
        {
            Total = total;
            More = more;
        }

        public int Total { get; }
        public int More { get; }
    }
}