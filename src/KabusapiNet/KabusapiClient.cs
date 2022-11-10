using KabusapiNet.Models;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace KabusapiNet;

public class KabusapiClient : IDisposable
{

    #region HttpClient

    private HttpClient? _HttpClient;
    public HttpClient HttpClient
    {
        get => _HttpClient ??= new HttpClient();
        set => _HttpClient = value;
    }

    public KabusapiClient(string apiPassword)
    {
        ApiPassword = apiPassword;
    }

    public KabusapiClient(string apiPassword, HttpClient httpClient)
    {
        ApiPassword = apiPassword;
        _HttpClient = httpClient;
    }

    #endregion HttpClient

    public bool IsDemo { get; init; } = false;
    public string ApiPassword { get; set; }

    private string? _ApiToken;
    private string ApiToken
    {
        get
        {
            return _ApiToken ??= string.Empty;
        }
        set
        {
            if (_ApiToken != value)
            {
                _ApiToken = value;
                HttpClient.DefaultRequestHeaders.Remove("X-API-KEY");
                if (string.IsNullOrEmpty(value))
                {
                    _IsAuthenticated = false;
                }
                else
                {
                    _IsAuthenticated = true;
                    HttpClient.DefaultRequestHeaders.Add("X-API-KEY", value);
                }
            }
        }
    }

    private bool _IsAuthenticated;
    public bool IsAuthenticated
        => _IsAuthenticated;

    public bool ShouldAuthenticate
        => !IsAuthenticated;

    private int Port
        => IsDemo ? 18081 : 18080;

    private string? _EndPoint;
    private string EndPoint
        => _EndPoint ??= $"http://localhost:{Port}/";

    #region REST API

    #region Request

    private HttpRequestMessage CreateRequest<TModel>(HttpMethod method, string path, TModel? body)
    {
        var request = new HttpRequestMessage(method, EndPoint + path);

        if (body is not null)
        {
            request.Content = JsonContent.Create(body, mediaType: MediaTypeHeaderValue.Parse("application/json"));
        }

        return request;
    }

    private async Task<TResponse> RequestAsync<TRequest, TResponse>
        (HttpMethod method, string path, TRequest? body, bool throwOnError = true)
    {
        var req = CreateRequest(method, path, body);
        var res = await HttpClient.SendAsync(req).ConfigureAwait(false);

        if (throwOnError)
        {
            res.EnsureSuccessStatusCode();
        }

        using var stream = await res.Content.ReadAsStreamAsync();
        if (res.IsSuccessStatusCode)
        {
            var response = await JsonSerializer.DeserializeAsync<TResponse>(stream).ConfigureAwait(false);
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
            var error = await JsonSerializer.DeserializeAsync<ErrorResponse>(stream).ConfigureAwait(false);
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

    #endregion Request

    #region CRUD

    public async Task<TInterface> GetAsync<TResponse, TInterface>(string path)
        where TResponse : TInterface
        => await RequestAsync<object, TResponse>(HttpMethod.Get, path, null).ConfigureAwait(false);

    public Task<TResponse> GetAsync<TResponse>(string path, bool throwOnError = true)
        => RequestAsync<object, TResponse>(HttpMethod.Get, path, null, throwOnError: throwOnError);

    public Task<TResponse> PostAsync<TResponse>(string path, bool throwOnError = true)
        => RequestAsync<object, TResponse>(HttpMethod.Post, path, null, throwOnError: throwOnError);

    public Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest body, bool throwOnError = true)
        => RequestAsync<TRequest, TResponse>(HttpMethod.Post, path, body, throwOnError: throwOnError);

    public Task<TResponse> PutAsync<TResponse>(string path, bool throwOnError = true)
        => RequestAsync<object, TResponse>(HttpMethod.Put, path, null, throwOnError: throwOnError);

    public Task<TResponse> PutAsync<TRequest, TResponse>(string path, TRequest body, bool throwOnError = true)
        => RequestAsync<TRequest, TResponse>(HttpMethod.Put, path, body, throwOnError: throwOnError);

    #endregion

    #region 認証

    public async Task<PostTokenResponse> PostTokenAsync()
        => await PostAsync<PostTokenResponse>("token");

    public async Task RefreshTokenAsync()
    {
        var res = await PostTokenAsync();
        ApiToken = res.Token;
    }

    public async Task<bool> RefreshTokenIfNeededAsync()
    {
        if (ShouldAuthenticate)
        {
            await RefreshTokenAsync();
            return true;
        }
        return false;
    }

    #endregion 認証

    #endregion REST API

    #region IDisposable

    private bool _IsDisposed { get; set; }

    public void Dispose()
    {
        if (!_IsDisposed)
        {
            _HttpClient?.Dispose();
            _HttpClient = null;
            _IsDisposed = true;
        }
    }

    #endregion IDisposable
}
