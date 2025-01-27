using FluentValidation;
using Proxima.Models;

namespace Proxima.Validators
{
    public class TaskTypeValidator : AbstractValidator<TaskTypeModel>
    {
        public TaskTypeValidator()
        {

            RuleFor(t => t.TaskTypeID)
                .GreaterThanOrEqualTo(0).WithMessage("TaskTypeID must be a positive integer.");

            RuleFor(t => t.TypeName)
                .NotEmpty().WithMessage("TypeName is required.")
                .Length(2, 50).WithMessage("TypeName must be between 2 and 50 characters.");
        }
    }
}
