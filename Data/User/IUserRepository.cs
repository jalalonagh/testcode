using ManaBaseData.Repositories;
using System.Threading.Tasks;

namespace Data.User
{
    public interface IUserRepository : IRepository<Entities.User.User>
    {
        Task<Entities.User.User> GetByUserAndPass(string username, string password);
        Task UpdateSecuirtyStampAsync(Entities.User.User user);
        Task UpdateLastLoginDateAsync(Entities.User.User user);
        Task AddAsync(Entities.User.User user, string password);
    }
}
