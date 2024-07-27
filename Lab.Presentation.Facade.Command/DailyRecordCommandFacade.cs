using Ex.Application.Contracts.DailyRecord;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class DailyRecordCommandFacade : IDailyRecordCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public DailyRecordCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateDailyRecord command) => _responsiveCommandBus.Dispatch<CreateDailyRecord, Guid>(command);

        public void Edit(EditDailyRecord command) => _commandBus.Dispatch(command);

        public void Remove(Guid guid) => _commandBus.Dispatch(new RemoveDailyRecord { Guid = guid});
    }
}
