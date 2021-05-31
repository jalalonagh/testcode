//using BusinessLayout.Configuration.Commands;
//using BusinessLayout.Profile.Share.Dto;
//using BusinessLayout.Profile.Share.ViewModels;
//using Microsoft.AspNetCore.Http;
//using Services;

//namespace BusinessLayout.Profile.Command.ChangeSecondPassword
//{
//    public class ChangeSecondPasswordCommand : CommandBase<ServiceResult>
//    {
//        public ChangeSecondPasswordCommand(string password, string newPassword, string username)
//        {
//            Password = password;
//            Username = username;
//            NewPassword = newPassword;
//        }

//        public string Password { get; }
//        public string NewPassword { get; }
//        public string Username { get; }
//    }
//}