using ClearBank.DeveloperTest.Types;
using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountService _accountService;

        public PaymentService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

            Account account = _accountService.GetAccount(dataStoreType, request.DebtorAccountNumber);

            var result = _accountService.ValidateAccountForPaymentRequest(account, request);

            if (result.Success)
            {
                _accountService.UpdateAccount(account, dataStoreType, request.Amount);
            }

            return result;
        }
    }
}
