using AM.Domain.TenderInquiryAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class TenderInquiryRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, TenderInquiry>(aliajCommandContext), ITenderInquiryRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}