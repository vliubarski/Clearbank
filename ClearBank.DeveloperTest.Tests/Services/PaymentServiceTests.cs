using NUnit.Framework;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using System.Configuration;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PrintServiceTests
    {
        private PaymentService _paymentService;
        private readonly Mock<IAccountService> _accountServiceMock = new Mock<IAccountService>();
        private string dataStoreTypeValue = "test setting";
        private MakePaymentRequest request = new MakePaymentRequest();

        public PrintServiceTests()
        {
            ConfigurationManager.AppSettings["DataStoreType"] = dataStoreTypeValue;
        }

        [Test]
        public void When_MakePayment_Called_Then_AccountServiceGetAccount_Called()
        {
            _accountServiceMock.Setup(x => x.ValidateAccountForPaymentRequest(It.IsAny<Account>(), request)).Returns(new MakePaymentResult());
            _paymentService = new PaymentService(_accountServiceMock.Object);

            _paymentService.MakePayment(request);

            _accountServiceMock.Verify(x => x.GetAccount(dataStoreTypeValue, request.DebtorAccountNumber), Times.Once);
        }


        [Test]
        public void When_MakePayment_Called_Then_AccountServiceValidateAccountForPaymentRequest_Called()
        {
            var account = new Account();

            _accountServiceMock.Setup(x => x.GetAccount(dataStoreTypeValue, request.DebtorAccountNumber)).Returns(account);
            _accountServiceMock.Setup(x => x.ValidateAccountForPaymentRequest(It.IsAny<Account>(), request)).Returns(new MakePaymentResult());

            _paymentService = new PaymentService(_accountServiceMock.Object);

            _paymentService.MakePayment(request);

            _accountServiceMock.Verify(x => x.ValidateAccountForPaymentRequest(account, request), Times.Once);
        }


        [Test]
        [TestCase(true, 1)]
        [TestCase(false, 0)]
        public void When_MakePayment_Called_Then_DataStoreServiceUpdateAccount_Called(bool success, int calledTimes)
        {
            var account = new Account();
            var paymentResult = new MakePaymentResult { Success = success };

            _accountServiceMock.Setup(x => x.GetAccount(dataStoreTypeValue, request.DebtorAccountNumber)).Returns(account);
            _accountServiceMock.Setup(x => x.ValidateAccountForPaymentRequest(It.IsAny<Account>(), request)).Returns(paymentResult);

            _paymentService = new PaymentService(_accountServiceMock.Object);

            _paymentService.MakePayment(request);

            _accountServiceMock.Verify(x => x.UpdateAccount(account, dataStoreTypeValue, request.Amount), Times.Exactly(calledTimes));
        }
    }
}
