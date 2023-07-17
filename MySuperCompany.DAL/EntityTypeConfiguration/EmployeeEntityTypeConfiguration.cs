using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

namespace MySuperCompany.DAL.EntityTypeConfiguration;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseHiLo("employee_seq");

        builder.OwnsOne(e => e.Department, d =>
        {
            d.Property(x => x.NameOfDepartment)
                .HasColumnName("departmentname")
                .HasColumnType("varchar(256)")
                .IsRequired();
        });

        builder.OwnsOne(e => e.FullName, fn =>
        {
            fn.Property(x => x.Surname)
                .HasColumnName("surname")
                .HasColumnType("varchar(200)")
                .IsRequired();

            fn.Property(x => x.FirstName)
                .HasColumnName("firstname")
                .HasColumnType("varchar(200)")
                .IsRequired();

            fn.Property(x => x.Patronymic)
                .HasColumnName("patronymic")
                .HasColumnType("varchar(200)")
                .IsRequired(false);
        });

        builder.OwnsOne(e => e.BirthDate, bd =>
        {
            bd.Property(x => x.Value)
                .HasColumnName("birthday")
                .ValueGeneratedNever()
                .HasColumnType("date")
                .IsRequired();
        });

        builder.OwnsOne(e => e.DateOfEmployment, doe =>
        {
            doe.Property(x => x.Value)
                .HasColumnName("dateofemployment")
                .ValueGeneratedNever()
                .HasColumnType("date")
                .IsRequired();
        });

        builder.OwnsOne(e => e.Salary, s =>
        {
            s.Property(x => x.SalaryValue)
                .HasColumnName("salary")
                .HasColumnType("numeric(12, 2)")
                .IsRequired();
        });
    }
}
