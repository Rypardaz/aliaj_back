using AM.Application.Contracts.TenderInquiry;
using AM.Infrastructure.Query.Contract.TenderInquiry;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.TenderInquiry;

public interface ITenderInquiryQueryFacade : IFacadeService
{
    List<TenderInquiryViewModel> List();

    EditTenderInquiry GetDetails(Guid guid);
    List<TenderInquiryComboModel> Combo(Guid? salonGuid);
}