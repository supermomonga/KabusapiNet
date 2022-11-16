namespace KabusapiNet.Models;

/// <summary>
/// 市場コード
/// </summary>
public enum ExchangeCode
{
    /// <summary>
    /// 東証
    /// </summary>
    TokyoStockExchange = 1,

    /// <summary>
    /// 名証
    /// </summary>
    NagoyaStockExchange = 3,

    /// <summary>
    /// 福証
    /// </summary>
    FukuokaStockExchange = 5,

    /// <summary>
    /// 札証
    /// </summary>
    SapporoStockExchange = 6,

    /// <summary>
    /// SOR
    /// </summary>
    SmartOrderRouting = 9,

    #region 先物・オプション

    /// <summary>
    /// 日通し
    /// </summary>
    AllDaySession = 2,

    /// <summary>
    /// 日中
    /// </summary>
    DayTimeSession = 23,

    /// <summary>
    /// 夜間
    /// </summary>
    NightTimeSession = 24,

    #endregion 先物・オプション

    #region 為替

    /// <summary>
    /// 為替
    /// </summary>
    ForeignExchange = 300

    #endregion 為替
}
