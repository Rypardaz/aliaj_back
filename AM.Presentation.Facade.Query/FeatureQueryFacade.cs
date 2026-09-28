using PhoenixFramework.Application.Query;
using AM.Presentation.Facade.Contract.Feature;
using AM.Infrastructure.Query.Contract.Feature;

namespace AM.Presentation.Facade.Query;

public class FeatureQueryFacade(IQueryBusAsync queryBusAsync) : IFeatureQueryFacade
{
    public async Task<string> GetUserPermissions() => await queryBusAsync.Dispatch<string>();
}