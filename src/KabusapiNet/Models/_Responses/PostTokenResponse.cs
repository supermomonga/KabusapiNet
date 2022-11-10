namespace KabusapiNet.Models;

/// <summary>
/// APIトークン
/// </summary>
public class PostTokenResponse
{
    /// <summary>
    /// 結果コード
    /// 0が成功。それ以外はエラーコード。
    /// </summary>
    [JsonPropertyName("ResultCode")]
    public int ResultCode { get; init; }

    /// <summary>
    /// APIトークン
    /// </summary>
    [JsonPropertyName("Token")]
    public string Token { get; init; }

    [JsonConstructor]
    public PostTokenResponse(int resultCode, string token)
        => (ResultCode, Token) = (resultCode, token);
}
