using PhoenixFramework.Domain;

namespace AM.Domain.UserAgg;

public record UserClaim : ValueObjectBase
{
    public string Name { get; private set; }
    public string Value { get; private set; }

    protected UserClaim()
    {
    }

    public UserClaim(string name, string value)
    {
        Name = name;
        Value = value;
    }
}