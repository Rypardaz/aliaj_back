using PhoenixFramework.Domain;

namespace Ex.Domain.UserAgg;

public record UserCompany : ValueObjectBase
{
    public int CompanyId { get; private set; }

    protected UserCompany()
    {
    }

    public UserCompany(int companyId)
    {
        CompanyId = companyId;
    }
}