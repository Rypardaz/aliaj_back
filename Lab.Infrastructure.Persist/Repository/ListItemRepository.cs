using Ex.Domain.ListItemAgg;
using Microsoft.EntityFrameworkCore;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class ListItemRepository : BaseRepository<int, ListItem>, IListItemRepository
    {
        public ListItemRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
        }
    }
}
