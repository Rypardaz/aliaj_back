using AM.Domain.TaskMasterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class TaskMasterMapping : IEntityTypeConfiguration<TaskMaster>
{

    public void Configure(EntityTypeBuilder<TaskMaster> builder)
    {
        builder.ToTable("tbTaskMaster");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);

        builder.OwnsMany(x => x.Contacts, contact =>
        {
            contact.ToTable("tbTaskMasterContact");
            contact.HasKey(x => x.Id);
            contact.Property(x => x.Id).ValueGeneratedOnAdd();
            contact.WithOwner().HasForeignKey(nameof(TaskMasterContact.TaskMasterId));

            contact.Property(x => x.Guid);
            contact.Property<long>(nameof(TaskMasterContact.TaskMasterId));
            contact.Property<string>(nameof(TaskMasterContact.Name)).IsRequired();
            contact.Property<string>(nameof(TaskMasterContact.Post)).IsRequired();
            contact.Property<string>(nameof(TaskMasterContact.Phone)).IsRequired();
            contact.Property<string?>(nameof(TaskMasterContact.CellPhone)).IsRequired(false);
        });

        builder.Navigation(x => x.Contacts)
            .HasField("_contacts")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
