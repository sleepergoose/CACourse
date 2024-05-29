using PackIt.Domain.Exceptions.PackingList;
using PackIt.Domain.ValueObjects.PackingList;
using Xunit;

namespace Domain.Tests.ValueObjects;
public class PackingListItemTests
{
    [Theory]
    [InlineData("Shirt", 2, true)]
    [InlineData("T-shirt", 3, true)]
    public void Should_Create_An_Object(string name, uint quantity, bool isPacked)
    {
        var item = new PackingListItem(name, quantity, isPacked);
        Assert.NotNull(item);
    }

    [Theory]
    [InlineData("Shirt", 2)]
    [InlineData("T-shirt", 3)]
    public void Should_Create_An_Object_With_Default_Parameter(string name, uint quantity)
    {
        var item = new PackingListItem(name, quantity);
        Assert.NotNull(item);
        Assert.False(item.IsPacked);
    }

    [Theory]
    [InlineData("Shirt", 1, true)]
    [InlineData("T-shirt", 50, false)]
    public void Should_Create_An_Object_With_Limit_Quantity(string name, uint quantity, bool isPacked)
    {
        var item = new PackingListItem(name, quantity, isPacked);
        Assert.NotNull(item);
    }

    [Theory]
    [InlineData("", 2, true)]
    [InlineData(null, 3, true)]
    public void Ahould_Throw_EmptyPackingListItemNameException_Exception(string name, uint quantity, bool isPacked)
    {
        Assert.Throws<EmptyPackingListItemNameException>(() => new PackingListItem(name, quantity, isPacked));
    }

    [Theory]
    [InlineData("Shirt", 0, true)]
    [InlineData("T-shirt", 51, true)]
    public void Ahould_Throw_InvalidPackingListItemQuantityException_Exception(string name, uint quantity, bool isPacked)
    {
        Assert.Throws<InvalidPackingListItemQuantityException>(() => new PackingListItem(name, quantity, isPacked));
    }
}
