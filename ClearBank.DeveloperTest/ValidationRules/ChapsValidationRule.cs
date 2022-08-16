using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.ValidationRules
{
    public class ChapsValidationRule : IChapsValidationRule
    {
        public bool IsValidAccount(ValidationData validationData)
        {
            return
                validationData.Account != null
                && validationData.Account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps)
                && validationData.Account.Status == AccountStatus.Live;
        }
    }
}
