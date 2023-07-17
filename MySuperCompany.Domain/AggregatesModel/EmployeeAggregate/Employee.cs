using MySuperCompany.Domain.CustomBaseMembers;

namespace MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

/// <summary>
/// Класс описывающий сотредников
/// </summary>
public class Employee : Entity, IAggregateRoot
{

    public Department Department { get; }

    public FullName FullName { get; }

    public BirthDate BirthDate { get; set; }

    public DateOfEmployment DateOfEmployment { get; set; }

    public Salary Salary { get; set; }

    public Employee(Department department,
        FullName fullName,
        BirthDate birthDate,
        DateOfEmployment dateOfEmployment,
        Salary salary)
    {
        Department = department;
        FullName = fullName;
        BirthDate = birthDate;
        DateOfEmployment = dateOfEmployment;
        Salary = salary;
    }

    /// <summary>
    /// Конструктор для EF Core
    /// </summary>
    private Employee() { }
}
