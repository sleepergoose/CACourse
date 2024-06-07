using PackIt.Domain.Entities;
using PackIt.Domain.Events;
using PackIt.Domain.Exceptions.PackingList;
using PackIt.Domain.Factories;
using PackIt.Domain.Policies;
using PackIt.Domain.ValueObjects.PackingList;
using Shouldly;

namespace Domain.Tests.Entities;

public class PackingListTests
{
    [Fact]
    public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
    {
        var packingList = GetPackingList();

        var exception = Record.Exception(() => packingList.AddItem(new PackingListItem("Item 1", 1)));

        exception.ShouldBeNull();

        packingList.Events.Count().ShouldBe(1);

        var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;

        @event.ShouldNotBeNull();
        @event.PackingListItem.Name.ShouldBe("Item 1");
        ((int)@event.PackingListItem.Quantity).ShouldBe(1);
    }

    [Fact]
    public void AddItem_Throws_PackingListAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
    {
        var packingList = GetPackingList();
        packingList.AddItem(new PackingListItem("Item 1", 1));

        var exception = Record.Exception(() => packingList.AddItem(new PackingListItem("Item 1", 1)));
        
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingListAlreadyExistsException>();

        Assert.Throws<PackingListAlreadyExistsException>(() => packingList.AddItem(new PackingListItem("Item 1", 1)));
    }

    #region ARRANGE

    private PackingList GetPackingList()
    {
        var packingList = _factory.Create(Guid.NewGuid(), "MyList", Localization.Create("Warsaw, Poland"));
        packingList.CrearEvents();
        return packingList;
    }

    private readonly IPackingListFactory _factory;

    public PackingListTests()
    {
        _factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
    }

    #endregion
}
