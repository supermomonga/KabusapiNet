namespace KabusapiNet.Models;

/// <summary>
/// 時価情報・板情報
/// </summary>
public class GetBoardResponse
{
    [JsonPropertyName("Symbol")]
    public string Symbol { get; init; }

    [JsonPropertyName("SymbolName")]
    public string SymbolName { get; init; }

    [JsonPropertyName("Exchange")]
    public ExchangeCode Exchange { get; init; }

    [JsonPropertyName("ExchangeName")]
    public string ExchangeName { get; init; }

    [JsonPropertyName("CurrentPrice")]
    public double CurrentPrice { get; init; }

    [JsonPropertyName("CurrentPriceTime")]
    public DateTimeOffset CurrentPriceTime { get; init; }

    [JsonPropertyName("CurrentPriceChangeStatus")]
    public CurrentPriceChangeStatus CurrentPriceChangeStatus { get; init; }

    [JsonPropertyName("CurrentPriceStatus")]
    public CurrentPriceStatus CurrentPriceStatus { get; init; }

    [JsonPropertyName("CalcPrice")]
    public double CalcPrice { get; init; }

    [JsonPropertyName("PreviousClose")]
    public double PreviousClose { get; init; }

    [JsonPropertyName("PreviousCloseTime")]
    public DateTimeOffset PreviousCloseTime { get; init; }

    [JsonPropertyName("ChangePreviousClose")]
    public double ChangePreviousClose { get; init; }

    [JsonPropertyName("ChangePreviousClosePer")]
    public double ChangePreviousClosePer { get; init; }

    [JsonPropertyName("OpeningPrice")]
    public double OpeningPrice { get; init; }

    [JsonPropertyName("OpeningPriceTime")]
    public DateTimeOffset OpeningPriceTime { get; init; }

    [JsonPropertyName("HighPrice")]
    public double HighPrice { get; init; }

    [JsonPropertyName("HighPriceTime")]
    public DateTimeOffset HighPriceTime { get; init; }

    [JsonPropertyName("LowPrice")]
    public double LowPrice { get; init; }

    [JsonPropertyName("LowPriceTime")]
    public DateTimeOffset LowPriceTime { get; init; }

    [JsonPropertyName("TradingVolume")]
    public double TradingVolume { get; init; }

    [JsonPropertyName("TradingVolumeTime")]
    public DateTimeOffset TradingVolumeTime { get; init; }

    [JsonPropertyName("VWAP")]
    public double Vwap { get; init; }

    [JsonPropertyName("TradingValue")]
    public double TradingValue { get; init; }

    [JsonPropertyName("BidQty")]
    public double BidQuantity { get; init; }

    [JsonPropertyName("BidPrice")]
    public double BidPrice { get; init; }

    [JsonPropertyName("BidTime")]
    public DateTimeOffset BidTime { get; init; }

    [JsonPropertyName("BidSign")]
    public QuoteSign BidSign { get; init; }

    [JsonPropertyName("MarketOrderSellQty")]
    public double MarketOrderSellQuantity { get; init; }

    [JsonPropertyName("Sell1")]
    public GetBoardResponseBestOrderLevelItem Sell1 { get; init; }

    [JsonPropertyName("Sell2")]
    public GetBoardResponseOrderLevelItem Sell2 { get; init; }

    [JsonPropertyName("Sell3")]
    public GetBoardResponseOrderLevelItem Sell3 { get; init; }

    [JsonPropertyName("Sell4")]
    public GetBoardResponseOrderLevelItem Sell4 { get; init; }

    [JsonPropertyName("Sell5")]
    public GetBoardResponseOrderLevelItem Sell5 { get; init; }

    [JsonPropertyName("Sell6")]
    public GetBoardResponseOrderLevelItem Sell6 { get; init; }

    [JsonPropertyName("Sell7")]
    public GetBoardResponseOrderLevelItem Sell7 { get; init; }

    [JsonPropertyName("Sell8")]
    public GetBoardResponseOrderLevelItem Sell8 { get; init; }

    [JsonPropertyName("Sell9")]
    public GetBoardResponseOrderLevelItem Sell9 { get; init; }

