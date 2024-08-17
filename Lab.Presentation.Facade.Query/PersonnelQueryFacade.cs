using Ex.Application.Contracts.Personnel;
using Lab.Infrastructure.Query.Contracts.Personnel;
using Lab.Presentation.Facade.Contract.Personnel;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class PersonnelQueryFacade : IPersonnelQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public PersonnelQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditPersonnel GetDetails(Guid guid) => _queryBus.Dispatch<EditPersonnel, Guid>(guid);

        public List<PersonnelViewModel> List() => _queryBus.Dispatch<List<PersonnelViewModel>>();

        public List<PersonnelComboModel> Combo(Guid? salonGuid) => _queryBus.Dispatch<List<PersonnelComboModel>, Guid?>(salonGuid);
    }
}
