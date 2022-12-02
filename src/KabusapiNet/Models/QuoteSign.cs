using System.Runtime.Serialization;

namespace KabusapiNet.Models;

/// <summary>
/// 最良気配値フラグ
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum QuoteSign
{
    /// <summary>
    /// 事象なし
    /// </summary>
    [EnumMember(Value = "0000")]
    None = 0000,

    /// <summary>
    /// 一般気配
    /// </summary>
    [EnumMember(Value = "0101")]
    General = 0101,

    /// <summary>
    /// 特別気配
    /// </summary>
    [EnumMember(Value = "0102")]
    Special = 0102,

    /// <summary>
    /// 注意気配
    /// </summary>
    [EnumMember(Value = "0103")]
    Warning = 0103,

    /// <summary>
    /// 寄前気配
    /// </summary>
    [EnumMember(Value = "0107")]
    BeforeSessionOpen = 0107,

    /// <summary>
    /// 停止前特別気配
    /// </summary>
    [EnumMember(Value = "0108")]
    SpecialBeforeStop = 0108,

    /// <summary>
    /// 引け後気配
    /// </summary>
    [EnumMember(Value = "0109")]
    AfterSessionClose = 0109,

    /// <summary>
    /// 寄前気配約定成立ポイントなし
    /// </summary>
    [EnumMember(Value = "0116")]
    UnmatchedBeforeSessionOpen = 0116,

    /// <summary>
    /// 寄前気配約定成立ポイントあり
    /// </summary>
    [EnumMember(Value = "0117")]
    MatchedBeforeSessionOpen = 0117,

    /// <summary>
    /// 連続約定気配
    /// </summary>
    [EnumMember(Value = "0118")]
    ContinuouslyExecuted = 0118,

    /// <summary>
    /// 停止前の連続約定気配
    /// </summary>
    [EnumMember(Value = "0119")]
    ContinuouslyExecutedBeforeStop = 0119,

    /// <summary>
    /// 買い上がり売り下がり中
    /// </summary>
    [EnumMember(Value = "0120")]
    BuyingUpOrSellingDown = 0120,
}
