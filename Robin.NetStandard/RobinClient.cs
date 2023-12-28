using System.Net.Http.Headers;
using System.Text.Json;

namespace Robin.NetStandard;

public class RobinClient:IRobinClient
{
    public static string DefaultBaseUrl = "https://api.robinpowered.com/v1.0/";

    public static HttpClient DefaultClient { get; } = new();

    public HttpClient Client { get; set; }

    public string Token { get; set; }

    private IAuthApi? _auth;
    public IAuthApi Auth => _auth ??= new AuthApi(this);

    private IOrganizationApi? _org;
    public IOrganizationApi Organization => _org ??= new OrganizationApi(this);

    public RobinClient(string token) : this(null, token) { }

    public RobinClient(HttpClient? client, string token)
    {
        Client = client ?? DefaultClient;
        Token = token;
    }

    async Task<ApiResponse<TResponse?>?> IRobinClient.MakeJsonCall<TResponse>(HttpMethod method, string path) where TResponse : default
    {
        var message = new HttpRequestMessage(HttpMethod.Get, PathUrl(path));

        HandleAuth(message);
        return await MakeRequest<TResponse>(message);
    }

    async Task<ApiResponse<TResponse?>?> IRobinClient.MakeJsonCall<TRequest, TResponse>(HttpMethod method, string path, TRequest request) where TResponse : default
    {
        var content = new StringContent(JsonSerializer.Serialize(request));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
        var message = new HttpRequestMessage(HttpMethod.Post, PathUrl(path)) { Content = content };

        HandleAuth(message);
        return await MakeRequest<TResponse>(message);
    }

    private async Task<ApiResponse<TResponse?>?> MakeRequest<TResponse>(HttpRequestMessage message)
    {
        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await Client.SendAsync(message);
        var stream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<ApiResponse<TResponse?>>(stream);
    }

    private static Uri PathUrl(string methodCall) => new(new Uri(DefaultBaseUrl), methodCall);

    private void HandleAuth(HttpRequestMessage message)
    {
        if (!string.IsNullOrWhiteSpace(Token))
        {
            message.Headers.Authorization = new AuthenticationHeaderValue("Access-Token", Token);
        }
    }
}