namespace KabusapiNet.Models;

/// <summary>
/// 執行条件 
/// </summary>
public enum FrontOrderType
{
    /// <summary>
    /// 成行
    /// </summary>
    MarketOrder = 10,

    /// <summary>
    /// 成寄
    /// </summary>
    MarketOrderOnMorningSessionOpen = 13,

    /// <summary>
    /// 寄成（後場）
    /// </summary>
    MarketOrderOnEveningSessionOpen = 14,

    /// <summary>
    /// 引成（前場）
    /// </summary>
    MarketOrderOnMorningSessionClose = 15,

    /// <summary>
    /// 引成（後場）
    /// </summary>
    MarketOrderOnEveningSessionClose = 16,

    /// <summary>
    /// IOC成行
    /// </summary>
    ImmediateOrCancelMarketOrder = 17,

    /// <summary>
    /// 指値
    /// </summary>
    LimitOrder = 20,

    /// <summary>
    /// 寄指（前場） 
    /// </summary>
    LimitOrderOnMorningSessionOpen = 21,

    /// <summary>
    /// 寄指（後場） 
    /// </summary>
    LimitOrderOnEveningSessionOpen = 22,

    /// <summary>
    /// 引指（前場） 
    /// </summary>
    LimitOrderOnMorningSessionClose = 23,

    /// <summary>
    /// 引指（後場） 
    /// </summary>
    LimitOrderOnEveningSessionClose = 24,

    /// <summary>
    /// 不成（前場） 
    /// </summary>
    NoLimitOrderAtTheMorningSessionClosing = 25,

    /// <summary>
    /// 不成（後場） 
    /// </summary>
    NoLimitOrderAtTheEveningSessionClosing = 26,

    /// <summary>
    /// IOC指値
    /// </summary>
    ImmediateOrCancelLimitOrder = 27,

    /// <summary>
    /// 逆指値
    /// </summary>
    LimitOrderAfterHit = 30,


    #region 先物・オプション

    /// <summary>
    /// 引成（金融派生商品）
    /// </summary>
    MarketOrderOnSessionCloseForFinancialDerivative = 18,

    /// <summary>
    /// 引指（金融派生商品）
    /// </summary>
    LimitOrderOnSessionCloseForFinancialDerivative = 28,

    /// <summary>
    /// 成行（金融派生商品）
    /// </summary>
    MarketOrderForFinancialDerivative = 120

    #endregion 先物
}
