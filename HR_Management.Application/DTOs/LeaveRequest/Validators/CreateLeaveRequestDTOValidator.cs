using FluentValidation;
using HR_Management.Application.Persistence.Contract;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDTOValidator : AbstractValidator<CreateLeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate)
                .WithMessage("{PropertyName } must be befor {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate)
                .WithMessage("{PropertyName } must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExist = await _leaveTypeRepository.Exist(id);
                    return !leaveTypeExist;
                })
                .WithMessage("{PropertyName } dose not exist");
        }
    }
}
