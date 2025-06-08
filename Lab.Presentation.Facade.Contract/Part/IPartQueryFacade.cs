using Ex.Application.Contracts.Part;
using Lab.Infrastructure.Query.Contracts.Part;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Part
{
    public interface IPartQueryFacade : IFacadeService
    {
        
        List<PartViewModel> List();
        
        EditPart GetDetails(Guid guid);
        List<PartComboModel> Combo(Guid? salonGuid);
    }
}
