using MediatR;

namespace MySuperCompany.API.Application.Queries.Employee;

/// <summary>
/// Запрос на получение записи
/// </summary>
public class GetEmployeeQuery : IRequest<Domain.AggregatesModel.EmployeeAggregate.Employee>
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public int Id { get; set; }
}
