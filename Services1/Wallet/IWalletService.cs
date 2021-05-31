using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Wallet;

namespace Services.Wallet
{
    public interface IWalletService
    {
        Task<ServiceResult> Decrease(decimal value, int walletId);
        Task<ServiceResult<Entities.Wallet.Wallet>> GetWallet(string username);
        Task<ServiceResult<IEnumerable<WalletSurvey>>> GetWalletSurvay();
        Task<ServiceResult<IEnumerable<WalletTransaction>>> GetWalletTransaction(string username);
        Task<ServiceResult> Increase(decimal value, int walletId);
        Task<ServiceResult<Entities.Wallet.Wallet>> CreateWallet(int profileId);
    }
}