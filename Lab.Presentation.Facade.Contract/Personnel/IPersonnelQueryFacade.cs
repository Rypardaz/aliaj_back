using Ex.Application.Contracts.Personnel;
using Lab.Infrastructure.Query.Contracts.Personnel;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Personnel
{
    public interface IPersonnelQueryFacade : IFacadeService
    {
        
        List<PersonnelViewModel> List();
        
        EditPersonnel GetDetails(Guid guid);
        List<PersonnelComboModel> Combo(Guid? salonGuid);
    }
}
