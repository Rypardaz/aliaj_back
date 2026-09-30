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
    public int? OfficeProvinceId { get; set; }
    public int? OfficeCityId { get; set; }
    public string? OfficeZipCode { get; set; }
    public string? OfficeAddress { get; set; }
    public string? OfficePhone { get; set; }
    public int? FactoryProvinceId { get; set; }
    public int? FactoryCityId { get; set; }
    public string? FactoryZipCode { get; set; }
    public string? FactoryAddress { get; set; }
    public string? FactoryPhone { get; set; }
    public List<TaskMasterContactOps> Contacts { get; set; }
}