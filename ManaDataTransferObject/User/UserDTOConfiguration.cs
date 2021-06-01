using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User
{
    internal class UserDTOConfiguration : BaseInterfaceDTO<UserDTO, Entities.User.User, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.User, UserDTO> mapping)
        {
            mapping.ForMember(x => x.AccountingId, y => y.MapFrom(c => c.AccountingUserReferenceId));
            mapping.ForMember(x => x.SCu, y => y.MapFrom(c => c.SalcustCu));
            mapping.ForMember(x => x.SSi, y => y.MapFrom(c => c.SalcustSi));
            mapping.ForMember(x => x.STp, y => y.MapFrom(c => c.SalcustTp));
        }
    }
}