using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.Personnel;

public class PersonnelViewModel : ViewModelAbilities
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string? NationalCode { get; set; }
    public string SalonName { get; set; }
    public string IsActiveStr { get; set; }
}