using Ex.Application.Contracts.DailyRecord;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Dapper;

namespace Lab.Presentation.Facade.Command
{
    public class DailyRecordCommandFacade : IDailyRecordCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;
        private readonly BaseDapperRepository _dapper;

        public DailyRecordCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus,
            BaseDapperRepository dapper)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
            _dapper = dapper;
        }

        public Guid Create(CreateDailyRecord command)
        {
            var guid = _responsiveCommandBus.Dispatch<CreateDailyRecord, Guid>(command);

            _dapper.ExecuteSp("AutoCreateWireScrew", new { DailyRecordGuid = guid });

            return guid;
        }

        public void Edit(EditDailyRecord command)
        {
            _commandBus.Dispatch(command);
            _dapper.ExecuteSp("AutoCreateWireScrew", new { DailyRecordGuid = command.Guid });
        }

        public void Remove(Guid guid) => _commandBus.Dispatch(new RemoveDailyRecord { Guid = guid });
    }
}