using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDTOValidator : AbstractValidator<ILeaveTypeDTO>
    {
        public ILeaveTypeDTOValidator()
        {
            RuleFor(l=>l.Name).NotEmpty().WithMessage("{PropertyName} Is Required.")
                .NotNull().MaximumLength(50).WithMessage("{PropertyName} Must Not Exceed 50");

            RuleFor(l => l.DefaultDay)
                .NotEmpty().WithMessage("{PropertyName} Is Required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100");
        }
    }
}
