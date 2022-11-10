namespace KabusapiNet.Models;

/// <summary>
/// エラー情報
/// </summary>
internal class ErrorResponse
{
    /// <summary>
    /// エラーコード
    /// </summary>
    [JsonPropertyName("Code")]
    public int Code { get; init; }

    /// <summary>
    /// エラーメッセージ
    /// https://kabucom.github.io/kabusapi/ptal/error.html#message
    /// </summary>
    [JsonPropertyName("Message")]
    public string Message { get; init; }

    [JsonConstructor]
    public ErrorResponse(int code, string message)
        => (Code, Message) = (code, message);
}
