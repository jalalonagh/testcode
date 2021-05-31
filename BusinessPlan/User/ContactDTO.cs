//using AutoMapper;
//using Entities;
//using System;
//using ViewModels.AutoMapepr;

//namespace ViewModels.Sale
//{
//    [Serializable]
//    public class ContactDTO : BaseDto<ContactDTO, Entities.Contact>
//    {
//        public string Value { get; set; }
//        public ContactTypeEnum ContactTypeId { get; set; }
//    }

//    [Serializable]
//    public class ContactEditeDTO : BaseDto<ContactEditeDTO, Entities.Contact>
//    {
//        public string Value { get; set; }
//        public ContactTypeEnum ContactType_Id { get; set; }
//        public override void CustomMappings(IMappingExpression<Contact, ContactEditeDTO> mapping)
//        {
//            mapping.ForMember(z => z.ContactType_Id, x => x.MapFrom(c => c.ContactTypeId));
//            //base.CustomMappings(mapping);
//        }
//        public override void CustomMappingsReverse(IMappingExpression<ContactEditeDTO, Contact> mapping)
//        {
//            mapping.ForMember(z => z.ContactTypeId, x => x.MapFrom(c => c.ContactType_Id));

//            //base.CustomMappingsReverse(mapping);
//        }
//    }


//}
