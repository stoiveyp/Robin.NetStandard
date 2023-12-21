using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Robin.NetStandard;

public class RobinClient
{
    public static string DefaultBaseUrl = "https://api.robinpowered.com/v1.0/";

    public static HttpClient DefaultClient { get; } = new();

    public HttpClient Client { get; set; }

    public string Token { get; set; }

    public RobinClient(string token):this(null,token){}

    public RobinClient(HttpClient? client, string token)
    {
        Client = client ?? DefaultClient;
        Token = token;
    }

    async Task<TResponse> IWebApiClient.MakeJsonCall<TRequest, TResponse>(HttpMethod method, string path, TRequest request)
    {
        try
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };

            var message = new HttpRequestMessage(HttpMethod.Post, PathUrl(path)) { Content = content };
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HandleAuth(message);

            var response = await Client.SendAsync(message);
            return await JsonSerializer<TResponse>(response);
        }
        catch (WebException ex)
        {
            var source = ExceptionDispatchInfo.Capture(ex);
            return ProcessSlackException<TResponse>(ex, source);
        }
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