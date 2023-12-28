namespace Robin.NetStandard;

public interface IRobinClient
{
    Task<ApiResponse<TResponse?>?> MakeJsonCall<TResponse>(HttpMethod method, string path) ;
    Task<ApiResponse<TResponse?>?> MakeJsonCall<TRequest, TResponse>(HttpMethod method, string path, TRequest request);
}