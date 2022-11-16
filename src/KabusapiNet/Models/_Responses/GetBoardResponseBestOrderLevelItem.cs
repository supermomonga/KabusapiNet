namespace KabusapiNet.Models;

/// <summary>
/// 最良気配値
/// </summary>
public class GetBoardResponseBestOrderLevelItem
{
    /// <summary>
    /// 時刻
    /// </summary>
    [JsonPropertyName("Time")]
    public DateTimeOffset Time { get; init; }

    /// <summary>
    /// 気配フラグ
    /// </summary>
    [JsonPropertyName("Sign")]
    public QuoteSign Sign { get; init; }

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
    public GetBoardResponseBestOrderLevelItem(DateTimeOffset time, QuoteSign sign, double price, double quantity)
    {
        Time = time;
        Sign = sign;
        Price = price;
        Quantity = quantity;
    }
}
