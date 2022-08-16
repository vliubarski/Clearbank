using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IValidationService
    {
        bool ValidateBacs(ValidationData validationData);
        bool ValidateChaps(ValidationData validationData);
        bool ValidateFasterPayments(ValidationData validationData);
    }
}