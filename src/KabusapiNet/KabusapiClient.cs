using KabusapiNet.Models;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Text.Json;

using Websocket.Client;

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
        => _EndPoint ??= $"http://localhost:{Port}/kabusapi/";

    private WebsocketClient? _Socket;

    private Uri? _SocketEndPoint;

    private Uri SocketEndPoint
        => _SocketEndPoint ??= new Uri($"ws://localhost:{Port}/kabusapi/websocket");

    public event EventHandler<EventArgs>? OnConnecting;

    public event EventHandler<EventArgs>? OnDisconnected;

    public event EventHandler<DataReceivedEventArgs<GetBoardResponse>>? OnBoardReceived;



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
            var response = await JsonSerializer.DeserializeAsync<TResponse>(stream)
                .ConfigureAwait(false);
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
            var error = await JsonSerializer.DeserializeAsync<ErrorResponse>(stream)
                .ConfigureAwait(false);
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
        => await PostAsync<PostTokenRequest, PostTokenResponse>("token", new PostTokenRequest(ApiPassword));

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

    #region 発注

    #endregion 発注

    #region 情報

    /// <summary>
    /// 指定した銘柄の時価情報・板情報を取得します
    /// </summary>
    /// <param name="symbol">銘柄コード</param>
    /// <param name="exchange">市場</param>
    /// <returns></returns>
    public async Task<GetBoardResponse> GetBoardAsync(string symbol, ExchangeCode exchange)
        => await GetAsync<GetBoardResponse>($"board/{symbol}@{(int)exchange}");

    #endregion 情報

    #region 銘柄登録

    #region 銘柄登録

    /// <summary>
    /// PUSH配信する銘柄を登録します。
    /// </summary>
    /// <param name="symbols">登録する銘柄のリスト</param>
    /// <returns></returns>
    public async Task<PutRegisterResponse> PutRegisterAsync(IList<SymbolInfo> symbols)
    {
        var payload = new PutRegisterRequest(symbols);
        return await PutAsync<PutRegisterRequest, PutRegisterResponse>("register", payload);
    }

    /// <summary>
    /// PUSH配信する銘柄を登録します。
    /// </summary>
    /// <param name="symbol">登録する銘柄</param>
    /// <returns></returns>
    public async Task<PutRegisterResponse> PutRegisterAsync(SymbolInfo symbol)
        => await PutRegisterAsync(new SymbolInfo[] { symbol });

    #endregion 銘柄登録

    #region 銘柄登録解除

    /// <summary>
    /// API登録銘柄リストに登録されている銘柄を解除します
    /// </summary>
    /// <param name="symbols">登録解除する銘柄のリスト</param>
    /// <returns></returns>
    public async Task<PutRegisterResponse> PutUnregisterAsync(IList<SymbolInfo> symbols)
    {
        var payload = new PutRegisterRequest(symbols);
        return await PutAsync<PutRegisterRequest, PutRegisterResponse>("unregister", payload);
    }

    /// <summary>
    /// API登録銘柄リストに登録されている銘柄を解除します
    /// </summary>
    /// <param name="symbol">登録解除する銘柄</param>
    /// <returns></returns>
    public async Task<PutRegisterResponse> PutUnregisterAsync(SymbolInfo symbol)
        => await PutUnregisterAsync(new SymbolInfo[] { symbol });

    #endregion 銘柄登録解除

    #region 銘柄登録全解除

    /// <summary>
    /// API登録銘柄リストに登録されている銘柄をすべて解除します
    /// </summary>
    /// <returns></returns>
    public async Task<PutRegisterResponse> PutUnregisterAllAsync()
        => await PutAsync<PutRegisterResponse>("unregister/all");

    #endregion 銘柄登録全解除

    #endregion 銘柄登録

    #endregion REST API

    #region WebSocket API

    public async Task SubscribeAsync()
    {
        _Socket?.Dispose();

        _Socket = new WebsocketClient(SocketEndPoint);
        _Socket.DisconnectionHappened.Subscribe(msg =>
        {
            OnDisconnected?.Invoke(this, new EventArgs());
        });
        _Socket.ReconnectionHappened.Subscribe(msg =>
        {
            OnConnecting?.Invoke(this, new EventArgs());
        });
        _Socket.MessageReceived.Subscribe(msg =>
        {
            if (msg.MessageType == WebSocketMessageType.Text)
            {
                var res = JsonSerializer.Deserialize<GetBoardResponse>(msg.Text);
                if (res is not null)
                {
                    OnBoardReceived?.Invoke(this, new DataReceivedEventArgs<GetBoardResponse>(res));
                }
            }
        });
        await _Socket.Start();
    }

    public void Unsubscribe()
    {
        var s = _Socket;
        _Socket = null;
        if (s is not null)
        {
            s.IsReconnectionEnabled = false;
            s.Dispose();
        }
    }

    #endregion WebSocket API

    #region IDisposable

    private bool _IsDisposed { get; set; }

    public void Dispose()
    {
        if (!_IsDisposed)
        {
            _Socket?.Dispose();
            _Socket = null;
            _HttpClient?.Dispose();
            _HttpClient = null;
            _IsDisposed = true;
        }
    }

    #endregion IDisposable
}
