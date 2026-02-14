using Ex.Application.Contracts.Personnel;
using Lab.Infrastructure.Query.Contracts.Personnel;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class PersonnelQueryHandler :
        IQueryHandler<List<PersonnelViewModel>>,
        IQueryHandler<EditPersonnel, Guid>,
        IQueryHandler<List<PersonnelComboModel>, PersonnelSearchModel>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public PersonnelQueryHandler(BaseDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        List<PersonnelViewModel> IQueryHandler<List<PersonnelViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<PersonnelViewModel>(QueryConstants.GetPersonnelFor, new
            {
                Type = QueryTypes.List
            });

        public EditPersonnel Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditPersonnel>(QueryConstants.GetPersonnelFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

        public List<PersonnelComboModel> Handle(PersonnelSearchModel searchModel)
        {
            return _dapperRepository.SelectFromSp<PersonnelComboModel>(QueryConstants.GetPersonnelFor, new
            {
                Type = QueryTypes.Combo,
                searchModel.SalonGuid,
                searchModel.OnlyActive
            });
        }
    }
}