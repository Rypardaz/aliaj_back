using Ex.Application.Contracts.Personnel;
using Lab.Infrastructure.Query.Contracts.Personnel;
using Lab.Presentation.Facade.Contract.Personnel;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class PersonnelQueryFacade(IQueryBus queryBus) : IPersonnelQueryFacade
{
    public EditPersonnel GetDetails(Guid guid) => queryBus.Dispatch<EditPersonnel, Guid>(guid);

    public List<PersonnelViewModel> List() => queryBus.Dispatch<List<PersonnelViewModel>>();

    public List<PersonnelComboModel> Combo(PersonnelSearchModel searchModel) =>
        queryBus.Dispatch<List<PersonnelComboModel>, PersonnelSearchModel?>(searchModel);
}