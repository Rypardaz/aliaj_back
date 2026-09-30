using AM.Application.Contracts.Material;
using AM.Infrastructure.Query.Contract.Material;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Material;

public interface IMaterialQueryFacade : IFacadeService
{
    List<MaterialViewModel> List();

    EditMaterial GetDetails(Guid guid);
    List<MaterialComboModel> Combo(Guid? salonGuid);
}