using Data.Repositories;
using Entities.User;
using Entities.User.Role;
using System.Linq;

namespace Services.DataInitializer
{
    public class RoleDataInitializer : IDataInitializer
    {
        private readonly IRepository<Role, RoleSearch> repository;

        public RoleDataInitializer(IRepository<Role, RoleSearch> repository)
        {
            this.repository = repository;
        }

        public void InitializeData()
        {
            if (!repository.Entities.Any())
            {
                repository.AddAsync(new Role { Name = "مدیر", Description = "مدیر سایت" });
                repository.AddAsync(new Role { Name = "متقاضی", Description = "متقاضی سایت" });
                repository.AddAsync(new Role { Name = "مرکز", Description = "مرکز طف قرار داد سایت" });
            }
        }
    }
}
