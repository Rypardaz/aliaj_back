using AM.Application.Contracts.Personnel;
using AM.Infrastructure.Query.Contract.Personnel;
using AM.Presentation.Facade.Contract.Personnel;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class PersonnelQueryFacade(IQueryBus queryBus) : IPersonnelQueryFacade
{
    public EditPersonnel GetDetails(Guid guid) => queryBus.Dispatch<EditPersonnel, Guid>(guid);

    public List<PersonnelViewModel> List() => queryBus.Dispatch<List<PersonnelViewModel>>();

    public List<PersonnelComboModel> Combo(PersonnelSearchModel searchModel) =>
        queryBus.Dispatch<List<PersonnelComboModel>, PersonnelSearchModel?>(searchModel);
}