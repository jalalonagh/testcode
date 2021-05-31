using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.SMS
{
    internal class SMSVMConfiguration : BaseVM<SMSVM, Entities.SMS.SMS, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.SMS.SMS, SMSVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}