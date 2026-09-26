namespace Ex.Application.Contracts.Role;

public interface IRoleApplication
{
    void Create(CreateRole command);
    void Edit(EditRole command);
    List<RoleViewModel> List();
    EditRole GetDetails(Guid guid);
    // List<RoleComboModel> GetForCombo();
    void Delete(Guid guid);
}