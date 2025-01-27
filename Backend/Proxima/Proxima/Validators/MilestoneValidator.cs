using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class MilestoneValidator:AbstractValidator<MilestonesModel>
    {
        public MilestoneValidator()
        {
            RuleFor(m => m.MilestoneID)
            .GreaterThanOrEqualTo(0).WithMessage("Milestone ID must be a positive integer.");

            RuleFor(m => m.ProjectID)
                .GreaterThan(0).WithMessage("Project ID must be a positive integer.");

            RuleFor(m => m.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(5, 100).WithMessage("Title must be between 5 and 100 characters.");

            RuleFor(m => m.DueDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Due Date must be today or in the future.");

            RuleFor(m => m.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => new[] { "Pending", "Achieved" }.Contains(status))
                .WithMessage("Status must be one of the following: 'Pending' or 'Achieved'.");

            RuleFor(m => m.Description)
                .Length(5, 500).When(m => !string.IsNullOrEmpty(m.Description))
                .WithMessage("Description must be between 5 and 500 characters.");
        }

    }
}
