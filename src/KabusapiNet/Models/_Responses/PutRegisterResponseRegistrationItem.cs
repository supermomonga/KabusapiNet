namespace KabusapiNet.Models;

/// <summary>
/// 登録銘柄情報
/// </summary>
public class PutRegisterResponseRegistrationItem
{
    /// <summary>
    /// 銘柄コード
    /// </summary>
    [JsonPropertyName("Symbol")]
    public string Symbol { get; init; }

    /// <summary>
    /// 市場コード
    /// </summary>
    [JsonPropertyName("Exchange")]
    public ExchangeCode Exchange { get; init; }

    [JsonConstructor]
    public PutRegisterResponseRegistrationItem(string symbol, ExchangeCode exchange)
        => (Symbol, Exchange) = (symbol, exchange);
}
