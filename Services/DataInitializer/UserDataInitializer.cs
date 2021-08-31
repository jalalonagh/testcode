using Data.User;
using Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Services.DataInitializer
{
    /// <summary>
    /// تولید کننده محتوا برای کاربر
    /// </summary>
    public class UserDataInitializer : IDataInitializer
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> manager;
        public UserDataInitializer(IUserRepository repository, UserManager<User> user)
        {
            userRepository = repository;
            manager = user;
        }

        public void InitializeData()
        {
            //if (!userRepository.TableNoTracking.Any(p => p.UserName == "Admin"))
            //{

            //    var result = manager.CreateAsync(new User
            //    {
            //        EmailConfirmed = false,
            //        PhoneNumber = "09354320819",
            //        TwoFactorEnabled = false,
            //        LockoutEnabled = false,
            //        AccessFailedCount = 0,
            //        IsActive = true,
            //        UserName = "Admin",
            //        Email = "admin@site.com",
            //        Age = 25,
            //        FullName = "administrator",
            //        Gender = ManaEnums.Entity.User.UserGenderType.MALE,
            //    }, "1234567").Result;
            //}
        }
    }
}