    [JsonPropertyName("Sell10")]
    public GetBoardResponseOrderLevelItem Sell10 { get; init; }

    [JsonPropertyName("AskQty")]
    public double AskQuantity { get; init; }

    [JsonPropertyName("AskPrice")]
    public double AskPrice { get; init; }

    [JsonPropertyName("AskTime")]
    public DateTimeOffset AskTime { get; init; }

    [JsonPropertyName("AskSign")]
    public QuoteSign AskSign { get; init; }

    [JsonPropertyName("MarketOrderBuyQty")]
    public double MarketOrderBuyQuantity { get; init; }

    [JsonPropertyName("Buy1")]
    public GetBoardResponseBestOrderLevelItem Buy1 { get; init; }

    [JsonPropertyName("Buy2")]
    public GetBoardResponseOrderLevelItem Buy2 { get; init; }

    [JsonPropertyName("Buy3")]
    public GetBoardResponseOrderLevelItem Buy3 { get; init; }

    [JsonPropertyName("Buy4")]
    public GetBoardResponseOrderLevelItem Buy4 { get; init; }

    [JsonPropertyName("Buy5")]
    public GetBoardResponseOrderLevelItem Buy5 { get; init; }

    [JsonPropertyName("Buy6")]
    public GetBoardResponseOrderLevelItem Buy6 { get; init; }

    [JsonPropertyName("Buy7")]
    public GetBoardResponseOrderLevelItem Buy7 { get; init; }

    [JsonPropertyName("Buy8")]
    public GetBoardResponseOrderLevelItem Buy8 { get; init; }

    [JsonPropertyName("Buy9")]
    public GetBoardResponseOrderLevelItem Buy9 { get; init; }

    [JsonPropertyName("Buy10")]
    public GetBoardResponseOrderLevelItem Buy10 { get; init; }

    [JsonPropertyName("OverSellQty")]
    public double OverSellQuantity { get; init; }

    [JsonPropertyName("UnderBuyQty")]
    public double UnderBuyQuantity { get; init; }

    [JsonPropertyName("TotalMarketValue")]
    public double TotalMarketValue { get; init; }

    [JsonPropertyName("SecurityType")]
    public double SecurityType { get; init; }

