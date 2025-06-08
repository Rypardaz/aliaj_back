using Ex.Application.Contracts.Machine;
using Lab.Infrastructure.Query.Contracts.Machine;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query;

public class MachineQueryHandler :
    IQueryHandler<List<MachineViewModel>>,
    IQueryHandler<EditMachine, Guid>,
    IQueryHandler<List<MachineComboModel>, Guid?>
{
    private readonly BaseDapperRepository _dapperRepository;

    public MachineQueryHandler(BaseDapperRepository dapperRepository)
    {
        _dapperRepository = dapperRepository;
    }

    List<MachineViewModel> IQueryHandler<List<MachineViewModel>>.Handle() =>
        _dapperRepository.SelectFromSp<MachineViewModel>(QueryConstants.GetMachineFor, new
        {
            Type = QueryTypes.List
        });

    List<MachineComboModel> IQueryHandler<List<MachineComboModel>, Guid?>.Handle(Guid? salonGuid)
    {
        return _dapperRepository.SelectFromSp<MachineComboModel>(QueryConstants.GetMachineFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }

    public EditMachine Handle(Guid guid) =>
        _dapperRepository.SelectFromSpFirstOrDefault<EditMachine>(QueryConstants.GetMachineFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });
}