using PhoenixFramework.Domain;

namespace AM.Domain.TaskMasterAgg;

public record TaskMasterContact : ValueObjectBase
{
    public long Id { get; private set; }
    public Guid Guid { get; private set; }
    public long TaskMasterId { private get; set; }
    public string Name { private get; set; }
    public string Post { private get; set; }
    public string Phone { private get; set; }
    public string? CellPhone { private get; set; }

    public TaskMasterContact(long taskMasterId, string name, string post, string phone, string? cellPhone)
    {
        Guid = Guid.NewGuid();
        TaskMasterId = taskMasterId;
        Name = name;
        Post = post;
        Phone = phone;
        CellPhone = cellPhone;
    }
}