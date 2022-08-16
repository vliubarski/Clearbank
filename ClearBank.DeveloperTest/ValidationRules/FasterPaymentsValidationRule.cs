using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.ValidationRules
{
    public class FasterPaymentsValidationRule : IFasterPaymentsValidationRule
    {
        public bool IsValidAccount(ValidationData validationData)
        {
            return
                validationData.Account != null
                && validationData.Account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments)
                && validationData.Account.Balance > validationData.AmountToDeduct;
        }
    }
}
