using MediatR;
using MySuperCompany.API.Application.Queries.Employee;
using MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

namespace MySuperCompany.API.Application.Handlers.Employee.Queries;

/// <summary>
/// Обработчик получения всех сотрудников
/// </summary>
public class ListQueryHandler : IRequestHandler<ListQuery, IEnumerable<Domain.AggregatesModel.EmployeeAggregate.Employee>>
{
    private readonly IEmployeeRepository _repository;

    public ListQueryHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }


    /// <summary>
    /// Обработчик
    /// </summary>
    public async Task<IEnumerable<Domain.AggregatesModel.EmployeeAggregate.Employee>> Handle(ListQuery request, CancellationToken cancellationToken)
        => _repository.GetAll().ToList();
}
