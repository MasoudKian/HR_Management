using AutoMapper;
using HR_Management.Application.DTOs;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Domain;

namespace HR_Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest,LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest,LeaveRequestListDTO>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
        }
    }
}
