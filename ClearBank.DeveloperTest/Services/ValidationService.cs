using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.ValidationRules;

namespace ClearBank.DeveloperTest.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IBacsValidationRule _bacsValidationRule;
        private readonly IChapsValidationRule _chapsValidationRule;
        private readonly IFasterPaymentsValidationRule _fasterPaymentsValidationRule;

        public ValidationService(IBacsValidationRule bacsValidationRule, 
            IChapsValidationRule chapsValidationRule, IFasterPaymentsValidationRule fasterPaymentsValidationRule)

        {
            _bacsValidationRule = bacsValidationRule;
            _chapsValidationRule = chapsValidationRule;
            _fasterPaymentsValidationRule = fasterPaymentsValidationRule;
        }

        public bool ValidateBacs(ValidationData validationData)
        {
            return _bacsValidationRule.IsValidAccount(validationData);
        }

        public bool ValidateFasterPayments(ValidationData validationData)
        {
            return _fasterPaymentsValidationRule.IsValidAccount(validationData);
        }

        public bool ValidateChaps(ValidationData validationData)
        {
            return _chapsValidationRule.IsValidAccount(validationData);
        }
    }
}
