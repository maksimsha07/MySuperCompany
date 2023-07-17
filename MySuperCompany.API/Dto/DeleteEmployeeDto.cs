namespace MySuperCompany.API.Dto;

/// <summary>
/// Дто модель для создания
/// </summary>
public record DeleteEmployeeDto
{
    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public int Id { get; set; }
}
