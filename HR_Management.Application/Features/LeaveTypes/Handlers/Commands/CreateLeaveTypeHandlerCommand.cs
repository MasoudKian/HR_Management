﻿using AutoMapper;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exeptions;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Contract.Persistence;
using HR_Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeHandlerCommand
        : IRequestHandler<CreateLeaveTypeRequestCommand, int>
    {
        #region Constructor
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeHandlerCommand(ILeaveTypeRepository leaveTypeRepository
            , IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task<int> Handle(CreateLeaveTypeRequestCommand request
            , CancellationToken cancellationToken)
        {
            #region Create Validator

            var validator = new CreateLeaveTypeValidator();
            //var validator = new CreateLeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDTO);

            if (validationResult.IsValid == false)
                throw new ValidationExeption(validationResult);

            #endregion



            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDTO);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            return leaveType.Id;
        }
    }
}
