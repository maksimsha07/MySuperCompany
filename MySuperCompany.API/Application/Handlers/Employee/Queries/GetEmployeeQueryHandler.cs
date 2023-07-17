using MediatR;
using MySuperCompany.API.Application.Queries.Employee;
using MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

namespace MySuperCompany.API.Application.Handlers.Employee.Queries;

/// <summary>
/// Обработчик полчения сотрудника по идентификатору
/// </summary>
public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Domain.AggregatesModel.EmployeeAggregate.Employee>
{
    private readonly IEmployeeRepository _repository;

    public GetEmployeeQueryHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Обработчик
    /// </summary>
    public async Task<Domain.AggregatesModel.EmployeeAggregate.Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(request.Id);

        return entity ?? throw new Exception("Сотрудник не найден");
    }
}
