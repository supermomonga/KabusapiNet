namespace KabusapiNet.Models;

/// <summary>
/// 登録銘柄情報
/// </summary>
public class SymbolInfo
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
    public SymbolInfo(string symbol, ExchangeCode exchange)
        => (Symbol, Exchange) = (symbol, exchange);
}
