using NUnit.Framework;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.ValidationRules;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class FasterPaymentsValidationRuleTests
    {
        FasterPaymentsValidationRule _fasterPaymentsValidationRule = new FasterPaymentsValidationRule();

        [Test]
        [TestCase(AllowedPaymentSchemes.Bacs, 0, false)]
        [TestCase(AllowedPaymentSchemes.Bacs, 1, false)]
        [TestCase(AllowedPaymentSchemes.FasterPayments, 0, false)]
        [TestCase(AllowedPaymentSchemes.FasterPayments, 1, true)]
        public void When_MakePayment_Called_Then_AccountServiceGetAccount_Called(AllowedPaymentSchemes scheme, decimal balance, bool expect)
        {
            ValidationData validationData = new ValidationData 
            {
                Account = new Account { AllowedPaymentSchemes = scheme, Balance = balance }
            };
            bool res = _fasterPaymentsValidationRule.IsValidAccount(validationData);
            Assert.AreEqual(expect, res);
        }
    }
}
