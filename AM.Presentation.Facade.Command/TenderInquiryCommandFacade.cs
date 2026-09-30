using AM.Application.Contracts.TenderInquiry;
using AM.Presentation.Facade.Contract.TenderInquiry;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class TenderInquiryCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : ITenderInquiryCommandFacade
{
    public Guid Create(CreateTenderInquiry command)
    {
        return responsiveCommandBus.Dispatch<CreateTenderInquiry, Guid>(command);
    }

    public void Edit(EditTenderInquiry command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateTenderInquiry(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateTenderInquiry(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveTenderInquiry(guid);
        commandBus.Dispatch(com);
    }
}