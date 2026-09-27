using AM.Application.Contracts.PartGroup;
using AM.Infrastructure.Query.Contract.PartGroup;
using AM.Presentation.Facade.Contract.PartGroup;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class PartGroupQueryFacade(IQueryBus queryBus) : IPartGroupQueryFacade
{
    public EditPartGroup GetDetails(Guid guid) => queryBus.Dispatch<EditPartGroup, Guid>(guid);

    public List<PartGroupViewModel> List() => queryBus.Dispatch<List<PartGroupViewModel>>();

    public List<PartGroupComboModel> Combo(Guid? salonGuid) => queryBus.Dispatch<List<PartGroupComboModel>, Guid?>(salonGuid);
}