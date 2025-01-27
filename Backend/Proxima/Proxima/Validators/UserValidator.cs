using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"[A-Za-z]").WithMessage("Password must contain at least one letter.")
            .Matches(@"\d").WithMessage("Password must contain at least one number.");

            RuleFor(u => u.RoleID)
                .GreaterThanOrEqualTo(0).When(u => u.RoleID.HasValue).WithMessage("Role ID annot be negative");

            RuleFor(u => u.RoleName)
            .Length(2, 30).When(u => !string.IsNullOrEmpty(u.RoleName))
            .WithMessage("Role Name must be between 2 and 30 characters.");

        RuleFor(u => u.Status)
            .NotNull().WithMessage("Status is required.");

        RuleFor(u => u.CreatedAt)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("CreatedAt cannot be in the future.");

        RuleFor(u => u.UpdatedAt)
            .GreaterThanOrEqualTo(u => u.CreatedAt).When(u => u.UpdatedAt.HasValue)
            .WithMessage("UpdatedAt cannot be earlier than CreatedAt.");
    }
    }
}
