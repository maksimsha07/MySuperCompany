using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySuperCompany.API.Application.Commands.Employee;
using MySuperCompany.API.Application.Queries.Employee;
using MySuperCompany.API.Dto;
using System.Globalization;

namespace MySuperCompany.API.Controllers;

/// <summary>
/// Контроллер для взаимодействия с сотрудниками
/// </summary>
[ApiController]
[Route("[controller]/{action}")]
public class EmployeeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Создать запись.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Create(CreateEmployeeDto dto)
    {
        var result = await _mediator.Send(
            _mapper.Map<CreateEmployeeCommand>(dto));

        return CreatedAtAction("Get", new GetDto { Id = result });
    }

    /// <summary>
    /// Редактировать запись.
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateEmployeeDto dto)
    {
        if (dto.Id == default)
        {
            return BadRequest("Не удалось получить идентификатор");
        }

        await _mediator.Send(_mapper.Map<UpdateEmployeeCommand>(dto));

        return Ok();
    }

    /// <summary>
    /// Удалить запись.
    /// </summary>
    /// <param name="dto">DTO</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteEmployeeDto dto)
    {
        await _mediator.Send(new DeleteEmployeeCommand { Id = dto.Id });
        return Ok();
    }

    /// <summary>
    /// Получить список всех записей.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/list")]
    public async Task<ActionResult<IEnumerable<ListDto>>> List()
    {
        var baseQuery = await _mediator.Send(new ListQuery());

        var query = baseQuery.Select(x => new ListDto
        {
            Id = x.Id,
            Department = x.Department.NameOfDepartment,
            Surname = x.FullName.Surname,
            FirstName = x.FullName.FirstName,
            Patronymic = x.FullName.Patronymic ?? string.Empty,
            BirthDate = x.BirthDate.Value,
            DateOfEmployment = x.DateOfEmployment.Value,
            Salary = x.Salary.SalaryValue
        });

        return Ok(query);
    }

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    /// <param name="dto">DTO с идентификатором</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<EmployeeDto>> Get([FromQuery] GetDto dto)
    {
        if (dto.Id == default)
        {
            return BadRequest("Не удалось получить идентификатор");
        }

        var entity = await _mediator.Send(new GetEmployeeQuery { Id = dto.Id });
        return new EmployeeDto 
        {
            Id = entity.Id,
            Department = entity.Department.NameOfDepartment,
            Surname = entity.FullName.Surname,
            FirstName = entity.FullName.FirstName,
            Patronymic = entity.FullName.Patronymic ?? string.Empty,
            BirthDate = entity.BirthDate.Value,
            DateOfEmployment = entity.DateOfEmployment.Value,
            Salary = entity.Salary.SalaryValue.ToString(CultureInfo.CurrentCulture)
        };
    }
}
