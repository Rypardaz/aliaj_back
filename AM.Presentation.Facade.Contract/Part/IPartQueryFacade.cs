using AM.Application.Contracts.Part;
using AM.Infrastructure.Query.Contract.Part;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Part;

public interface IPartQueryFacade : IFacadeService
{
        
    List<PartViewModel> List();
        
    EditPart GetDetails(Guid guid);
    List<PartComboModel> Combo(Guid? salonGuid);
}