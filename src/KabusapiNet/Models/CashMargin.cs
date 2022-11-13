namespace KabusapiNet.Models;

/// <summary>
/// 信用区分
/// </summary>
public enum CashMargin
{
    Unknown = 0,

    /// <summary>
    /// 現物
    /// </summary>
    Cash = 1,

    /// <summary>
    /// 信用新規
    /// </summary>
    MarginOpen = 2,

    /// <summary>
    /// 信用返済
    /// </summary>
    MarginClose = 3
}
