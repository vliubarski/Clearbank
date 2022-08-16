using NUnit.Framework;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using ClearBank.DeveloperTest.ValidationRules;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class ValidationServiceTests
    {
        private readonly Mock<IBacsValidationRule> _bacsValidationRuleMock = new Mock<IBacsValidationRule>();
        private readonly Mock<IChapsValidationRule> _chapsValidationRuleMock = new Mock<IChapsValidationRule>();
        private readonly Mock<IFasterPaymentsValidationRule> _fasterPaymentsValidationRuleMock = new Mock<IFasterPaymentsValidationRule>();
        private ValidationService _validationService;
        ValidationData _validationData = new ValidationData();

        public ValidationServiceTests()
        {
            _validationService = new ValidationService(_bacsValidationRuleMock.Object,
                _chapsValidationRuleMock.Object, _fasterPaymentsValidationRuleMock.Object);
        }

        [Test]
        public void When_ValidateBacs_Called_Then_BacsValidationRuleIsValidAccount_Called()
        {
            _validationService.ValidateBacs(_validationData);

            _bacsValidationRuleMock.Verify(x => x.IsValidAccount(_validationData), Times.Once);
        }

        [Test]
        public void When_ValidateChaps_Called_Then_ChapsValidationRuleIsValidAccount_Called()
        {
            _validationService.ValidateChaps(_validationData);

            _chapsValidationRuleMock.Verify(x => x.IsValidAccount(_validationData), Times.Once);
        }

        [Test]
        public void When_ValidateFasterPayments_Called_Then_FasterPaymentsValidationRuleIsValidAccount_Called()
        {
            _validationService.ValidateFasterPayments(_validationData);

            _fasterPaymentsValidationRuleMock.Verify(x => x.IsValidAccount(_validationData), Times.Once);
        }
    }
}
