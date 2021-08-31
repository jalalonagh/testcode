using BusinessBaseConfig;
using ProfileBusiness;
using SMSBusiness;
using SMSConfirmationBusiness;
using SMSRegexBusiness;
using System.Reflection;
using TransactionBusiness;
using UserBusiness;

namespace WebFramework.Configuration.Autofac
{
    public static class Assemblies
    {
        public static readonly Assembly Application = typeof(IBL).Assembly;
        public static readonly Assembly[] Applications = new Assembly[] { typeof(IBL).Assembly, typeof(IPrB).Assembly,
            typeof(ISmB).Assembly, typeof(ISCB).Assembly, typeof(ISRB).Assembly, typeof(ITrB).Assembly, typeof(IUsB).Assembly};
    }
}
