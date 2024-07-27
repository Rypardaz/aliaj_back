namespace UserManagement.Domain.RoleAgg.Services;

public class RoleValidatorService : IRoleValidatorService
{
    private readonly IRoleRepository _roleRepository;

    public RoleValidatorService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public bool IsNameDuplicated(string name)
    {
        return _roleRepository.Exists(x => x.Title == name);
    }

    public bool IsNameDuplicated(string name, int id)
    {
        return _roleRepository.Exists(x => x.Title == name && x.Id != id);
    }
}