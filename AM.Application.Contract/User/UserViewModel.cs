using PhoenixFramework.Company.Query;

namespace AM.Application.Contracts.User;

public class UserViewModel : ViewModelAbilities
{
    public string Token { get; set; }
    public DateTime TokenExpirationUtc { get; set; }
    public long UserGroupId { get; set; }
    public string UserGroupName { get; set; }
    public string Username { get; set; }
    public string Mobile { get; set; }
    public string Fullname { get; set; }
    public string CompanyTitle { get; set; }
    public string OrganizationChartTitle { get; set; }
    public string EmployeeCode { get; set; }
}
