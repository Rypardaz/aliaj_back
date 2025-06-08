using Ex.Application.Contracts.GasTypeGroup;
using Lab.Infrastructure.Query.Contracts.GasTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.GasTypeGroup
{
    public interface IGasTypeGroupQueryFacade : IFacadeService
    {
        List<GasTypeGroupViewModel> List();
        EditGasTypeGroup GetDetails(Guid guid);
        List<GasTypeGroupComboModel> Combo();
    }
}
