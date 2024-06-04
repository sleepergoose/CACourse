using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackIt.Infrastructure.EF.Models;

namespace PackIt.Infrastructure.EF.Config;

internal class ReadConfiguration
    : IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingListItemReadModel>
{
    public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
    {
        builder.ToTable("PackingLists");
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Localization)
            .HasConversion(
                toDatabaseValue => toDatabaseValue.ToString(),
                fromDatabaseValue => LocalizationReadModel.Create(fromDatabaseValue)
             );

        builder
            .HasMany(list => list.Items)
            .WithOne(item => item.PackingList);
    }

    public void Configure(EntityTypeBuilder<PackingListItemReadModel> builder)
    {
        builder.ToTable("PackingItems");
    }
}
