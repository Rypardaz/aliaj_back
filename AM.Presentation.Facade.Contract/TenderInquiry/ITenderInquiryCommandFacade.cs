using AM.Application.Contracts.TenderInquiry;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.TenderInquiry;

public interface ITenderInquiryCommandFacade : IFacadeService
{

    Guid Create(CreateTenderInquiry command);

    void Edit(EditTenderInquiry command);

    void Delete(Guid guid);

    void Activate(Guid guid);

    void Deactivate(Guid guid);
}
