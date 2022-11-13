namespace KabusapiNet.Models;

/// <summary>
/// 制度信用区分
/// </summary>
public enum MarginTradeType
{
    Unknown = 0,

    /// <summary>
    /// 制度信用
    /// </summary>
    SystemMargin = 1,

    /// <summary>
    /// 一般信用（長期）
    /// </summary>
    GeneralMarginLong = 2,

    /// <summary>
    /// 一般信用（デイトレ）
    /// </summary>
    GeneralMarginDay = 3
}
