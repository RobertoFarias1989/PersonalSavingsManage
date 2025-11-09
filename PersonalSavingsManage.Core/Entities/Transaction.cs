using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PersonalSavingsManage.Core.Enums;
using System.Text.Json.Serialization;

namespace PersonalSavingsManage.Core.Entities;

public class Transaction : BaseEntity
{
    public Transaction(decimal amount, TransactionTypeEnum type) : base()
    {
        Amount = amount;
        Type = type;

        TransactionDate = DateTime.Now;
        
    }

    public decimal Amount { get; private set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [BsonRepresentation(BsonType.String)]
    public TransactionTypeEnum Type { get; private set; }
    public DateTime TransactionDate { get; private set; }

    public void Update(decimal amount, TransactionTypeEnum type)
    {
        Amount = amount;
        Type = type;

        UpdatedAt = DateTime.Now;
    }
}
