namespace MySuperCompany.API.Dto;

/// <summary>
/// Дто модель для операции получения записи
/// </summary>
public record GetDto
{
    /// <summary>
    /// Идентификатор записи.
    /// </summary>
    public int Id { get; set; }
}
