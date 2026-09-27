using AM.Application.Contracts.WorkCalendar;
using AM.Presentation.Facade.Contract.WorkCalendar;
using PhoenixFramework.Dapper;

namespace AM.Presentation.Facade.Command;

public class WorkCalendarCommandFacade(BaseDapperRepository repository) : IWorkCalendarCommandFacade
{
    public void Edit(EditWorkCalendar command)
    {
        var query = "";
        foreach (var item in command.Items)
        {
            var description = string.IsNullOrWhiteSpace(item.Description) ? "NULL" : $"'{item.Description}'";
            var closedTypeId = item.ClosedTypeId is null ? "NULL" : $"'{item.ClosedTypeId}'";
            var isClosed = item.IsClosed ? 1 : 0;

            query += $"""
                        UPDATE tbWorkCalendar SET
                            WorkTime = {item.WorkTime},
                            IsClosed = {isClosed},
                            ClosedTypeId = {closedTypeId},
                            Description = {description},
                            StartTime = '{item.StartTime}',
                            EndTime = '{item.EndTime}'
                         WHERE Id = {item.Id}
                      """;
        }

        repository.Execute(query);
    }
}