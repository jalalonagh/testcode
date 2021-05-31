//using System;
//using AutoMapper;
//using Entities.User;
//using ViewModels.AutoMapepr;

//namespace ViewModels.User
//{

//    public class SuspendedUserDTO : BaseNotIdDto<SuspendedUserDTO, SuspendedUser>
//    {
//        public string PhoneNumber { get; set; }
//        //public bool PhoneNumberConfirmated { get; set; }
//        //public string ValidCode { get; set; }
//        //public DateTime ValidCodeExpired { get; set; }
//    }
//    public class SuspendedUserConfirmDTO : BaseNotIdDto<SuspendedUserConfirmDTO, SuspendedUser>
//    {
//        public string PhoneNumber { get; set; }
//        public string Code { get; set; }
//        //public bool PhoneNumberConfirmated { get; set; }
//        //public string ValidCode { get; set; }
//        //public DateTime ValidCodeExpired { get; set; }
//        public override void CustomMappings(IMappingExpression<SuspendedUser, SuspendedUserConfirmDTO> mapping)
//        {
//            mapping.ForMember(z => z.Code, z => z.MapFrom(x=>x.ValidCode));
//            base.CustomMappings(mapping);
//        }
//        public override void CustomMappingsReverse(IMappingExpression<SuspendedUserConfirmDTO, SuspendedUser> mapping)
//        {
//            mapping.ForMember(z => z.ValidCode, z => z.MapFrom(x => x.Code));
//            base.CustomMappingsReverse(mapping);
//        }
//    }
//}
