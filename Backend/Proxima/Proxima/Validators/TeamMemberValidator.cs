using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class TeamMemberValidator : AbstractValidator<TeamMemberModel>
    {
        public TeamMemberValidator()
        {
            RuleFor(tm => tm.TeamMemberID)
            .GreaterThanOrEqualTo(0).WithMessage("Team Member ID must be a positive integer.");

            RuleFor(tm => tm.UserID)
                .GreaterThan(0).WithMessage("User ID must be a positive integer.");

            RuleFor(tm => tm.UserName)
                .Length(2, 50).WithMessage("User Name must be between 2 and 50 characters.");

            //RuleFor(tm => tm.Email)
            //    .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(tm => tm.TeamID)
                .GreaterThan(0).WithMessage("Team ID must be a positive integer.");

            RuleFor(tm => tm.AssignedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("AssignedAt cannot be in the future.");
        }
    }
}
