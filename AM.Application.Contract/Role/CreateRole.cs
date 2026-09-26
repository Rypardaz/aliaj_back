namespace Ex.Application.Contracts.Role;

public class CreateRole
{
    public string Title { get; set; }
    public List<int> Permissions { get; set; }
}