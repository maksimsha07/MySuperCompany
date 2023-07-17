using MySuperCompany.Domain.CustomBaseMembers;

namespace MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;


/// <summary>
/// Интерфейс для репозитория сотрудников
/// </summary>
public interface IEmployeeRepository : IRepository<Employee>
{
}
