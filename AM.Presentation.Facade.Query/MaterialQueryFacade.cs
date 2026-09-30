using AM.Application.Contracts.Material;
using AM.Infrastructure.Query.Contract.Material;
using AM.Presentation.Facade.Contract.Material;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class MaterialQueryFacade(IQueryBus queryBus) : IMaterialQueryFacade
{
    public EditMaterial GetDetails(Guid guid) => queryBus.Dispatch<EditMaterial, Guid>(guid);

    public List<MaterialViewModel> List() => queryBus.Dispatch<List<MaterialViewModel>>();

    public List<MaterialComboModel> Combo(Guid? salonGuid) =>
        queryBus.Dispatch<List<MaterialComboModel>, Guid?>(salonGuid);
}