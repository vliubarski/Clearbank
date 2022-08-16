using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IStoreProvider _storeProvider;
        private readonly IValidationService _validationService;

        public AccountService(IStoreProvider storeProvider, IValidationService validationService)
        {
            _storeProvider = storeProvider;
            _validationService = validationService;
    }

    public void UpdateAccount(Account account, string dataStoreType, decimal amount)
        {
            var dataStore = _storeProvider.GetDataStoreByType(dataStoreType);
            account.Balance -= amount;
            dataStore.UpdateAccount(account);
        }

        public Account GetAccount(string dataStoreType, string accountNumber)
        {
            var dataStore = _storeProvider.GetDataStoreByType(dataStoreType);
            return dataStore.GetAccount(accountNumber);
        }

        public MakePaymentResult ValidateAccountForPaymentRequest(Account account, MakePaymentRequest request)
        {
            var result = new MakePaymentResult();

            var validationData = new ValidationData
            {
                Account = account,
                AmountToDeduct = request.Amount
            };

            switch (request.PaymentScheme)
            {
                case PaymentScheme.FasterPayments:
                    result.Success = _validationService.ValidateFasterPayments(validationData);
                    break;
                case PaymentScheme.Bacs:
                    result.Success = _validationService.ValidateBacs(validationData);
                    break;
                case PaymentScheme.Chaps:
                    result.Success = _validationService.ValidateChaps(validationData);
                    break;
            }
            return result;
        }
    }
}
