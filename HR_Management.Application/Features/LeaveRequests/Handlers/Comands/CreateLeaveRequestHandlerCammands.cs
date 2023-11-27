using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Features.LeaveRequests.Requests.Comands;
using HR_Management.Application.Contract.Persistence;
using HR_Management.Application.Responses;
using HR_Management.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Contract.Infrastructure;
using HR_Management.Application.Models;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Comands
{
    public class CreateLeaveRequestHandlerCammands
        : IRequestHandler<CreateLeaveRequestRequestsCammands, BaseCommandResponse>
    {

        #region Constructor
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestHandlerCammands(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper, ILeaveTypeRepository leaveTypeRepository
            , IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }

        #endregion

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestRequestsCammands request, CancellationToken cancellationToken)
        {
            #region Create Validator

            var response = new BaseCommandResponse();

            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);
            //var validator = new CreateLeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationExeption(validationResult);
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            #endregion

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDTO);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Create Succsess";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "masoudkiannezhad@gmail.com",
                Subject = "leaveRequestSubmit",
                Body = $"درخواست مرخصی شما {request.CreateLeaveRequestDTO.StartDate}"
                + $"تا {request.CreateLeaveRequestDTO.EndDate}" +
                $"با موفقیت تایید شد"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (System.Exception)
            {

                //Log
            }

            return response;
        }
    }
}
