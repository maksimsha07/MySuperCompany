using MediatR;
using MySuperCompany.API.Application.Commands.Employee;
using MySuperCompany.DAL.UnitOfWork.Interface;
using MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

namespace MySuperCompany.API.Application.Handlers.Employee.Commands;

/// <summary>
/// Обработчик команды создания сотрудника
/// </summary>
public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Обработчик
    /// </summary>
    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {

        var newEmployee = new Domain.AggregatesModel.EmployeeAggregate.Employee(
            new Department(request.Department),
            !string.IsNullOrEmpty(request.Patronymic) ? new FullName(request.FirstName, request.Surname, request.Patronymic) : new FullName(request.FirstName, request.Surname),
            new BirthDate(request.BirthDate),
            new DateOfEmployment(request.DateOfEmployment),
            new Salary(request.Salary)
        );

        var createResult = await _repository.CreateAsync(newEmployee);
        await _unitOfWork.SaveChangesAsync();

        return createResult.Id;
    }
}
