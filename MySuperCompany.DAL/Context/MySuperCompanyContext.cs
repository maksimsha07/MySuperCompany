using Microsoft.EntityFrameworkCore;
using MySuperCompany.DAL.EntityTypeConfiguration;
using MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

namespace MySuperCompany.DAL.Context;

/// <summary>
/// Контекст данных
/// </summary>
public class MySuperCompanyContext : DbContext
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    public MySuperCompanyContext(DbContextOptions<MySuperCompanyContext> options)
    : base(options)
    {
        Database.EnsureCreated();
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
    }
}
