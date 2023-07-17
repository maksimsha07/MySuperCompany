using AutoMapper;
using MySuperCompany.API.Application.Commands.Employee;
using MySuperCompany.API.Application.Queries.Employee;
using MySuperCompany.API.Dto;
using System;

namespace MySuperCompany.API;

/// <summary>
/// Профайл для автомаппера
///</summary>
public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<CreateEmployeeDto, CreateEmployeeCommand>().ReverseMap();
        CreateMap<UpdateEmployeeDto, UpdateEmployeeCommand>().ReverseMap();
        CreateMap<DeleteEmployeeDto, DeleteEmployeeCommand>().ReverseMap();
        CreateMap<GetEmployeeQuery, EmployeeDto>().ReverseMap();

    }
}
