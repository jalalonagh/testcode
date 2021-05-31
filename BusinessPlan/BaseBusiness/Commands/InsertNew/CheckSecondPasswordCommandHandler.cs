//using BusinessLayout.Configuration.Commands;
//using Common.Utilities;
//using Entities;
//using Microsoft.Extensions.Logging;
//using Services;
//using System.Reflection;
//using System.Resources;
//using System.Threading;
//using System.Threading.Tasks;

//namespace BusinessLayout.Profile.Command.InsertNew
//{
//    public class InsertNewCommandHandler<TEntity, TInEntity, TOutEntity> : ICommandHandler<InsertNewCommand, ServiceResult<TOutEntity>>
//        where TEntity: class, IEntity
//        where TInEntity: class, new()
//        where TOutEntity: class
//    {
//        private readonly ResourceManager _resourceManager;
//        private readonly ILogger<InsertNewCommandHandler> _logger;

//        public InsertNewCommandHandler(IProfileService profileService,
//                                                     ResourceManager resourceManager,
//                                                     ILogger<InsertNewCommandHandler> logger)
//        {
//            _profileService = profileService;
//            _resourceManager = resourceManager;
//            _logger = logger;
//        }

//        public async Task<ServiceResult> Handle(InsertNewCommand request, CancellationToken cancellationToken)
//        {
//            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, request, cancellationToken);

//            return await _profileService.InsertNew(request.Password, request.Username);
//        }
//    }
//}