using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.ValidationRules
{
    public interface IPaymentRule
    {
        bool IsValidAccount(ValidationData validationData);
    }
}