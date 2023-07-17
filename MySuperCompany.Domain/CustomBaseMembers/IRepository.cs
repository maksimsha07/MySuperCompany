namespace MySuperCompany.Domain.CustomBaseMembers;

/// <summary>
/// Репозиторий для работы с сущностями агрегатами
/// </summary>
/// <typeparam name="T">Сущность агрегат, которая наследует <see cref="IAggregateRoot"/></typeparam>
public interface IRepository<T> where T : IAggregateRoot
{
    /// <summary>
    /// Получить все записи
    /// </summary>
    /// <returns>Список всех записей в <see cref="IQueryable"/></returns>
    IQueryable<T> GetAll();

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <returns>Найденная запись</returns>
    Task<T?> Get(int id);

    /// <summary>
    /// Создать запись
    /// </summary>
    /// <param name="entity">Сущность которую необходимо создать</param>
    /// <param name="cancellation">Для отмены операции</param>
    /// <returns>Созданная сущность</returns>
    Task<T> CreateAsync(T entity);

    /// <summary>
    /// Обновить запись
    /// </summary>
    /// <param name="entity">Сущность которую необходимо обновить</param>
    /// <param name="cancellation">Для отмены операции</param>
    /// <returns>Обновленная сущность</returns>
    Task<T> UpdateAsync(T entity);

    /// <summary>
    /// Удалить запись
    /// </summary>
    /// <param name="entity">Сущность которую необходимо удалить</param>
    void Delete(T entity);
}
