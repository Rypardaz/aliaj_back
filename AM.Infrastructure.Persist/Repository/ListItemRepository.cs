using AM.Domain.ListItemAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ListItemRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<int, ListItem>(aliajCommandContext), IListItemRepository;