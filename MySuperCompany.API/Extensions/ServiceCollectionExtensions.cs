using Microsoft.EntityFrameworkCore;
using MySuperCompany.API.Application.Handlers.Employee.Commands;
using MySuperCompany.DAL.Context;
using MySuperCompany.DAL.Repositories;
using MySuperCompany.DAL.UnitOfWork.Imp;
using MySuperCompany.DAL.UnitOfWork.Interface;
using MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

namespace MySuperCompany.API.Extensions;

/// <summary>
/// Регистрация некоторых зависимостей
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрация DAL
    /// </summary>
    public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MySuperCompanyContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(MySuperCompanyContext).Assembly.FullName);
            });
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }

    /// <summary>
    /// Регистрация Application.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(CreateEmployeeCommandHandler).Assembly);
        });

        return services;
    }
}
