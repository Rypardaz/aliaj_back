using Ex.Application.Contracts.PowderTypeGroup;
using Lab.Infrastructure.Query.Contracts.PowderTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.PowderTypeGroup
{
    public interface IPowderTypeGroupQueryFacade : IFacadeService
    {
        List<PowderTypeGroupViewModel> List();
        EditPowderTypeGroup GetDetails(Guid guid);
        List<PowderTypeGroupComboModel> Combo();
    }
}
