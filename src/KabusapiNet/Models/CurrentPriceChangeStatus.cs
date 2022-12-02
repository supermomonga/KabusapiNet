using System.Runtime.Serialization;

namespace KabusapiNet.Models;

/// <summary>
/// 現値前値比較
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CurrentPriceChangeStatus
{
    /// <summary>
    /// 事象なし
    /// </summary>
    [EnumMember(Value = "0000")]
    None = 0000,

    /// <summary>
    /// 変わらず
    /// </summary>
    [EnumMember(Value = "0056")]
    Unchanged = 0056,

    /// <summary>
    /// UP
    /// </summary>
    [EnumMember(Value = "0057")]
    Up = 0057,

    /// <summary>
    /// DOWN
    /// </summary>
    [EnumMember(Value = "0058")]
    Down = 0058,

    /// <summary>
    /// 中断・板寄せ後の初値
    /// </summary>
    [EnumMember(Value = "0059")]
    FirstPrice = 0059,

    /// <summary>
    /// ザラバ引け
    /// </summary>
    [EnumMember(Value = "0060")]
    ContinuousSessionLastClose = 0060,

    /// <summary>
    /// 板寄り引け
    /// </summary>
    [EnumMember(Value = "0061")]
    ItayoseClose = 0061,

    /// <summary>
    /// 中断引け
    /// </summary>
    [EnumMember(Value = "0062")]
    StoppedClose = 0062,

    /// <summary>
    /// ダウン引け
    /// </summary>
    [EnumMember(Value = "0063")]
    DownClose = 0063,

    /// <summary>
    /// 逆転終値
    /// </summary>
    [EnumMember(Value = "0064")]
    OppositeClose = 0064,

    /// <summary>
    /// 特別気配引け
    /// </summary>
    [EnumMember(Value = "0066")]
    SpecialQuoteClose = 0066,

    /// <summary>
    /// 一時留保引け
    /// </summary>
    [EnumMember(Value = "0067")]
    TemporaryReservationClose = 0067,

    /// <summary>
    /// 売買停止引け
    /// </summary>
    [EnumMember(Value = "0068")]
    SuspendedClose = 0068,

    /// <summary>
    /// サーキットブレーカ引け
    /// </summary>
    [EnumMember(Value = "0069")]
    CircuitBreakerClose = 0069,

    /// <summary>
    /// ダイナミックサーキットブレーカ引け
    /// </summary>
    [EnumMember(Value = "0431")]
    DynamicCircuitBreakerClose = 0431,
}
