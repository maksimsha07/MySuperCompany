using MediatR;

namespace MySuperCompany.API.Application.Queries.Employee;

/// <summary>
/// Запрос на получение всех сотрудников
/// </summary>
public class ListQuery : IRequest<IEnumerable<Domain.AggregatesModel.EmployeeAggregate.Employee>>
{
}
