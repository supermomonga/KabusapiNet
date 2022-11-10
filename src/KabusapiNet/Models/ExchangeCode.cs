namespace KabusapiNet.Models;

/// <summary>
/// 市場コード
/// </summary>
public enum ExchangeCode
{
    Unknwon = 0,

    /// <summary>
    /// 東証
    /// </summary>
    TokyoStockExchange = 1,

    /// <summary>
    /// 明証
    /// </summary>
    NagoyaStockExchange = 2,

    /// <summary>
    /// 福証
    /// </summary>
    FukuokaStockExchange = 5,

    /// <summary>
    /// 札証
    /// </summary>
    SapporoStockExchange = 6,
}
