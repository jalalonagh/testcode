using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.SMSRegex
{
    internal class SMSRegexVMConfiguration : BaseVM<SMSRegexVM, Entities.SMSRegex.SMSRegex, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.SMSRegex.SMSRegex, SMSRegexVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}