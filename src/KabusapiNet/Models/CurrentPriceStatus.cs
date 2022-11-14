namespace KabusapiNet.Models;

/// <summary>
/// 現値ステータス
/// </summary>
public enum CurrentPriceStatus
{
    /// <summary>
    /// 現値
    /// </summary>
    CurrentPrice = 1,

    /// <summary>
    /// 不連続歩み
    /// </summary>
    DiscontinuityTick = 2,

    /// <summary>
    /// 板寄せ
    /// </summary>
    Itayose = 3,

    /// <summary>
    /// システム障害
    /// </summary>
    SystemTrouble = 4,

    /// <summary>
    /// 中断
    /// </summary>
    Interrupted = 5,

    /// <summary>
    /// 売買停止
    /// </summary>
    Suspended = 6,

    /// <summary>
    /// 売買停止・システム停止解除
    /// </summary>
    SuspendResolved = 7,

    /// <summary>
    /// 終値
    /// </summary>
    ClosePrice = 8,

    /// <summary>
    /// システム停止
    /// </summary>
    SystemStopped = 9,

    /// <summary>
    /// 概算値
    /// </summary>
    ApproximatePrice = 10,

    /// <summary>
    /// 参考値
    /// </summary>
    ReferencePrice = 11,

    /// <summary>
    /// サーキットブレイク実施中
    /// </summary>
    CircuitBreaking = 12,

    /// <summary>
    /// システム障害解除
    /// </summary>
    SystemTroubleResolved = 13,

    /// <summary>
    /// サーキットブレイク解除
    /// </summary>
    CircuitBreakResolved = 14,

    /// <summary>
    /// 中断解除
    /// </summary>
    InterupptionResoluved = 15,

    /// <summary>
    /// 一時留保中
    /// </summary>
    TemporaryReserved = 16,

    /// <summary>
    /// 一時留保解除
    /// </summary>
    TemporaryReservationResolved = 17,

    /// <summary>
    /// ファイル障害
    /// </summary>
    FileTrouble = 18,

    /// <summary>
    /// ファイル障害解除
    /// </summary>
    FileTroubleResolved = 19,

    /// <summary>
    /// Spread/Strategy
    /// </summary>
    SpreadOrStrategy = 20,

    /// <summary>
    /// ダイナミックサーキットブレイク発動
    /// </summary>
    DynamicCircuitBreaking = 21,

    /// <summary>
    /// ダイナミックサーキットブレイク解除
    /// </summary>
    DynamicCircuitBreakResolved = 22,

    /// <summary>
    /// 板寄せ約定
    /// </summary>
    ItayoseExecuted = 23
}
