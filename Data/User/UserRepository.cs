using Common.Exceptions;
using Common.Utilities;
using ManaSpeedTester;
using ManaSpeedTester.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Data.User
{
    public class UserRepository : Repository<Entities.User.User, Entities.User.UserSearch>, IUserRepository
    {
        protected readonly ApplicationDbContext DbContext;
        private TimeDurationTrackerSingleton tester;

        public DbContext Database { get { return DbContext; } }

        public DbSet<Entities.User.User> Entities { get; }
        public IQueryable<Entities.User.User> Table => Entities;
        public IQueryable<Entities.User.User> TableNoTracking => Entities.AsNoTracking();

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<Entities.User.User>();
            tester = TimeDurationTrackerSingleton.Instance;
        }

        public Task<Entities.User.User> GetByUserAndPass(string username, string password)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var passwordHash = SecurityHelper.GetSha256Hash(password);
            var result = Table.Where(p => p.UserName == username && p.PasswordHash == passwordHash).SingleOrDefaultAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), username, password));      // SAVE SPEEDT TEST RESULT
            return result;
        }

        public Task UpdateSecuirtyStampAsync(Entities.User.User user)
        {
            return UpdateAsync(user);
        }

        public Task UpdateLastLoginDateAsync(Entities.User.User user)
        {
            user.LastLoginDate = DateTimeOffset.Now;
            return UpdateAsync(user);
        }

        public async Task AddAsync(Entities.User.User user, string password)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var exists = await TableNoTracking.AnyAsync(p => p.UserName == user.UserName);
            if (exists)
                throw new BadRequestException("نام کاربری تکراری است");

            var passwordHash = SecurityHelper.GetSha256Hash(password);
            user.PasswordHash = passwordHash;
            var result = await base.AddAsync(user);
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), user, password));      // SAVE SPEEDT TEST RESULT
        }

        new public virtual async Task<Entities.User.User> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            var start = DateTime.Now;       // START SPEED TEST
            var result = await Entities.Where(w => ids.Contains(w.Id)).FirstOrDefaultAsync();
            tester.SaveRepositoySpeed(new TestInput(start, DateTime.Now, MethodInfo.GetCurrentMethod(), ids));      // SAVE SPEEDT TEST RESULT
            return result;
        }
    }
}
