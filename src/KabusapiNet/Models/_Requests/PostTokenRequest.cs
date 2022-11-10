namespace KabusapiNet.Models;

/// <summary>
/// トークン発行リクエスト
/// </summary>
internal class PostTokenRequest
{
	/// <summary>
	/// APIパスワード
	/// </summary>
	[JsonPropertyName("APIPassword")]
	public string ApiPassword { get; init; }

	public PostTokenRequest(string apiPassword)
		=> ApiPassword = apiPassword;
}
