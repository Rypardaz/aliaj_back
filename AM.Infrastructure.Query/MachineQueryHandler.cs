using AM.Application.Contracts.Machine;
using AM.Infrastructure.Query.Contract.Machine;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class MachineQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<MachineViewModel>>,
    IQueryHandler<EditMachine, Guid>,
    IQueryHandler<List<MachineComboModel>, Guid?>
{
    List<MachineViewModel> IQueryHandler<List<MachineViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<MachineViewModel>(QueryConstants.GetMachineFor, new
        {
            Type = QueryTypes.List
        });

    List<MachineComboModel> IQueryHandler<List<MachineComboModel>, Guid?>.Handle(Guid? salonGuid)
    {
        return dapperRepository.SelectFromSp<MachineComboModel>(QueryConstants.GetMachineFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }

    public EditMachine Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditMachine>(QueryConstants.GetMachineFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });
}