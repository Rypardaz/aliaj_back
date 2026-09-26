using Ex.Application.Contracts.DailyRecord;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.DailyRecord;

public interface IDailyRecordCommandFacade : IFacadeService
{
    Guid Create(CreateDailyRecord command);
    void Edit(EditDailyRecord command);
    void Remove(Guid guid);
}