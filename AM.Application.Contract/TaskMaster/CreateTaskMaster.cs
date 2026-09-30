using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.TaskMaster;

public class CreateTaskMaster : ICommand
{
    [Required] public required string Name { get; set; }

    public int? IndustryTypeId { get; set; }
    public string? RegistNo { get; set; }
    public string? NationalCode { get; set; }
    public string? EconomicCode { get; set; }
    public Guid? OfficeProvinceGuid { get; set; }
    public Guid? OfficeCityGuid { get; set; }
    public string? OfficeZipCode { get; set; }
    public string? OfficeAddress { get; set; }
    public string? OfficePhone { get; set; }
    public Guid? FactoryProvinceGuid { get; set; }
    public Guid? FactoryCityGuid { get; set; }
    public string? FactoryZipCode { get; set; }
    public string? FactoryAddress { get; set; }
    public string? FactoryPhone { get; set; }
    public List<TaskMasterContactOps> Contacts { get; set; }
}