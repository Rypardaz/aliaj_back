using AM.Application.Contracts.Unit;
using AM.Infrastructure.Query.Contract.Unit;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Unit;

public interface IUnitQueryFacade : IFacadeService
{
    List<UnitViewModel> List();

    EditUnit GetDetails(Guid guid);
    List<UnitComboModel> Combo(Guid? salonGuid);
}