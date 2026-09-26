using Ex.Application.Contracts.DailyRecord;
using Lab.Presentation.Facade.Contract.DailyRecord;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Dapper;

namespace Lab.Presentation.Facade.Command;

public class DailyRecordCommandFacade(
    ICommandBus commandBus,
    IResponsiveCommandBus responsiveCommandBus,
    BaseDapperRepository dapper)
    : IDailyRecordCommandFacade
{
    public Guid Create(CreateDailyRecord command)
    {
        var guid = responsiveCommandBus.Dispatch<CreateDailyRecord, Guid>(command);

        dapper.ExecuteSp("AutoCreateWireScrew", new { DailyRecordGuid = guid });

        return guid;
    }

    public void Edit(EditDailyRecord command)
    {
        commandBus.Dispatch(command);
        dapper.ExecuteSp("AutoCreateWireScrew", new { DailyRecordGuid = command.Guid });
    }

    public void Remove(Guid guid) => commandBus.Dispatch(new RemoveDailyRecord { Guid = guid });
}