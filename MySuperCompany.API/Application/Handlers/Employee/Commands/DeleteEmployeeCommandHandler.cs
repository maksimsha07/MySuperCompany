using MediatR;
using MySuperCompany.API.Application.Commands.Employee;
using MySuperCompany.DAL.UnitOfWork.Interface;
using MySuperCompany.Domain.AggregatesModel.EmployeeAggregate;

namespace MySuperCompany.API.Application.Handlers.Employee.Commands;

/// <summary>
/// Обработчик команды удаления сотрудника
/// </summary>
public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Обработчик
    /// </summary>
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employe = await _repository.Get(request.Id) ?? throw new Exception("Не удалось найти запись");
        _repository.Delete(employe);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
