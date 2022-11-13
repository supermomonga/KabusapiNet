namespace KabusapiNet.Models;

/// <summary>
/// 口座種別
/// </summary>
public enum AccountType
{
    Unknown = 0,

    /// <summary>
    /// 一般口座
    /// </summary>
    GeneralAccount = 2,

    /// <summary>
    /// 特定口座
    /// </summary>
    SpecifiedAccount = 4,

    /// <summary>
    /// 法人口座
    /// </summary>
    CorporateAccount = 12
}
