using AM.Domain.ListItemAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

internal class ListItemMapping : IEntityTypeConfiguration<ListItem>
{
    public void Configure(EntityTypeBuilder<ListItem> builder)
    {
        builder.ToTable("tbListItem");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.Created);
        builder.Ignore(x => x.CreatedBy);
        builder.Ignore(x => x.IsActive);
    }
}