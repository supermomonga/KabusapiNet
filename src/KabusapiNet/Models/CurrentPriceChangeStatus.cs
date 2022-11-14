namespace KabusapiNet.Models;

/// <summary>
/// 現値前値比較
/// </summary>
public enum CurrentPriceChangeStatus
{
    /// <summary>
    /// 事象なし
    /// </summary>
    None = 0000,

    /// <summary>
    /// 変わらず
    /// </summary>
    Unchanged = 0056,

    /// <summary>
    /// UP
    /// </summary>
    Up = 0057,

    /// <summary>
    /// DOWN
    /// </summary>
    Down = 0058,

    /// <summary>
    /// 中断・板寄せ後の初値
    /// </summary>
    FirstPrice = 0059,

    /// <summary>
    /// ザラバ引け
    /// </summary>
    ContinuousSessionLastClose = 0060,

    /// <summary>
    /// 板寄り引け
    /// </summary>
    ItayoseClose = 0061,

    /// <summary>
    /// 中断引け
    /// </summary>
    StoppedClose = 0062,

    /// <summary>
    /// ダウン引け
    /// </summary>
    DownClose = 0063,

    /// <summary>
    /// 逆転終値
    /// </summary>
    OppositeClose = 0064,

    /// <summary>
    /// 特別気配引け
    /// </summary>
    SpecialQuoteClose = 0066,

    /// <summary>
    /// 一時留保引け
    /// </summary>
    TemporaryReservationClose = 0067,

    /// <summary>
    /// 売買停止引け
    /// </summary>
    SuspendedClose = 0068,

    /// <summary>
    /// サーキットブレーカ引け
    /// </summary>
    CircuitBreakerClose = 0069,

    /// <summary>
    /// ダイナミックサーキットブレーカ引け
    /// </summary>
    DynamicCircuitBreakerClose = 0431,

}
