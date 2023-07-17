using MySuperCompany.Domain.CustomBaseMembers;

namespace MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

/// <summary>
/// Полное имя сотрудника
/// </summary>
public class FullName : ValueObject
{
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
    /// Конструктор
    /// </summary>
    /// <param name="surname">Фамилия</param>
    /// <param name="firstName">Имя</param>
    /// <param name="patronymic">Отчество</param>
    public FullName(string surname, string firstName, string patronymic)
    {
        if (string.IsNullOrEmpty(surname))
        {
            throw new ArgumentNullException("Фамилия не может быть пуста");
        }

        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentNullException("Имя не может быть пусто");
        }

        if (string.IsNullOrEmpty(patronymic))
        {
            throw new ArgumentNullException("Отчество не может быть пусто");
        }

        Surname = surname;
        FirstName = firstName;
        Patronymic = patronymic;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="surname">Фамилия</param>
    /// <param name="firstName">Имя</param>
    public FullName(string surname, string firstName)
    {
        if (string.IsNullOrEmpty(surname))
        {
            throw new ArgumentNullException("Фамилия не может быть пуста");
        }

        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentNullException("Имя не может быть пусто");
        }

        Surname = surname;
        FirstName = firstName;
    }


    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return Surname;
    }

    /// <summary>
    /// Конструктор для EF Core
    /// </summary>
    public FullName() { }
}
