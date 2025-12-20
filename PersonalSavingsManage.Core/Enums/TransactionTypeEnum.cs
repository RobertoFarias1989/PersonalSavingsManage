using System.Text.Json.Serialization;

namespace PersonalSavingsManage.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionTypeEnum
{
    Deposit,
    Withdraw
}
