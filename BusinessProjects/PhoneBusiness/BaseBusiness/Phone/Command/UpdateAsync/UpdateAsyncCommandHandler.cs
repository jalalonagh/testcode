using BusinessBaseConfig.Configuration.Commands;
using Entities.Phone;
using Microsoft.Extensions.Logging;
using Services.Base.Contracts;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel.Phone.Command.UpdateAsync
{
    public class UpdateAsyncCommandHandler : ICommandHandler<UpdateAsyncCommand, ServiceResult<Entities.Phone.Phone>>
    {
        private readonly IBaseService<Entities.Phone.Phone, PhoneSearch> _service;
        private readonly ILogger<UpdateAsyncCommandHandler> _logger;

        public UpdateAsyncCommandHandler(ILogger<UpdateAsyncCommandHandler> logger, IBaseService<Entities.Phone.Phone, PhoneSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Phone.Phone>> Handle(UpdateAsyncCommand request, CancellationToken cancel)
        {
            return await _service.UpdateAsync(request.Model.ToEntity());
        }
    }
}