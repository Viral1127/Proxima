using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class UserRolesValidator:AbstractValidator<RolesModel>
    {
        public UserRolesValidator()
        {
            RuleFor(r => r.RoleID)
                .GreaterThanOrEqualTo(0).WithMessage("Role ID cannnot be Negative.");

            RuleFor(r => r.RoleName)
                .NotEmpty().WithMessage("Role Name is required.")
                .Length(2, 50).WithMessage("Role Name must be between 2 and 50 characters.");

            RuleFor(r => r.Description)
                .Length(5, 200).When(r => !string.IsNullOrEmpty(r.Description))
                .WithMessage("Description must be between 5 and 200 characters.");

        }
    }
}
