using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.User
{
    internal class UserVMConfiguration : BaseInterfaceVM<UserVM, Entities.User.User, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.User, UserVM> mapping)
        {
            mapping.ForMember(x => x.SaleCustomerCu, y => y.MapFrom(c => c.SalcustCu));
            mapping.ForMember(x => x.SaleCustomerSi, y => y.MapFrom(c => c.SalcustSi));
            mapping.ForMember(x => x.SaleCustomerTp, y => y.MapFrom(c => c.SalcustTp));
        }
    }
}
