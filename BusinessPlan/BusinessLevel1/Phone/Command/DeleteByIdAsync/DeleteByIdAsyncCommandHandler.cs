using BusinessLayout.Configuration.Commands;
using Entities.Phone;
using Microsoft.Extensions.Logging;
using Services;
using Services.Base.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.DeleteByIdAsync
{
    public class DeleteByIdAsyncCommandHandler : ICommandHandler<DeleteByIdAsyncCommand, ServiceResult<Entities.Phone.Phone>>
    {
        private readonly IBaseService<Entities.Phone.Phone, PhoneSearch> _service;
        private readonly ILogger<DeleteByIdAsyncCommandHandler> _logger;

        public DeleteByIdAsyncCommandHandler(ILogger<DeleteByIdAsyncCommandHandler> logger, IBaseService<Entities.Phone.Phone, PhoneSearch> service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResult<Entities.Phone.Phone>> Handle(DeleteByIdAsyncCommand request, CancellationToken cancel)
        {
            return await _service.DeleteByIdAsync(request.EntityId);
        }
    }
}