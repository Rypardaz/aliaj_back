namespace AM.Infrastructure.Query.Contract.Personnel;

public class PersonnelSearchModel
{
    public Guid? SalonGuid { get; set; }
    public bool OnlyActive { get; set; }
}