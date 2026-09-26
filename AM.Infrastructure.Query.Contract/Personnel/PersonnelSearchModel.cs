namespace Lab.Infrastructure.Query.Contracts.Personnel;

public class PersonnelSearchModel
{
    public Guid? SalonGuid { get; set; }
    public bool OnlyActive { get; set; }
}