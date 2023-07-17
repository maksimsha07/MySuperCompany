using MySuperCompany.DAL.Context;
using MySuperCompany.DAL.UnitOfWork.Interface;


namespace MySuperCompany.DAL.UnitOfWork.Imp;

/// <summary>
/// Реализация шаблона Unit Of Work
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private bool _disposed;

    /// <summary>
    /// Контекст
    /// </summary>
    public MySuperCompanyContext Context { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public UnitOfWork(MySuperCompanyContext context)
        => Context = context ?? throw new ArgumentNullException(nameof(context));

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }


    /// <inheritdoc />
    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }

        _disposed = true;
    }
}
