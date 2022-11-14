namespace KabusapiNet.Models;

/// <summary>
/// 有効期間条件
/// </summary>
public enum TimeInForce
{
    /// <summary>
    /// FAS
    /// </summary>
    FillAndStore = 1,

    /// <summary>
    /// FAK
    /// </summary>
    FillAndKill = 2,

    /// <summary>
    /// FOK
    /// </summary>
    FillOrKill = 3
}
