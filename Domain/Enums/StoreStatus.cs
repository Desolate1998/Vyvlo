using Common.EnumCode;

namespace Domain.Enums;

public enum StoreStatus
{
    [EnumCode("PendingActivation")]
    PendingActivation,
    [EnumCode("Active")]
    Active,
    [EnumCode("Inactive")]
    Inactive,
    [EnumCode("Deleted")]
    Deleted
}
