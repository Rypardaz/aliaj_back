using PhoenixFramework.Core;

namespace AM.Domain.TenderInquiryAgg.Service;

public interface ITenderInquiryService : IDomainService
{
    void ThrowWhenDuplicatedProjectCode(string projectCode, long? id = null);
    void ThrowWhenDuplicatedNo(string No, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}