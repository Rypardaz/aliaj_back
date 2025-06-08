using PhoenixFramework.Core;
using UserManagement.Application.Contracts.Company;

namespace Um.Presentation.Facade.Contract.Company;

public interface ICompanyCommandFacade : IFacadeService
{
    long Create(CreateCompany command);
    void Edit(EditCompany command);
    void Delete(Guid guid);
    void Deactivate(Guid guid);
    void Activate(Guid guid);
}