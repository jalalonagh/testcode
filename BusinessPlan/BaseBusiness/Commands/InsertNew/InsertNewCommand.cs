//using BusinessLayout.Configuration.Commands;
//using BusinessLayout.Profile.Share.Dto;
//using BusinessLayout.Profile.Share.ViewModels;
//using Microsoft.AspNetCore.Http;
//using Services;

//namespace BusinessLayout.Profile.Command.InsertNew
//{
//    public class InsertNewCommand<TInEntity, TOutEntity> : CommandBase<ServiceResult<TOutEntity>>
//    {
//        public InsertNewCommand<TInEntity, TOutEntity>(TInEntity request)
//        {
//            Password = password;
//            Username = username;
//        }

//        public TInEntity Request { get; }
//        public string Username { get; }
//    }
//}