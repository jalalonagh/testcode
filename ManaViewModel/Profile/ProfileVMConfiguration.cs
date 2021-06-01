using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.Profile
{
    internal class ProfileVMConfiguration : BaseVM<ProfileVM, Entities.Profile.Profile, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.Profile, ProfileVM> mapping)
        {
            mapping.ForMember(x => x.AccountingId, y => y.MapFrom(c => c.AccountingSystemId));
            mapping.ForMember(x => x.Avatar, y => y.MapFrom(c => c.ImageAddress));
            mapping.ForMember(x => x.CardNo, y => y.MapFrom(c => c.BankCarNo));
            mapping.ForMember(x => x.Day, y => y.MapFrom(c => c.DayBirthDate));
            mapping.ForMember(x => x.Month, y => y.MapFrom(c => c.MonthBirthDate));
            mapping.ForMember(x => x.NumberId, y => y.MapFrom(c => c.PhoneNumberId));
            mapping.ForMember(x => x.Number, y => y.MapFrom(c => c.PhoneNumber));
            mapping.ForMember(x => x.TeleNumber, y => y.MapFrom(c => c.TelePhoneNumber));
            mapping.ForMember(x => x.Year, y => y.MapFrom(c => c.YearBirthDate));
        }
    }
}