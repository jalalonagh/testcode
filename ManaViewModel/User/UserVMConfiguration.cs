using AutoMapper;
using ManaViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
