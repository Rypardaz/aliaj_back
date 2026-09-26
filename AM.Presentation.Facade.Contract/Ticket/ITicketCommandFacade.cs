using Ex.Application.Contracts.Ticket;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.Ticket;

public interface ITicketCommandFacade : IFacadeService
{
    Guid Create(CreateTicket command);
    void AddResponse(AddResponse command);
    void Delete(Guid guid);
}
