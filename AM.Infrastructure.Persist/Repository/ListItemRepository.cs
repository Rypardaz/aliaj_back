using Ex.Domain.ListItemAgg;
using Microsoft.EntityFrameworkCore;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class ListItemRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<int, ListItem>(aliajCommandContext), IListItemRepository;