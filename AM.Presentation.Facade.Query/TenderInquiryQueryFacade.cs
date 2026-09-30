using AM.Application.Contracts.TenderInquiry;
using AM.Infrastructure.Query.Contract.TenderInquiry;
using AM.Presentation.Facade.Contract.TenderInquiry;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class TenderInquiryQueryFacade(IQueryBus queryBus) : ITenderInquiryQueryFacade
{
    public EditTenderInquiry GetDetails(Guid guid) => queryBus.Dispatch<EditTenderInquiry, Guid>(guid);

    public List<TenderInquiryViewModel> List() => queryBus.Dispatch<List<TenderInquiryViewModel>>();

    public List<TenderInquiryComboModel> Combo(Guid? salonGuid) =>
        queryBus.Dispatch<List<TenderInquiryComboModel>, Guid?>(salonGuid);
}