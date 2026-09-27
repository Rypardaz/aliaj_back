using AM.Application.Contracts.Part;
using AM.Infrastructure.Query.Contract.Part;
using AM.Presentation.Facade.Contract.Part;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class PartQueryFacade(IQueryBus queryBus) : IPartQueryFacade
{
    public EditPart GetDetails(Guid guid) => queryBus.Dispatch<EditPart, Guid>(guid);

    public List<PartViewModel> List() => queryBus.Dispatch<List<PartViewModel>>();

    public List<PartComboModel> Combo(Guid? salonGuid) => queryBus.Dispatch<List<PartComboModel>, Guid?>(salonGuid);
}