namespace KabusapiNet.Models;

/// <summary>
/// 資産区分（預り区分）
/// </summary>
public enum FundType
{
    Unknown = 0,

    /// <summary>
    /// 保護
    /// </summary>
    Protected = 1,

    /// <summary>
    /// 信用代用（代用有価証券）
    /// </summary>
    SubstituteSecurities = 2,

    /// <summary>
    /// 信用取引
    /// </summary>
    MarginTrade = 3
}
