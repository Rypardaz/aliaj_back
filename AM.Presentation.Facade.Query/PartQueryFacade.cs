using Ex.Application.Contracts.Part;
using Lab.Infrastructure.Query.Contracts.Part;
using Lab.Presentation.Facade.Contract.Part;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class PartQueryFacade(IQueryBus queryBus) : IPartQueryFacade
{
    public EditPart GetDetails(Guid guid) => queryBus.Dispatch<EditPart, Guid>(guid);

    public List<PartViewModel> List() => queryBus.Dispatch<List<PartViewModel>>();

    public List<PartComboModel> Combo(Guid? salonGuid) => queryBus.Dispatch<List<PartComboModel>, Guid?>(salonGuid);
}