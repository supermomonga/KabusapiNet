namespace KabusapiNet.Models;

/// <summary>
/// 受渡区分
/// </summary>
public enum DeliveryType
{
    /// <summary>
    /// 指定なし
    /// </summary>
    None = 0,

    /// <summary>
    /// 自動振替
    /// </summary>
    Auto = 1,

    /// <summary>
    /// お預かり金
    /// </summary>
    Deposit = 2
}
