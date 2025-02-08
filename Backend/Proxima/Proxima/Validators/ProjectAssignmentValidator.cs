using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class ProjectAssignmentValidator : AbstractValidator<ProjectAssignmentsModel>
    {
        public ProjectAssignmentValidator()
        {
            RuleFor(pa => pa.AssignmentID)
            .GreaterThanOrEqualTo(0).WithMessage("Assignment ID must be a positive integer.");

            RuleFor(pa => pa.ProjectID)
                .GreaterThan(0).WithMessage("Project ID must be a positive integer.");

            RuleFor(pa => pa.UserID)
                .GreaterThan(0).WithMessage("User ID must be a positive integer.");

            RuleFor(pa => pa.Name)
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            //RuleFor(pa => pa.RoleID)
            //    .GreaterThan(0).WithMessage("Role ID must be a positive integer.");

            RuleFor(pa => pa.RoleName)
                .Length(2, 50).WithMessage("Role Name must be between 2 and 50 characters.");

            RuleFor(pa => pa.AssignedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("AssignedAt cannot be in the future.");
        }
    }
}
