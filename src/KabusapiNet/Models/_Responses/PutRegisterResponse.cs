namespace KabusapiNet.Models;

/// <summary>
/// 現在登録されている銘柄のリスト
/// </summary>
public class PutRegisterResponse
{
    /// <summary>
    /// 現在登録されている銘柄のリスト
    /// </summary>
    [JsonPropertyName("RegistList")]
    public IReadOnlyList<SymbolInfo> RegistrationItems { get; init; }

    public PutRegisterResponse(IReadOnlyList<SymbolInfo> registrationItems)
        => RegistrationItems = registrationItems;
}
