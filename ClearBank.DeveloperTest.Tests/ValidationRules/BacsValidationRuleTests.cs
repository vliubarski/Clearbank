using NUnit.Framework;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.ValidationRules;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class BacsValidationRuleTests
    {
        BacsValidationRule _bacsValidationRule = new BacsValidationRule();

        [Test]
        [TestCase(AllowedPaymentSchemes.Bacs, true)]
        [TestCase(AllowedPaymentSchemes.Chaps, false)]
        public void When_MakePayment_Called_Then_AccountServiceGetAccount_Called(AllowedPaymentSchemes scheme, bool expect)
        {
            ValidationData validationData = new ValidationData 
            {
                Account = new Account { AllowedPaymentSchemes = scheme }
            };
            bool res = _bacsValidationRule.IsValidAccount(validationData);
            Assert.AreEqual(expect, res);
        }
    }
}
