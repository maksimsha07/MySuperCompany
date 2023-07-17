using MediatR;

namespace MySuperCompany.API.Application.Commands.Employee;

/// <summary>
/// Команда удаления сотрудника
/// </summary>
public class DeleteEmployeeCommand : IRequest<Unit>
{
    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public int Id { get; set; }
}
