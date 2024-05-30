using PackIt.Domain.Entities;
using PackIt.Domain.ValueObjects.PackingList;
using Xunit;

namespace Domain.Tests.Entities;

public class PackingListTests
{
    [Fact]
    public void Should_Create_An_Object()
    {
        var packingList = new PackingList(Guid.NewGuid(), "PackingListName", Localization.Create("City, Country"));
        Assert.NotNull(packingList);
    }

    [Fact]
    public void Should_Add_An_item()
    {
        var packingList = new PackingList(Guid.NewGuid(), "PackingListName", Localization.Create("City, Country"));
        var item = new PackingListItem("Pants", 1);
        packingList.AddItem(item);
        
        Assert.True(packingList.Events.Any());
    }
}
