using System.Collections.Generic;
using System;
using UserManagement.Application.Contracts.Commands.Role;
using UserManagement.Query.Contracts.UserManagement.Role;

namespace UserManagement.Application.Contracts.Contracts;

public interface IRoleApplication
{
    void Create(CreateRole command);
    void Edit(EditRole command);
    List<RoleViewModel> List();
    EditRole GetDetails(Guid guid);
    List<RoleComboModel> GetForCombo();
    void Delete(Guid guid);
}