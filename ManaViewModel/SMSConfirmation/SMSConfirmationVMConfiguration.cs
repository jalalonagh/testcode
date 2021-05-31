using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.SMSConfirmation
{
    internal class SMSConfirmationVMConfiguration : BaseVM<SMSConfirmationVM, Entities.SMSConfirmation.SMSConfirmation, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}