using Common.Exceptions;
using Common.Utilities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.User
{
    public class UserRepository: Repository<Entities.User.User, Entities.User.UserSearch>, IUserRepository
    {
        protected readonly ApplicationDbContext DbContext;

        public DbContext Database { get { return DbContext; } }

        public DbSet<Entities.User.User> Entities { get; }
        public IQueryable<Entities.User.User> Table => Entities;
        public IQueryable<Entities.User.User> TableNoTracking => Entities.AsNoTracking();

        public UserRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<Entities.User.User>();
        }

        public Task<Entities.User.User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken)
        {
            var passwordHash = SecurityHelper.GetSha256Hash(password);
            return Table.Where(p => p.UserName == username && p.PasswordHash == passwordHash).SingleOrDefaultAsync(cancellationToken);
        }

        public Task UpdateSecuirtyStampAsync(Entities.User.User user, CancellationToken cancellationToken)
        {
            return UpdateAsync(user, cancellationToken);
        }

        public Task UpdateLastLoginDateAsync(Entities.User.User user, CancellationToken cancellationToken)
        {
            user.LastLoginDate = DateTimeOffset.Now;
            return UpdateAsync(user, cancellationToken);
        }

        public async Task AddAsync(Entities.User.User user, string password, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.UserName == user.UserName);
            if (exists)
                throw new BadRequestException("نام کاربری تکراری است");

            var passwordHash = SecurityHelper.GetSha256Hash(password);
            user.PasswordHash = passwordHash;
            await base.AddAsync(user, cancellationToken);
        }

        new public virtual async Task<Entities.User.User> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return await Entities.Where(w => ids.Contains(w.Id)).FirstOrDefaultAsync();
        }
    }
}
