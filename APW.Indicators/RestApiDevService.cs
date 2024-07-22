using APW.Architecture;

namespace APW.Service;

public interface IRestApiDevService
{
    Task<object> GetRestDevListAsync();
    Task<object> GetRestDevSingleAsync(string id);
}

public class RestApiDevService(IRestProvider restProvider) : IRestApiDevService
{
    private readonly IRestProvider _restProvider = restProvider;

    public async Task<object> GetRestDevListAsync()
    {
        try
        {
            return await _restProvider.GetAsync("https://api.restful-api.dev/objects?id=3&id=5&id=10", null);
        }
        catch { throw; }
    }

    public async Task<object> GetRestDevSingleAsync(string id)
    {
        try
        {
            return await _restProvider.GetAsync("https://api.restful-api.dev/objects/", id);
        }
        catch { throw; }
    }

}
