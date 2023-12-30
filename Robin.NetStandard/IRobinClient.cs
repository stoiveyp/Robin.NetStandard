namespace Robin.NetStandard;

public interface IRobinClient
{
    Task<TResponse?> MakeJsonCall<TResponse>(HttpMethod method, string path, Dictionary<string,string>? query = null);
    Task<TResponse?> MakeJsonCall<TRequest, TResponse>(HttpMethod method, string path, TRequest request);
}