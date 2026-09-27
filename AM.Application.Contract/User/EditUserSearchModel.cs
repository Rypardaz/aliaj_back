namespace AM.Application.Contracts.User;

public class EditUserSearchModel(Guid id)
{
    public Guid Guid { get; set; } = id;
}