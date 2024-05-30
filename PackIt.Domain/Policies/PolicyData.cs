using PackIt.Domain.Constants;
using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Policies;

public record class PolicyData(
    TravelDays Days,
    Constants.Gender Gender,
    ValueObjects.PackingList.Temperature Temperature,
    Localization Localization
    );
