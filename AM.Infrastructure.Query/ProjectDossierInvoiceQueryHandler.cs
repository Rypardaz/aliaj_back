using AM.Application.Contracts.ProjectDossier;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.ProjectDossierInvoice;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class ProjectDossierInvoiceQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<ProjectDossierInvoiceViewModel>>,
    IQueryHandler<EditProjectDossierInvoice, Guid>
{
    List<ProjectDossierInvoiceViewModel> IQueryHandler<List<ProjectDossierInvoiceViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<ProjectDossierInvoiceViewModel>(QueryConstants.GetProjectDossierInvoiceFor, new
        {
            Type = QueryTypes.List
        });

    public EditProjectDossierInvoice Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditProjectDossierInvoice>(QueryConstants.GetProjectDossierInvoiceFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}