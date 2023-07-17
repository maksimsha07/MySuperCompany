using MySuperCompany.Domain.CustomBaseMembers;

namespace MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

/// <summary>
/// Дата устройства на работу
/// </summary>
public class DateOfEmployment : ValueObject
{
    /// <summary>
    /// Значение даты устройства на работе
    /// </summary>
    public DateTime Value { get; set; }

    public DateOfEmployment(DateTime value)
        => Value = value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    /// <summary>
    /// Конструктор для EF Core
    /// </summary>
    public DateOfEmployment() { }
}
