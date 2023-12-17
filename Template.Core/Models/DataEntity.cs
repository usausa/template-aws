namespace Template.Models;

[DynamoDBTable("Data")]
public sealed class DataEntity
{
    [DynamoDBHashKey]
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public DateTime CreatedAt { get; set; }
}
