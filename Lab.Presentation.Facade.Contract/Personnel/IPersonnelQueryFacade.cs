using Ex.Application.Contracts.Personnel;
using Lab.Infrastructure.Query.Contracts.Personnel;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Personnel
{
    public interface IPersonnelQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<PersonnelViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditPersonnel GetDetails(Guid guid);
        List<PersonnelComboModel> Combo(Guid? salonGuid);
    }
}
