using AM.Application.Contracts.Personnel;
using AM.Infrastructure.Query.Contract.Personnel;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class PersonnelQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<PersonnelViewModel>>,
    IQueryHandler<EditPersonnel, Guid>,
    IQueryHandler<List<PersonnelComboModel>, PersonnelSearchModel>
{
    List<PersonnelViewModel> IQueryHandler<List<PersonnelViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<PersonnelViewModel>(QueryConstants.GetPersonnelFor, new
        {
            Type = QueryTypes.List
        });

    public EditPersonnel Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditPersonnel>(QueryConstants.GetPersonnelFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

    public List<PersonnelComboModel> Handle(PersonnelSearchModel searchModel)
    {
        return dapperRepository.SelectFromSp<PersonnelComboModel>(QueryConstants.GetPersonnelFor, new
        {
            Type = QueryTypes.Combo,
            searchModel.SalonGuid,
            searchModel.OnlyActive
        });
    }
}