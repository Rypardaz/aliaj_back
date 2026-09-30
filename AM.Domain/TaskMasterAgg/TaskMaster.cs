using PhoenixFramework.Domain;
using System.Collections.ObjectModel;
using AM.Domain.TaskMasterAgg.Service;

namespace AM.Domain.TaskMasterAgg;

public class TaskMaster : AuditableAggregateRootBase<long>
{
    private IList<TaskMasterContact> _contacts = new List<TaskMasterContact>();
    public string Name { get; private set; }
    public int? IndustryTypeId { get; private set; }
    public string? RegistNo { get; private set; }
    public string? NationalCode { get; private set; }
    public string? EconomicCode { get; private set; }
    public int? OfficeProvinceId { get; private set; }
    public int? OfficeCityId { get; private set; }
    public string? OfficeZipCode { get; private set; }
    public string? OfficeAddress { get; private set; }
    public string? OfficePhone { get; private set; }
    public int? FactoryProvinceId { get; private set; }
    public int? FactoryCityId { get; private set; }
    public string? FactoryZipCode { get; private set; }
    public string? FactoryAddress { get; private set; }
    public string? FactoryPhone { get; private set; }

    public IReadOnlyCollection<TaskMasterContact> Contacts =>
        new ReadOnlyCollection<TaskMasterContact>(_contacts);

    protected TaskMaster()
    {
    }

    public TaskMaster(Guid creator, string name, int? industryTypeId, string? registNo, string? nationalCode,
        string? economicCode, int? officeProvinceId, int? officeCityId, string? officeZipCode, string? officeAddress,
        string? officePhone, int? factoryProvinceId, int? factoryCityId, string? factoryZipCode, string? factoryAddress,
        string? factoryPhone, List<TaskMasterContact> contacts, ITaskMasterService service) : base(creator)
    {
        service.ThrowWhenDuplicatedName(name);

        Name = name;
        IndustryTypeId = industryTypeId;
        RegistNo = registNo;
        NationalCode = nationalCode;
        EconomicCode = economicCode;
        OfficeProvinceId = officeProvinceId;
        OfficeCityId = officeCityId;
        OfficeZipCode = officeZipCode;
        OfficeAddress = officeAddress;
        OfficePhone = officePhone;
        FactoryProvinceId = factoryProvinceId;
        FactoryCityId = factoryCityId;
        FactoryZipCode = factoryZipCode;
        FactoryAddress = factoryAddress;
        FactoryPhone = factoryPhone;
        _contacts = contacts;
    }

    public void Edit(Guid actor, string name, int? industryTypeId, string? registNo, string? nationalCode,
        string? economicCode, int? officeProvinceId, int? officeCityId, string? officeZipCode, string? officeAddress,
        string? officePhone, int? factoryProvinceId, int? factoryCityId, string? factoryZipCode, string? factoryAddress,
        string? factoryPhone, List<TaskMasterContact> contacts, ITaskMasterService service)
    {
        service.ThrowWhenDuplicatedName(name, Id);

        Name = name;
        IndustryTypeId = industryTypeId;
        RegistNo = registNo;
        NationalCode = nationalCode;
        EconomicCode = economicCode;
        OfficeProvinceId = officeProvinceId;
        OfficeCityId = officeCityId;
        OfficeZipCode = officeZipCode;
        OfficeAddress = officeAddress;
        OfficePhone = officePhone;
        FactoryProvinceId = factoryProvinceId;
        FactoryCityId = factoryCityId;
        FactoryZipCode = factoryZipCode;
        FactoryAddress = factoryAddress;
        FactoryPhone = factoryPhone;
        _contacts = contacts;

        Modified(actor);
    }
}