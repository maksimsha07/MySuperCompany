using MediatR;
using MySuperCompany.API.Application.Commands.Employee;
using MySuperCompany.DAL.UnitOfWork.Interface;
using MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;
using System.Globalization;

namespace MySuperCompany.API.Application.Handlers.Employee.Commands;

/// <summary>
/// Обработчик команды обновления сотрудника
/// </summary>
public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Обработчик
    /// </summary>
    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(request.Id) ?? throw new ArgumentException("Not found");

        entity.Department.NameOfDepartment = request.Department;
        entity.BirthDate.Value = request.BirthDate;
        entity.FullName.FirstName = request.FirstName;
        entity.FullName.Surname = request.Surname;
        entity.FullName.Patronymic = request.Patronymic;
        entity.DateOfEmployment.Value = request.DateOfEmployment;
        entity.Salary.SalaryValue = request.Salary;

        await _repository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
