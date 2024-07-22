using APW.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APW.Service;

public interface IRestApwService
{
    Task<object> GetApwServiceAsync();
    Task<object> PostApwServiceAsync();
}

public class RestApwService(IRestProvider restProvider) : IRestApwService
{
    private readonly IRestProvider _restProvider = restProvider;

    public async Task<object> GetApwServiceAsync()
    {
        var response = await _restProvider.GetAsync($"https://api.restful-api.dev/objects", null);
        return response;
    }

    public async Task<object> PostApwServiceAsync()
    {
        // content
        string content = "";
        var response = await _restProvider.PostAsync($"https://localhost:7154/api/Vehicle/", content);
        return response;
    }
}
