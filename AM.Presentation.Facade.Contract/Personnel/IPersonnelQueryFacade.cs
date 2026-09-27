using AM.Application.Contracts.Personnel;
using AM.Infrastructure.Query.Contract.Personnel;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Personnel;

public interface IPersonnelQueryFacade : IFacadeService
{
        
    List<PersonnelViewModel> List();
        
    EditPersonnel GetDetails(Guid guid);
    List<PersonnelComboModel> Combo(PersonnelSearchModel salonGuid);
}