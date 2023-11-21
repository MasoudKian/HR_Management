using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDTOValidator : AbstractValidator<CreateLeaveTypeDTO>
    {
        public CreateLeaveTypeDTOValidator()
        {
            RuleFor(l=>l.Name).NotEmpty().WithMessage("{PropertyName} Is Required.")
                .NotNull().MaximumLength(50).WithMessage("{PropertyName} Must Not Exceed 50");

            RuleFor(l => l.DefaultDay)
                .NotEmpty().WithMessage("{PropertyName} Is Required.")
                .GreaterThan(0).LessThan(100);
        }
    }
}
