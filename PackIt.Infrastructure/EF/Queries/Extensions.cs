using PackIt.Application.DTO;
using PackIt.Infrastructure.EF.Models;

namespace PackIt.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static PackingListDto AsDto(this PackingListReadModel readModel)
    {
        return new PackingListDto
        {
            Id = readModel.Id,
            Name = readModel.Name,
            Localization = new LocalizationDto
            (
                readModel.Localization?.City ?? "No City Data",
                readModel.Localization?.Country ?? "No Country Data"
            ),
            Items = readModel.Items?.Select(item => new PackingListItemDto
            (
                item.Name,
                item.Quantity,
                item.IsPacked
            ))!,
        };
    }
}
