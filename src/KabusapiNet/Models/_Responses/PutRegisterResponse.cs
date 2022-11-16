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
    public IReadOnlyList<PutRegisterResponseRegistrationItem> RegistrationItems { get; init; }

    public PutRegisterResponse(IReadOnlyList<PutRegisterResponseRegistrationItem> registrationItems)
        => RegistrationItems = registrationItems;
}
