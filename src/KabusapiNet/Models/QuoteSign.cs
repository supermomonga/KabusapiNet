namespace KabusapiNet.Models;

/// <summary>
/// 最良気配値フラグ
/// </summary>
public enum QuoteSign
{
    /// <summary>
    /// 事象なし
    /// </summary>
    None = 0000,

    /// <summary>
    /// 一般気配
    /// </summary>
    General = 0101,

    /// <summary>
    /// 特別気配
    /// </summary>
    Special = 0102,

    /// <summary>
    /// 注意気配
    /// </summary>
    Warning = 0103,

    /// <summary>
    /// 寄前気配
    /// </summary>
    BeforeSessionOpen = 0107,

    /// <summary>
    /// 停止前特別気配
    /// </summary>
    SpecialBeforeStop = 0108,

    /// <summary>
    /// 引け後気配
    /// </summary>
    AfterSessionClose = 0109,

    /// <summary>
    /// 寄前気配約定成立ポイントなし
    /// </summary>
    UnmatchedBeforeSessionOpen = 0116,

    /// <summary>
    /// 寄前気配約定成立ポイントあり
    /// </summary>
    MatchedBeforeSessionOpen = 0117,

    /// <summary>
    /// 連続約定気配
    /// </summary>
    ContinuouslyExecuted = 0118,

    /// <summary>
    /// 停止前の連続約定気配
    /// </summary>
    ContinuouslyExecutedBeforeStop = 0119,

    /// <summary>
    /// 買い上がり売り下がり中
    /// </summary>
    BuyingUpOrSellingDown = 0120,
}
