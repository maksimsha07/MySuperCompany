using Microsoft.EntityFrameworkCore;
using MySuperCompany.DAL.Context;
using MySuperCompany.DAL.UnitOfWork.Interface;
using MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

namespace MySuperCompany.DAL.Repositories;

/// <summary>
/// Репозиторий для сущности <see cref="Employee"/>
/// </summary>
public class EmployeeRepository : IEmployeeRepository
{
    private readonly MySuperCompanyContext _context;

    public EmployeeRepository(IUnitOfWork unitOfWork)
        => _context = unitOfWork.Context;

    /// <inheritdoc />
    public async Task<Employee> CreateAsync(Employee entity)
    {
        await _context.AddAsync(entity);

        return entity;
    }

    /// <inheritdoc />
    public void Delete(Employee entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.Remove(entity);
    }

    /// <inheritdoc />
    public async Task<Employee?> Get(int id) =>
        await _context.FindAsync<Employee>(id);

    /// <inheritdoc />
    public IQueryable<Employee> GetAll() =>
        _context.Employees.AsQueryable();

    /// <inheritdoc />
    public Task<Employee> UpdateAsync(Employee entity)
    {
        _context.Entry(entity).State = EntityState.Modified;

        return Task.FromResult(entity);
    }
}
