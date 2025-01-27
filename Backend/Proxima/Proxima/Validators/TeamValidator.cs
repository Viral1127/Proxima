using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class TeamValidator:AbstractValidator<TeamsModel>
    {
        public TeamValidator()
        {
            RuleFor(t => t.TeamID)
           .GreaterThanOrEqualTo(0).WithMessage("Team ID must be a positive integer.");

            RuleFor(t => t.TeamName)
                .NotEmpty().WithMessage("Team Name is required.")
                .Length(2, 100).WithMessage("Team Name must be between 2 and 100 characters.");

            RuleFor(t => t.Description)
                .NotEmpty()
                .Length(5, 250).When(t => !string.IsNullOrEmpty(t.Description))
                .WithMessage("Description must be between 5 and 250 characters.");

            RuleFor(t => t.CreatedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("CreatedAt cannot be in the future.");

            RuleFor(t => t.UpdatedAt)
                .GreaterThanOrEqualTo(t => t.CreatedAt).When(t => t.UpdatedAt.HasValue)
                .WithMessage("UpdatedAt cannot be earlier than CreatedAt.");

            RuleFor(t => t.UserID)
                .GreaterThanOrEqualTo(0).WithMessage("User ID must be a positive integer.");
        }
    }
}
