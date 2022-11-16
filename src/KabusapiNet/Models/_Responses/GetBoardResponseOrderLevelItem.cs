namespace KabusapiNet.Models;

/// <summary>
/// 気配値
/// </summary>
public class GetBoardResponseOrderLevelItem
{
    /// <summary>
    /// 値段
    /// </summary>
    [JsonPropertyName("Price")]
    public double Price { get; init; }

    /// <summary>
    /// 数量
    /// </summary>
    [JsonPropertyName("Qty")]
    public double Quantity { get; init; }

    [JsonConstructor]
    public GetBoardResponseOrderLevelItem(double price, double quantity)
    {
        Price = price;
        Quantity = quantity;
    }
}