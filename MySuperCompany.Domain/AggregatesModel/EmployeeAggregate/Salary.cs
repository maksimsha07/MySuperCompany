using MySuperCompany.Domain.CustomBaseMembers;

namespace MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

/// <summary>
/// Зарплата
/// </summary>
public class Salary : ValueObject
{
    /// <summary>
    /// Значение зарплаты
    /// </summary>
    public decimal SalaryValue { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="salaryValue">Зарплата</param>
    public Salary(decimal salaryValue)
    {
        if (salaryValue <= 0m)
        {
            throw new ArgumentException("Зарплата не может быть отрицательной или равной нулю");
        }

        SalaryValue = salaryValue;
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SalaryValue;
    }

    /// <summary>
    /// Конструктор для EF Core
    /// </summary>
    private Salary() { }
}
