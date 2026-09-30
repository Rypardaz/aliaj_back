using AM.Infrastructure.Query.Contract.Region;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Region;

public interface IRegionQueryFacade : IFacadeService
{
    Task<IEnumerable<RegionViewModel>> GetList(RegionSearchModel searchModel);
}