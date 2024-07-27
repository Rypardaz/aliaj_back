using PhoenixFramework.Core;

namespace Ex.Application.Contracts.DailyRecord
{
    public interface IDailyRecordCommandFacade : IFacadeService
    {
        Guid Create(CreateDailyRecord command);
        void Edit(EditDailyRecord command);
        void Remove(Guid guid);
    }
}
