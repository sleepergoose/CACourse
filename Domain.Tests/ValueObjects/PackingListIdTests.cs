using PackIt.Domain.Exceptions.PackingList;
using PackIt.Domain.ValueObjects.PackingList;
using Xunit;

namespace Domain.Tests.ValueObjects;

public class PackingListIdTests
{
    [Fact]
    public void Shoud_Create_An_Object()
    {
        var guid = Guid.NewGuid();
        var packingListId = new PackingListId(guid);

        Assert.NotNull(packingListId);
    }

    [Fact]
    public void Shoud_Have_A_Correct_Value()
    {
        var guid = Guid.NewGuid();
        var packingListId = new PackingListId(guid);

        Assert.Equal(guid, packingListId.Value);
    }

    [Fact]
    public void Should_Throw_EmptyPackingListException_If_Guid_Is_Empty()
    {
        Assert.Throws<EmptyPackingListException>(() => new PackingListId(Guid.Empty));
    }

    [Fact]
    public void Shoud_Implicitly_Convert_To_Guid()
    {
        var guid = Guid.NewGuid();
        var packingListId = new PackingListId(guid);
        Guid actual = packingListId;

        Assert.Equal(guid, actual);
    }

    [Fact]
    public void Shoud_Implicitly_Convert_To_PackingListId()
    {
        var guid = Guid.NewGuid();
        PackingListId packingListId = guid;

        Assert.Equal(guid, packingListId.Value);
    }
}
