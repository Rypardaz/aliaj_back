using AM.Domain.RegionAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class RegionRepository(AliajCommandContext commandContext)
    : BaseRepository<int, Region>(commandContext), IRegionRepository;