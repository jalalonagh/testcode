using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Profile
{
    internal class ProfileDTOConfiguration : BaseDTO<ProfileDTO, Entities.Profile.Profile, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.Profile, ProfileDTO> mapping)
        {
            mapping.ForMember(x => x.AccountingId, y => y.MapFrom(c => c.AccountingSystemId));
            mapping.ForMember(x => x.BankCardNo, y => y.MapFrom(c => c.BankCarNo));
            mapping.ForMember(x => x.Email, y => y.MapFrom(c => c.EmailAddress));
            mapping.ForMember(x => x.Image, y => y.MapFrom(c => c.ImageAddress));
            mapping.ForMember(x => x.PhoneId, y => y.MapFrom(c => c.PhoneNumberId));
            mapping.ForMember(x => x.TelePhone, y => y.MapFrom(c => c.TelePhoneNumber));
        }
    }
}