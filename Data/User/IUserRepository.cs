using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.User
{
    public interface IUserRepository: IRepository<Entities.User.User, Entities.User.UserSearch>
    {
        Task<Entities.User.User> GetByUserAndPass(string username, string password);
        Task UpdateSecuirtyStampAsync(Entities.User.User user);
        Task UpdateLastLoginDateAsync(Entities.User.User user);
        Task AddAsync(Entities.User.User user, string password);
    }
}
