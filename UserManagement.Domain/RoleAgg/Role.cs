using System;
using System.Collections.Generic;
using System.Data;
using PhoenixFramework.Domain;
using UserManagement.Domain.RoleAgg.Services;
using UserManagement.Domain.UserAgg;

namespace UserManagement.Domain.RoleAgg;

public class Role : AuditableAggregateRootBase<int>
{
    public int SystemId { get; private set; }
    public string Title { get; private set; }
    public List<RolePermission> Permissions { get; private set; }

    protected Role()
    {
    }

    public Role(Guid creator, string title, List<RolePermission> permissions, IRoleValidatorService validatorService) : base(creator)
    {
        GuardAgainstDuplicatedName(title, validatorService);

        Title = title;
        Permissions = permissions;
    }

    public void Edit(string title, List<RolePermission> permissions, IRoleValidatorService validatorService)
    {
        GuardAgainstDuplicatedName(title, Id, validatorService);

        Title = title;
        Permissions = permissions;
    }

    private static void GuardAgainstDuplicatedName(string name, IRoleValidatorService validatorService)
    {
        if (validatorService.IsNameDuplicated(name))
            throw new DuplicateNameException();
    }

    private static void GuardAgainstDuplicatedName(string name, int id,
        IRoleValidatorService validatorService)
    {
        if (validatorService.IsNameDuplicated(name, id))
            throw new DuplicateNameException();
    }
}