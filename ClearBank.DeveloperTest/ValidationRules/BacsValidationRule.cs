using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.ValidationRules
{
    public class BacsValidationRule : IBacsValidationRule
    {
        public bool IsValidAccount(ValidationData validationData)
        {
            return
                validationData.Account != null
                && validationData.Account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs);
        }
    }
}
