using KabusapiNet.Models;

using System.Net.Http.Json;
using System.Text.Json;

namespace KabusapiNet;

public class KabusapiClient
{

	#region HttpClient

	private HttpClient? _HttpClient;
	public HttpClient HttpClient
	{
		get => _HttpClient ??= new HttpClient();
		set => _HttpClient = value;
	}

	public KabusapiClient()
	{ }

	public KabusapiClient(HttpClient httpClient)
		=> _HttpClient = httpClient;

	#endregion HttpClient

	public bool IsDemo { get; set; } = false;
	public string ApiPassword { get; set; }

	private string? _ApiToken;

	#region REST API

	#region Request

	private async Task<TResponse> RequestAsync<TResponse>(HttpRequestMessage request)
	{
		var res = await HttpClient.SendAsync(request);
		using var stream = await res.Content.ReadAsStreamAsync();
		if (res.IsSuccessStatusCode)
		{
			var response = await JsonSerializer.DeserializeAsync<TResponse>(stream);
			if (response is null)
			{
				throw new Exception("Failed to parse response.");
			}
			else
			{
				return response;
			}
		}
		else
		{
			var error = await JsonSerializer.DeserializeAsync<ErrorResponse>(stream);
			if (error is null)
			{
				throw new Exception("Unknown error.");
			}
			else
			{
				throw new Exception($"{error.Code}: {error.Message}");
			}
		}
	}

	private async Task<TResponse> GetAsync<TResponse>(Uri uri)
	{
		var req = new HttpRequestMessage(HttpMethod.Get, uri);
		return await RequestAsync<TResponse>(req);
	}

	private async Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request)
	{
		var req = new HttpRequestMessage(HttpMethod.Post, uri);
		req.Content = JsonContent.Create(request);
		return await RequestAsync<TResponse>(req);
	}

	#endregion Request

	#region 認証

	public async Task<PostTokenResponse> PostTokenAsync(string apiPassword)
	{
		return PostAsync<PostTokenResponse>(new Uri("http://localhost:"))
	}

	#endregion 認証

	#endregion REST API
}
