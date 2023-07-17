﻿namespace MySuperCompany.API.Dto;

/// <summary>
/// Дто модель для сотрудника
/// </summary>
public record EmployeeDto
{
    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Отдел
    /// </summary>
    public string Department { get; set; }

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
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Дата устройства на работу
    /// </summary>
    public DateTime DateOfEmployment { get; set; }

    /// <summary>
    /// Зарплата
    /// </summary>
    public string Salary { get; set; }
}
