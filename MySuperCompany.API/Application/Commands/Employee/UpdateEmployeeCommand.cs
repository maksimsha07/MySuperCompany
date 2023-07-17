using MediatR;

namespace MySuperCompany.API.Application.Commands.Employee;

/// <summary>
/// Команда сохранения сотрудника
/// </summary>
public class UpdateEmployeeCommand : IRequest<Unit>
{
    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Отдел
    /// </summary>
    public string Department { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Дата устройства на работу
    /// </summary>
    public DateTime DateOfEmployment { get; set; }

    /// <summary>
    /// Зарплата
    /// </summary>
    public decimal Salary { get; set; }
}
