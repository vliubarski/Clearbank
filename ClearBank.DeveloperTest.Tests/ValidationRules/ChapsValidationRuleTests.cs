using NUnit.Framework;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.ValidationRules;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class ChapsValidationRuleTests
    {
        ChapsValidationRule _chapsValidationRule = new ChapsValidationRule();

        [Test]
        [TestCase(AllowedPaymentSchemes.Bacs, AccountStatus.Disabled, false)]
        [TestCase(AllowedPaymentSchemes.Bacs, AccountStatus.Live, false)]
        [TestCase(AllowedPaymentSchemes.Chaps, AccountStatus.Disabled, false)]
        [TestCase(AllowedPaymentSchemes.Chaps, AccountStatus.Live, true)]
        public void When_MakePayment_Called_Then_AccountServiceGetAccount_Called(AllowedPaymentSchemes scheme, AccountStatus status, bool expect)
        {
            ValidationData validationData = new ValidationData 
            {
                Account = new Account { AllowedPaymentSchemes = scheme, Status = status }
            };
            bool res = _chapsValidationRule.IsValidAccount(validationData);
            Assert.AreEqual(expect, res);
        }
    }
}
