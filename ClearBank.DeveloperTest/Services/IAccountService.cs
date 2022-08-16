using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountService
    {
        Account GetAccount(string dataStoreType, string accNumber);
        MakePaymentResult ValidateAccountForPaymentRequest(Account account, MakePaymentRequest request);

        void UpdateAccount(Account account, string dataStoreType, decimal amount);
    }
}