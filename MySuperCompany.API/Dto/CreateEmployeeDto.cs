﻿namespace MySuperCompany.API.Dto;

/// <summary>
/// Дто модель для создания сотрудника
/// </summary>
public record CreateEmployeeDto
{
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
    public decimal Salary { get; set; }
}
