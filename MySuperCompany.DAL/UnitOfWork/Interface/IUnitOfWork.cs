using MySuperCompany.DAL.Context;

namespace MySuperCompany.DAL.UnitOfWork.Interface;

/// <summary>
/// Шаблон Unit of Work
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Контекст
    /// </summary>
    MySuperCompanyContext Context { get; }

    /// <summary>
    /// Асинхронно сохранить все изменения
    /// </summary>
    /// <returns><see cref="Task{TResult}"/> количество сохраненных объектов</returns>
    Task<int> SaveChangesAsync();
}

