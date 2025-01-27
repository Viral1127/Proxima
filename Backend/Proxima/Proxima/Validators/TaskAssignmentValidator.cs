using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class TaskAssignmentValidator:AbstractValidator<TaskAssignmentModel>
    {
        public TaskAssignmentValidator()
        {
            RuleFor(t => t.AssignmentID)
            .GreaterThanOrEqualTo(0).WithMessage("Assignment ID must be a positive integer.");

            RuleFor(t => t.TaskID)
                .GreaterThan(0).WithMessage("Task ID must be a positive integer.");

            RuleFor(t => t.TaskTitle)
                .Length(2, 100).WithMessage("Task Title must be between 2 and 100 characters.");

            RuleFor(t => t.UserID)
                .GreaterThan(0).WithMessage("User ID must be a positive integer.");

            RuleFor(t => t.UserName)
                .Length(2, 100).WithMessage("User Name must be between 2 and 100 characters.");

            RuleFor(t => t.RoleID)
                .GreaterThan(0).WithMessage("Role ID must be a positive integer.");

            RuleFor(t => t.RoleName)
                .Length(2, 50).WithMessage("Role Name must be between 2 and 50 characters.");

            RuleFor(t => t.AssignedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("AssignedAt cannot be a future date.");
        }
    }
}