    [JsonConstructor]
    public GetBoardResponse(
        string symbol,
        string symbolName,
        ExchangeCode exchange,
        string exchangeName,
        double currentPrice,
        DateTimeOffset currentPriceTime,
        CurrentPriceChangeStatus currentPriceChangeStatus,
        CurrentPriceStatus currentPriceStatus,
        double calcPrice,
        double previousClose,
        DateTimeOffset previousCloseTime,
        double changePreviousClose,
        double changePreviousClosePer,
        double openingPrice,
        DateTimeOffset openingPriceTime,
        double highPrice,
        DateTimeOffset highPriceTime,
        double lowPrice,
        DateTimeOffset lowPriceTime,
        double tradingVolume,
        DateTimeOffset tradingVolumeTime,
        double vwap,
        double tradingValue,
        double bidQuantity,
        double bidPrice,
        DateTimeOffset bidTime,
        QuoteSign bidSign,
        double marketOrderSellQuantity,
        GetBoardResponseBestOrderLevelItem sell1,
        GetBoardResponseOrderLevelItem sell2,
        GetBoardResponseOrderLevelItem sell3,
        GetBoardResponseOrderLevelItem sell4,
        GetBoardResponseOrderLevelItem sell5,
        GetBoardResponseOrderLevelItem sell6,
        GetBoardResponseOrderLevelItem sell7,
        GetBoardResponseOrderLevelItem sell8,
        GetBoardResponseOrderLevelItem sell9,
        GetBoardResponseOrderLevelItem sell10,
        double askQuantity,
        double askPrice,
        DateTimeOffset askTime,
        QuoteSign askSign,
        double marketOrderBuyQuantity,
        GetBoardResponseBestOrderLevelItem buy1,
        GetBoardResponseOrderLevelItem buy2,
        GetBoardResponseOrderLevelItem buy3,
        GetBoardResponseOrderLevelItem buy4,
        GetBoardResponseOrderLevelItem buy5,
        GetBoardResponseOrderLevelItem buy6,
        GetBoardResponseOrderLevelItem buy7,
        GetBoardResponseOrderLevelItem buy8,
        GetBoardResponseOrderLevelItem buy9,
        GetBoardResponseOrderLevelItem buy10,
        double overSellQuantity,
        double underBuyQuantity,
        double totalMarketValue,
        double securityType)
    {
        Symbol = symbol;
        SymbolName = symbolName;
        Exchange = exchange;
        ExchangeName = exchangeName;
        CurrentPrice = currentPrice;
        CurrentPriceTime = currentPriceTime;
        CurrentPriceChangeStatus = currentPriceChangeStatus;
        CurrentPriceStatus = currentPriceStatus;
        CalcPrice = calcPrice;
        PreviousClose = previousClose;
        PreviousCloseTime = previousCloseTime;
        ChangePreviousClose = changePreviousClose;
        ChangePreviousClosePer = changePreviousClosePer;
        OpeningPrice = openingPrice;
        OpeningPriceTime = openingPriceTime;
        HighPrice = highPrice;
        HighPriceTime = highPriceTime;
        LowPrice = lowPrice;
        LowPriceTime = lowPriceTime;
        TradingVolume = tradingVolume;
        TradingVolumeTime = tradingVolumeTime;
        Vwap = vwap;
        TradingValue = tradingValue;
        BidQuantity = bidQuantity;
        BidPrice = bidPrice;
        BidTime = bidTime;
        BidSign = bidSign;
        MarketOrderSellQuantity = marketOrderSellQuantity;
        Sell1 = sell1;
        Sell2 = sell2;
        Sell3 = sell3;
        Sell4 = sell4;
        Sell5 = sell5;
        Sell6 = sell6;
        Sell7 = sell7;
        Sell8 = sell8;
        Sell9 = sell9;
        Sell10 = sell10;
        AskQuantity = askQuantity;
        AskPrice = askPrice;
        AskTime = askTime;
        AskSign = askSign;
        MarketOrderBuyQuantity = marketOrderBuyQuantity;
        Buy1 = buy1;
        Buy2 = buy2;
        Buy3 = buy3;
        Buy4 = buy4;
        Buy5 = buy5;
        Buy6 = buy6;
        Buy7 = buy7;
        Buy8 = buy8;
        Buy9 = buy9;
        Buy10 = buy10;
        OverSellQuantity = overSellQuantity;
        UnderBuyQuantity = underBuyQuantity;
        TotalMarketValue = totalMarketValue;
        SecurityType = securityType;
    }

    #region Normalized properties

    private IReadOnlyCollection<IOrderLevel> CreateBids()
        => new IOrderLevel[] {
            Buy1,
            Buy2,
            Buy3,
            Buy4,
            Buy5,
            Buy6,
            Buy7,
            Buy8,
            Buy9,
            Buy10,
        }.AsReadOnly();

    public IReadOnlyCollection<IOrderLevel>? _Bids;
    public IReadOnlyCollection<IOrderLevel> Bids
        => _Bids ??= CreateBids();

    private IReadOnlyCollection<IOrderLevel> CreateAsks()
        => new IOrderLevel[] {
            Sell1,
            Sell2,
            Sell3,
            Sell4,
            Sell5,
            Sell6,
            Sell7,
            Sell8,
            Sell9,
            Sell10,
        }.AsReadOnly();

    public IReadOnlyCollection<IOrderLevel>? _Asks;
    public IReadOnlyCollection<IOrderLevel> Asks
        => _Asks ??= CreateAsks();

    private DateTimeOffset? _UpdatedAt;
    public DateTimeOffset UpdatedAt
    {
        get
        {
            if (_UpdatedAt is null)
            {
                _UpdatedAt = new DateTimeOffset[5] {
                    CurrentPriceTime,
                    OpeningPriceTime,
                    TradingVolumeTime,
                    BidTime,
                    AskTime
                }.Max();
            }
            return _UpdatedAt.Value;
        }
    }

    #endregion Normalized properties
}
