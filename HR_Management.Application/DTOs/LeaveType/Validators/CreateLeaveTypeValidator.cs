using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeValidator : AbstractValidator<CreateLeaveTypeDTO>
    {
        public CreateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDTOValidator());

        }
    }
}
