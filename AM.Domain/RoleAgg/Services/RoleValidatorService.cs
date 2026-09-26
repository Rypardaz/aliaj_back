namespace Ex.Domain.RoleAgg.Services;

public class RoleValidatorService(IRoleRepository roleRepository) : IRoleValidatorService
{
    public bool IsNameDuplicated(string name)
    {
        return roleRepository.Exists(x => x.Title == name);
    }

    public bool IsNameDuplicated(string name, int id)
    {
        return roleRepository.Exists(x => x.Title == name && x.Id != id);
    }
}