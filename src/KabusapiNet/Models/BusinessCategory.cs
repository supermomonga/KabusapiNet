namespace KabusapiNet.Models;

/// <summary>
/// 業種コード
/// </summary>
public enum BusinessCategory
{
    /// <summary>
    /// 水産・農林業
    /// </summary>
    FisheryOrAgricultureAndForestry = 0050,

    /// <summary>
    /// 鉱業
    /// </summary>
    Mining = 1050,

    /// <summary>
    /// 建設業
    /// </summary>
    Construction = 2050,

    /// <summary>
    /// 食料品
    /// </summary>
    Foods = 3050,

    /// <summary>
    /// 繊維製品
    /// </summary>
    TextilesAndApparels = 3100,

    /// <summary>
    /// パルプ・紙
    /// </summary>
    PulpAndPaper = 3150,

    /// <summary>
    /// 化学
    /// </summary>
    Chemicals = 3200,

    /// <summary>
    /// 医薬品
    /// </summary>
    Pharmaceutical = 3250,

    /// <summary>
    /// 石油・石炭製品
    /// </summary>
    OilAndCoalProducts = 3300,

    /// <summary>
    /// ゴム製品
    /// </summary>
    RubberProducts = 3350,

    /// <summary>
    /// ガラス・土石製品
    /// </summary>
    GlassAndCeramicsProducts = 3400,

    /// <summary>
    /// 鉄鋼
    /// </summary>
    IronAndSteel = 3450,

    /// <summary>
    /// 非鉄金属
    /// </summary>
    NonferrousMetals = 3500,

    /// <summary>
    /// 金属製品
    /// </summary>
    MetalProducts = 3550,

    /// <summary>
    /// 機械
    /// </summary>
    Machinery = 3600,

    /// <summary>
    /// 電気機器
    /// </summary>
    ElectricAppliances = 3650,

    /// <summary>
    /// 輸送用機器
    /// </summary>
    TransportationEquipment = 3700,

    /// <summary>
    /// 精密機器
    /// </summary>
    PrecisionInstruments = 3750,

    /// <summary>
    /// その他製品
    /// </summary>
    OtherProducts = 3800,

    /// <summary>
    /// 電気・ガス業
    /// </summary>
    ElectricPowerAndGas = 4050,

    /// <summary>
    /// 陸運業
    /// </summary>
    LandTransportation = 5050,

    /// <summary>
    /// 海運業
    /// </summary>
    MarineTransportation = 5100,

    /// <summary>
    /// 空運業
    /// </summary>
    AirTransportation = 5150,

    /// <summary>
    /// 倉庫・運輸関連業
    /// </summary>
    WarehousingAndHarborTransportation = 5200,

    /// <summary>
    /// 情報・通信業
    /// </summary>
    InformationAndCommunication = 5250,

    /// <summary>
    /// 卸売業
    /// </summary>
    WholesaleTrade = 6050,

    /// <summary>
    /// 小売業
    /// </summary>
    RetailTrade = 6100,

    /// <summary>
    /// 銀行業
    /// </summary>
    Banks = 7050,

    /// <summary>
    /// 証券、商品先物取引業
    /// </summary>
    SecuritiesAndCommoditiesFutures = 7100,

    /// <summary>
    /// 保険業
    /// </summary>
    Insurance = 7150,

    /// <summary>
    /// その他金融業
    /// </summary>
    OtherFinancingBusiness = 7200,

    /// <summary>
    /// 不動産業
    /// </summary>
    RealEstate = 8050,

    /// <summary>
    /// サービス業
    /// </summary>
    Services = 9050,

    /// <summary>
    /// その他
    /// </summary>
    Other = 9999
}
