namespace KabusapiNet.Models;

/// <summary>
/// 現在登録されている銘柄の編集リクエスト
/// </summary>
public class PutRegisterRequest
{
    /// <summary>
    /// 現在登録されている銘柄のリスト
    /// </summary>
    [JsonPropertyName("Symbols")]
    public IList<SymbolInfo> Symbols { get; init; }

    public PutRegisterRequest(IList<SymbolInfo> registrationItems)
        => Symbols = registrationItems;
}
