using MySuperCompany.Domain.CustomBaseMembers;

namespace MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

/// <summary>
/// Отдел сотрудника
/// </summary>
public class Department : ValueObject
{
    /// <summary>
    /// Наименование отдела
    /// </summary>
    public string NameOfDepartment { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="nameOfDepartment">Наименование отдела</param>
    public Department(string nameOfDepartment)
    {
        if (string.IsNullOrEmpty(nameOfDepartment))
        {
            throw new ArgumentNullException("Наименование отдела не может быть пустым");
        }

        NameOfDepartment = nameOfDepartment;
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Конструктор для EF Core
    /// </summary>
    public Department() { }
}
