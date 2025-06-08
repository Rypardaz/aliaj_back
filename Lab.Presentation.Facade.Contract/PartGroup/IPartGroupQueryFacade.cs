using Ex.Application.Contracts.PartGroup;
using Lab.Infrastructure.Query.Contracts.PartGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.PartGroup
{
    public interface IPartGroupQueryFacade : IFacadeService
    {
        
        List<PartGroupViewModel> List();
        
        EditPartGroup GetDetails(Guid guid);
        List<PartGroupComboModel> Combo(Guid? salonGuid);
    }
}
