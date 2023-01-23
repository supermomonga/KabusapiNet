
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

    public override bool Equals(object? obj)
    {
        if (obj is SymbolInfo si)
        {
            return si.Symbol.Equals(Symbol) && si.Exchange.Equals(Exchange);
        }
        return false;
    }

    public override int GetHashCode()
        => Symbol.GetHashCode() ^ Exchange.GetHashCode();

    public static bool operator ==(SymbolInfo o1, SymbolInfo o2)
        => EqualityComparer<SymbolInfo>.Default.Equals(o1, o2);

    public static bool operator !=(SymbolInfo o1, SymbolInfo o2)
        => !(o1 == o2);
}
