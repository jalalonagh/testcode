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
        }
    }
}
