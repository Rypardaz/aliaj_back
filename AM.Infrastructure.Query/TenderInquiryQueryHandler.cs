using AM.Application.Contracts.TenderInquiry;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.Shared;
using AM.Infrastructure.Query.Contract.TenderInquiry;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class TenderInquiryQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<TenderInquiryViewModel>>,
    IQueryHandler<EditTenderInquiry, Guid>,
    IQueryHandler<List<TenderInquiryComboModel>, Guid?>
{
    List<TenderInquiryViewModel> IQueryHandler<List<TenderInquiryViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<TenderInquiryViewModel>(QueryConstants.GetTenderInquiryFor, new
        {
            Type = QueryTypes.List
        });

    public List<TenderInquiryComboModel> Handle(Guid? salonGuid)
    {
        return dapperRepository.SelectFromSp<TenderInquiryComboModel>(QueryConstants.GetTenderInquiryFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }
    public EditTenderInquiry Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditTenderInquiry>(QueryConstants.GetTenderInquiryFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });
}