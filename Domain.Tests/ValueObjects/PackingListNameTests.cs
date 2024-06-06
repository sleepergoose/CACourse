using PackIt.Domain.Exceptions.PackingList;
using PackIt.Domain.ValueObjects.PackingList;
using Xunit;

namespace Domain.Tests.ValueObjects;

public class PackingListNameTests
{
    [Fact]
    public void Should_Create_Object_And_Set_Name()
    {
        var name = "someCoolName";
        var valueObject = new PackingListName(name);

        Assert.NotNull(valueObject);
        Assert.True(valueObject.Value == name);
    }

    [Fact]
    public void Should_Throw_EmptyPackingListNameException_If_Name_Is_Null()
    {
        string? name = null;

        Assert.Throws<EmptyPackingListNameException>(() => new PackingListName(name!));
    }

    [Fact]
    public void Should_Throw_EmptyPackingListNameException_If_Name_Is_Empty()
    {
        string name = "";

        Assert.Throws<EmptyPackingListNameException>(() => new PackingListName(name!));
    }

    [Fact]
    public void Should_Implicitly_Convert_String_To_PackingListName()
    {
        var name = "expectedName";
        var valueObject = new PackingListName("tempName");
        valueObject = name;

        Assert.True(valueObject.Value == name);
        Assert.True(valueObject == name);
    }

    [Fact]
    public void Should_Implicitly_Convert_PackingListName_To_String()
    {
        var name = "expectedName";
        var valueObject = new PackingListName(name);
        string actualName = valueObject;

        Assert.True(actualName == name);
    }
}
