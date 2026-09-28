using AM.Infrastructure.Query.Contract.Feature;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Feature;

public interface IFeatureQueryFacade : IFacadeService
{
    Task<string> GetUserPermissions();
}