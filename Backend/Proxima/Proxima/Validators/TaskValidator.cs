using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class TaskValidator : AbstractValidator<TaskModel>
    {
        public TaskValidator()
        {
            RuleFor(t => t.TaskID)
           .GreaterThanOrEqualTo(0).WithMessage("Task ID must be a positive integer.");

            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(5, 100).WithMessage("Title must be between 5 and 100 characters.");

            RuleFor(t => t.Description)
                .Length(5, 500).When(t => !string.IsNullOrEmpty(t.Description))
                .WithMessage("Description must be between 5 and 500 characters.");

            RuleFor(t => t.TaskTypeID)
                .GreaterThan(0).WithMessage("Task Type ID must be a positive integer.");

            RuleFor(t => t.TypeName)
                .Length(2, 50).WithMessage("Task Type Name must be between 2 and 50 characters.");

            RuleFor(t => t.DueDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Due Date must be today or in the future.");

            RuleFor(t => t.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => new[] { "In Progress", "Under Review", "Completed" }.Contains(status))
                .WithMessage("Status must be one of the following: 'In Progress', Under Review', or 'Completed'.");

            RuleFor(t => t.AssignedTo)
                .GreaterThan(0).WithMessage("AssignedTo (User ID) must be a positive integer.");

            RuleFor(t => t.Name)
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(t => t.ProjectID)
                .GreaterThan(0).WithMessage("Project ID must be a positive integer.");

            RuleFor(t => t.ProjectName)
                .Length(2, 100).WithMessage("Project Name must be between 2 and 100 characters.");

            RuleFor(t => t.CreatedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("CreatedAt cannot be in the future.");

            RuleFor(t => t.UpdatedAt)
                .GreaterThanOrEqualTo(t => t.CreatedAt).When(t => t.UpdatedAt.HasValue)
                .WithMessage("UpdatedAt cannot be earlier than CreatedAt.");
        }
    }
}
