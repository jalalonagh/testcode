using BusinessBaseConfig.Configuration.Commands;
using Entities.Phone;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBusiness.BaseBusinessLevel.Phone.Command.AddAsync
{
    public class AddAsyncCommandHandler : ICommandHandler<AddAsyncCommand, ServiceResult<Entities.Phone.Phone>>
    {
        private readonly IBaseService<Entities.Phone.Phone, PhoneSearch> _service;
        private readonly ILogger<AddAsyncCommandHandler> _logger;

        public AddAsyncCommandHandler(ILogger<AddAsyncCommandHandler> logger, IBaseService<Entities.Phone.Phone, PhoneSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Phone.Phone>> Handle(AddAsyncCommand request, CancellationToken cancel)
        {
            return await _service.AddAsync(request.Model.ToEntity());
        }
    }
}