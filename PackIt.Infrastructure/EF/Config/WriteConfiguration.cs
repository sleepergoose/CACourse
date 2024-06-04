using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackIt.Domain.Entities;
using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Infrastructure.EF.Config;

internal sealed class WriteConfiguration
    : IEntityTypeConfiguration<PackingList>, IEntityTypeConfiguration<PackingListItem>
{
    public void Configure(EntityTypeBuilder<PackingList> builder)
    {
        builder.HasKey(x => x.Id);

        var localizationConvertor = new ValueConverter<Localization, string>(
            valueToDatabase => valueToDatabase.ToString(),
            valueFromDatabase => Localization.Create(valueFromDatabase)
            );

        var packingListNameConvertor = new ValueConverter<PackingListName, string>(
            valueToDatabase => valueToDatabase.Value,
            valueFromDatabase => new PackingListName(valueFromDatabase)
            );

        builder
            .Property(p => p.Id)
            .HasConversion(id => id.Value, id => new PackingListId(id));

        builder
            .Property(typeof(Localization), "_localization")
            .HasConversion(localizationConvertor)
            .HasColumnName("Localization");

        builder
            .Property(typeof(PackingListName), "_name")
            .HasConversion(packingListNameConvertor)
            .HasColumnName("Name");

        builder.HasMany(typeof(PackingListItem), "_items");

        builder.ToTable("PackingLista");
    }

    public void Configure(EntityTypeBuilder<PackingListItem> builder)
    {
        
    }
}
