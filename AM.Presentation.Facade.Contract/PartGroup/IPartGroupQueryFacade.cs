using AM.Application.Contracts.PartGroup;
using AM.Infrastructure.Query.Contract.PartGroup;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.PartGroup;

public interface IPartGroupQueryFacade : IFacadeService
{
        
    List<PartGroupViewModel> List();
        
    EditPartGroup GetDetails(Guid guid);
    List<PartGroupComboModel> Combo(Guid? salonGuid);
}