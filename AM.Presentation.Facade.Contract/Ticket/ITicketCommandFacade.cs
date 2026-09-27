using AM.Application.Contracts.Ticket;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Ticket;

public interface ITicketCommandFacade : IFacadeService
{
    Guid Create(CreateTicket command);
    void AddResponse(AddResponse command);
    void Delete(Guid guid);
}
