using Common;
using Common.Utilities;
using Data.Contracts;
using Entities.Wallet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Wallet
{
    public class WalletService : IWalletService, IScopedDependency
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<WalletSurvey> _walletSurvey;
        private readonly DbSet<Entities.Wallet.Wallet> _wallet;
        private readonly DbSet<WalletTransaction> _walletTransaction;
        private readonly ILogger<WalletService> _logger;

        public WalletService(IUnitOfWork uow, ILogger<WalletService> logger)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _walletSurvey = _uow.Set<WalletSurvey>();
            _wallet = _uow.Set<Entities.Wallet.Wallet>();
            _walletTransaction = _uow.Set<WalletTransaction>();
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<WalletSurvey>>> GetWalletSurvay()
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null);
            return await _walletSurvey.ToListAsync();
        }

        public async Task<ServiceResult<Entities.Wallet.Wallet>> CreateWallet(int profileId)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, profileId);
            var wallet = new Entities.Wallet.Wallet
            {
                ProfileId = profileId,
                Value = 0,
                WalletTransactions = new List<WalletTransaction> { new WalletTransaction { Value = 0, Description = "افتتاحیه", Type = WalletTransactionEnumType.Opening } }
            };

            await _wallet.AddAsync(wallet);
            await _uow.SaveChangesAsync();

            return wallet;
        }

        public async Task<ServiceResult<Entities.Wallet.Wallet>> GetWallet(string username)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username);
            return await _wallet.Include(z => z.Profile).ThenInclude(z => z.User).FirstAsync(z => z.Profile.User.UserName == username);
        }

        public async Task<ServiceResult<IEnumerable<WalletTransaction>>> GetWalletTransaction(string username)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, username);
            return await _walletTransaction.Include(z => z.Wallet).ThenInclude(z => z.Profile).ThenInclude(z => z.User).Where(z => z.Wallet.Profile.User.UserName == username).ToListAsync();
        }

        public async Task<ServiceResult> Increase(decimal value, int walletId)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, value, walletId);
            var wallet = await _wallet.FindAsync(walletId);

            await _walletTransaction.AddAsync(new WalletTransaction
            {
                Type = WalletTransactionEnumType.Increase,
                Value = value,
                WalletId = walletId,
                Description = "افزایش اعتبار",
            });
            wallet.Value += value;

            await _uow.SaveChangesAsync();

            return new ServiceResult(true, ApiResultStatusCode.Success);
        }

        public async Task<ServiceResult> Decrease(decimal value, int walletId)
        {
            Log.LogMethod(_logger, MethodBase.GetCurrentMethod(), null, value, walletId);
            var wallet = await _wallet.FindAsync(walletId);

            await _walletTransaction.AddAsync(new WalletTransaction
            {
                Type = WalletTransactionEnumType.Decrease,
                Value = value,
                WalletId = walletId,
                Description = "کاهش اعتبار",
            });
            wallet.Value -= value;

            await _uow.SaveChangesAsync();

            return new ServiceResult(true, ApiResultStatusCode.Success);
        }
    }
}