namespace KabusapiNet.Models;

/// <summary>
/// 商品種別
/// </summary>
internal enum SecurityType
{
    /// <summary>
    /// 指数
    /// </summary>
    Index = 0,

    /// <summary>
    /// 現物
    /// </summary>
    Spot = 1,

    /// <summary>
    /// 日経225先物
    /// </summary>
    Nikkei225Future = 101,

    /// <summary>
    /// 日経225OP
    /// </summary>
    Nikkei225Option = 103,

    /// <summary>
    /// TOPIX先物
    /// </summary>
    TopixFuture = 107,

    /// <summary>
    /// JPX400先物
    /// </summary>
    Jpx400Future = 121,

    /// <summary>
    /// NYダウ
    /// </summary>
    NewYorkDow = 144,

    /// <summary>
    /// 日経平均VI
    /// </summary>
    NikkeiHeikinVI = 145,

    /// <summary>
    /// 東証マザーズ指数先物
    /// </summary>
    MothersIndexFuture = 154,

    /// <summary>
    /// TOPIX_REIT
    /// </summary>
    TopixReit = 155,

    /// <summary>
    /// TOPIX CORE30
    /// </summary>
    TopixCore30 = 171,

    /// <summary>
    /// 日経平均225ミニ先物
    /// </summary>
    NikkeiHeikin225MiniFuture = 901,

    /// <summary>
    /// TOPIXミニ先物
    /// </summary>
    TopicMiniFuture = 907,
}
