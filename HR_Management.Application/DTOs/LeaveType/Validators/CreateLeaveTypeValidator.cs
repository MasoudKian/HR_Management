using FluentValidation;
using HR_Management.Application.DTOs.LeaveAllocation;

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
