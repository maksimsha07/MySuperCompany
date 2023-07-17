using MySuperCompany.Domain.CustomBaseMembers;

namespace MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

/// <summary>
/// Дата рождения
/// </summary>
public class BirthDate : ValueObject
{
    /// <summary>
    /// Значение даты рождения
    /// </summary>
    public DateTime Value { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="value">Дата рождения</param>
    public BirthDate(DateTime value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    /// <summary>
    /// Конструктор для EF Core
    /// </summary>
    public BirthDate() { }
}
