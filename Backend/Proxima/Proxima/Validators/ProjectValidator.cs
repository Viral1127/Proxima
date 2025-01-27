using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class ProjectValidator : AbstractValidator<ProjectModel>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.ProjectID)
                .GreaterThanOrEqualTo(0).WithMessage("Project ID must be a positive integer.");

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(5, 100).WithMessage("Title must be between 5 and 100 characters.");

            RuleFor(p => p.Description)
                .Length(5, 500).When(p => !string.IsNullOrEmpty(p.Description))
                .WithMessage("Description must be between 5 and 500 characters.");

            RuleFor(p => p.ClientID)
                .GreaterThan(0).WithMessage("Client ID must be a positive integer.");

            RuleFor(p => p.StartDate)
                .LessThanOrEqualTo(p => p.EndDate).WithMessage("Start Date must be before or equal to End Date.");

            RuleFor(p => p.EndDate)
                .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("End Date must be after or equal to Start Date.");

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => new[] { "Ongoing", "Completed", "Upcoming", "Archived" }.Contains(status))
                .WithMessage("Status must be one of the following: 'Ongoing', 'Completed','Upcoming' or 'Archived'.");

            RuleFor(p => p.CreatedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("CreatedAt cannot be in the future.");

            RuleFor(p => p.UpdatedAt)
                .GreaterThanOrEqualTo(p => p.CreatedAt).When(p => p.UpdatedAt.HasValue)
                .WithMessage("UpdatedAt cannot be earlier than CreatedAt.");
        }
    }
}
